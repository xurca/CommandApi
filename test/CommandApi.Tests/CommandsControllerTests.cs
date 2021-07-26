using Xunit;
using System.Collections.Generic;
using Moq;
using CommandApi.Data;
using CommandApi.Models;
using AutoMapper;
using System;
using CommandApi.Controllers;
using CommandApi.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Tests
{
    public class CommandsControllerTests
    {
        [Fact]
        public void GetAll_Returns0Items_WhenDbIsEmpty()
        {
            var mockRepo = new Mock<ICommandRepo>();

            mockRepo.Setup(repo => repo.GetAll()).Returns(GetCommands(0));

            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);

            var controller = new CommandsController(mockRepo.Object, mapper);

            var result = controller.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        private IEnumerable<Command> GetCommands(int num)
        {
            var commands = new List<Command>();

            if (num > 0)
            {
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"
                });
            }

            return commands;
        }
    }
}