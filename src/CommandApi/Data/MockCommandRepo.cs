using System.Collections.Generic;
using System.Linq;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class MockCommandRepo //: ICommandRepo
    {
        public void Create(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAll()
        {
            return new List<Command>
            {
                new Command
                {
                    Id=0,
                    HowTo="How to genrate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migration>",
                    Platform=".Net Core EF"
                },
                new Command
                {
                    Id=1,
                    HowTo="Run Migrations",
                    CommandLine="dotnet ef database update",
                    Platform=".Net Core EF"
                },
                new Command
                {
                    Id=2,
                    HowTo="List active migrations",
                    CommandLine="dotnet ef migrations list",
                    Platform=".Net Core EF"
                }
            };
        }

        public Command GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}