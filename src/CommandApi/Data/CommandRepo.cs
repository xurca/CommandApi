using System;
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
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _db.Commands.Add(cmd);
        }

        public void Delete(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _db.Commands.Remove(cmd);
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
            return _db.SaveChanges() >= 0;
        }

        public void Update(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _db.Commands.Update(cmd);
        }
    }
}