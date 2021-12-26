using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException(); 
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
        {
            new Command{Id=0, UserName="Mariano", Email="elDestripador@gmail.com", CreationDate="2021-06-66", StatusId=1},
            new Command{Id=1, UserName="Prueba2", Email="prueba2@gmail.com", CreationDate="2021-12-22",StatusId=1},
            new Command{Id=2, UserName="Prueba3", Email="prueba2@gmail.com", CreationDate="2021-12-22",StatusId=1}
        };
        return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{ Id = 0, UserName = "Mariano", Email = "elDestripador@gmail.com", CreationDate = "2021-12-22", StatusId = 1 };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}