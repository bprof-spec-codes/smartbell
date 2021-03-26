﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult Upload(IFormFile FileToUpload)
        {
            try
            {
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (FileToUpload != null || FileToUpload.Length > 0)
                {
                    var fullpath = Path.Combine(pathToSave, FileToUpload.FileName);

                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        FileToUpload.CopyTo(stream);
                    }
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpGet("{filename}")]
        public FileResult Download(string filename)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            var path = Path.Combine(folder, filename);
            byte[] allbytes = System.IO.File.ReadAllBytes(path);
            return File(allbytes, "application/octet-stream",filename);
        }

        [HttpPost("PostTTSString/{content} & {filename}")]
        public IActionResult PostTTSFileFromString(string content, string filename)
        {
            try
            {
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                var fullpath = Path.Combine(pathToSave, filename);
                if (!System.IO.File.Exists(fullpath))
                {
                    System.IO.File.WriteAllText(fullpath, content);
                    return Ok();
                }
                return BadRequest("File already exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("DeleteTTSByName/ {filename}")]
        public IActionResult DeleteTTSFileByName(string filename)
        {
            try
            {
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                var fullpath = Path.Combine(pathToSave, filename);
                if (System.IO.File.Exists(fullpath))
                {
                    System.IO.File.Delete(fullpath);
                    return Ok();
                }
                return BadRequest("File does not exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
