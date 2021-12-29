using UserRolModel.Models;
using System.Collections.Generic;
using UserModel.Models;

namespace Commander.Data{
    public class MockUserRolRepo : IUserRolRepo
    {

        public void CreateUserRol(UserRol cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserRol(UserRol cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRol> GetUserRol()
        {
            throw new NotImplementedException();
        }

        public UserRol GetUserRolById(int id)
        {
            throw new NotImplementedException();
        }
       
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserRol(UserRol cmd)
        {
            throw new NotImplementedException();
        }
    }
}