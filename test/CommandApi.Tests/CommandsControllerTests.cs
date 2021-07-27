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
using CommandApi.Dtos;

namespace CommandApi.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        private Mock<ICommandRepo> mockRepo;
        private CommandsProfile realProfile;
        private MapperConfiguration configuration;
        private IMapper mapper;

        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandRepo>();
            realProfile = new CommandsProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetAll_Returns0Items_WhenDbIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetCommands(0));
            var controller = new CommandsController(mockRepo.Object, mapper);

            var result = controller.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAll_Returns1Item_WhenDbHas1Resource()
        {
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);
            var result = controller.GetAll();

            var okResult = result.Result as OkObjectResult;
            var commands = okResult.Value as List<CommandReadDto>;

            Assert.Single(commands);
        }

        [Fact]
        public void GetCommandByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetById(0)).Returns(() => null);
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Get(1);
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Get_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Get(1);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsCorrectType__WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Get(1);
            //Assert
            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }

        [Fact]
        public void Create_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Create(new CommandCreateDto { });
            //Assert
            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }

        [Fact]
        public void Create_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Create(new CommandCreateDto { });
            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void Update_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.Update(1, new CommandUpdateDto { });
            //Assert
            Assert.IsType<NoContentResult>(result);
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