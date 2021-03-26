using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBell.Controllers
{
    [ApiController]
    [Route("OutPutPath")]
    public class OutputPathController : ControllerBase
    {
        ModificationLogic logic;

        public OutputPathController(ModificationLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteOutputPath(string id)
        {
            OutputPath outputPath = logic.GetOneOutputPath(id);
            logic.DeleteOutputPath(outputPath);
        }
        [HttpGet("{id}")]
        public OutputPath GetOutputPath(string id)
        {
            return logic.GetOneOutputPath(id);
        }
        [HttpGet]
        public IEnumerable<OutputPath> GetAllOutputPaths()
        {
            return logic.GetAllOutputPath();
        }

        [HttpPost]
        public void AddOutputPath([FromBody] OutputPath item)
        {
            logic.InsertOutputPath(item);
        }
    }
}
