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
        ModificationLogic modlogic;
        ReadLogic readlogic;

        public OutputPathController(ModificationLogic logic, ReadLogic readlogic)
        {
            this.modlogic = logic;
            this.readlogic = readlogic;
        }

        [HttpDelete("{id}")]
        public void DeleteOutputPath(string id)
        {
            OutputPath outputPath = readlogic.GetOneOutputPath(id);
            modlogic.DeleteOutputPath(outputPath);
        }
        [HttpGet("{id}")]
        public OutputPath GetOutputPath(string id)
        {
            return readlogic.GetOneOutputPath(id);
        }
        [HttpGet]
        public IEnumerable<OutputPath> GetAllOutputPaths()
        {
            return readlogic.GetAllOutputPath();
        }

        [HttpPost]
        public void AddOutputPath([FromBody] OutputPath item)
        {
            modlogic.InsertOutputPath(item);
        }
    }
}
