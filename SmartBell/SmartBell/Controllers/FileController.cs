using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmartBell.Controllers
{
    [ApiController]
    [Route("File")]
    public class FileController : ControllerBase
    {
        [HttpPost,DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length>0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullpath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
