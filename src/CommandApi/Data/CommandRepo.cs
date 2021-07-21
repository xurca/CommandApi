using System.Collections.Generic;
using System.Linq;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly CommandContext _db;

        public CommandRepo(CommandContext db)
        {
            _db = db;
        }

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
            return _db.Commands.ToList();
        }

        public Command GetById(int id)
        {
            return _db.Commands.Find(id);
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