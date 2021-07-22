using System.Collections.Generic;
using AutoMapper;
using CommandApi.Data;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;
using CommandApi.Dtos;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _rep;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll() => Ok(_mapper.Map<IEnumerable<CommandReadDto>>(_rep.GetAll()));

        [HttpGet("{id}", Name ="Get")]
        public ActionResult<CommandReadDto> Get(int id)
        {
            var command = _rep.GetById(id);

            if (command == null) return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> Create(CommandCreateDto cmdDto)
        {
            var cmd = _mapper.Map<Command>(cmdDto);

            _rep.Create(cmd);
            _rep.SaveChanges();

            return CreatedAtRoute(nameof(Get), new { id = cmd.Id }, cmd);
        }
    }
}