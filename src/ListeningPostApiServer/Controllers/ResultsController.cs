using ListeningPostApiServer.Data;
using ListeningPostApiServer.Extensions;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ResultsController : ControllerBase
    {
        public ResultRepository _repository;

        public ResultsController(IRepository<Result> repository)
        {
            _repository = (ResultRepository)repository;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetResults(string id)
        {
            if (Guid.TryParse(id, out var guid))
            {
                return Ok(await _repository.GetByGuidAsync(guid));
            }

            if (int.TryParse(id, out var taskId))
            {
                var task = await _repository.GetByIdAsync(taskId);
                return Ok(task.Results);
            }

            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost("{nodeId}")]
        public async Task<IActionResult> PostResult(int nodeId, [FromBody] Result result)
        {
            this.Log($"Implant returning. Implant Id:{nodeId}");

            if (result.TaskId is int taskId)
            {
                var task = await _repository.Context.Set<TaskBase>().FindAsync(taskId);

                this.Log($"TaskId: {taskId}");

                var newResult = new Result()
                {
                    TaskBase = task,
                    Error = result.Error,
                    Implant = task.Implant,
                    Results = result.Results
                };

                await _repository.CreateAsync(newResult);
                task.IsReturned = true;
                await _repository.SaveChangesAsync();

                return CreatedAtAction("GetResults", new { newResult.Id }, null);
            }

            return NoContent();
        }
    }
}