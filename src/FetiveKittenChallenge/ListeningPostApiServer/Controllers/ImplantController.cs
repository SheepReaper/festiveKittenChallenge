using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListeningPostApiServer.Data;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListeningPostApiServer.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ImplantController : ControllerBase

    {
        private ImplantRepository _implantRepository { get; }

        public ImplantController(IRepository<Implant> implantRepository)
        {
            _implantRepository = (ImplantRepository)implantRepository;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return Ok(await _implantRepository.GetAllAsync());
            }

            return Ok(await _implantRepository.GetById(id));
        }

        //private async Task<Implant> GetImplantAsync(int implantId)
        //{
        //    return await ((ImplantRepository)_implantRepository).GetById(implantId);
        //}

        //[HttpPost]
        //[Route("{nodeId}/newTask/{command}")]
        //public async Task<IActionResult> AssignNewTask(int nodeId, string command)
        //{
        //    var implant = await _implantRepository.GetById(nodeId);
        //    var newTask = await implant.AssignNewTask(command);
        //    await _implantRepository.SaveChangesAsync();
        //    return CreatedAtAction("ListTasks","Tasking",new{Id = newTask.Guid},newTask);
        //}
    }
}
