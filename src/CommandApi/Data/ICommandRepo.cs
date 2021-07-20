using CommandApi.Models;
using System.Collections.Generic;

namespace CommandApi.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAll();
        Command GetById(int id);
        void Create(Command cmd);
        void Update(Command cmd);
        void Delete(Command cmd);
    }
}