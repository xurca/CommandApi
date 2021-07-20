using System.Collections.Generic;
using CommandApi.Data;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _rep;

        public CommandsController(ICommandRepo rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAll() => Ok(_rep.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var command = _rep.GetById(id);

            if (command == null) return NotFound();

            return Ok(command);
        }
    }
}