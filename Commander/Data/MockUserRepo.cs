using UserModel.Models;
using System.Collections.Generic;

namespace Commander.Data{
    public class MockUserRepo : IUserRepo
    {
        public void CreateUser(User cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User cmd)
        {
            throw new NotImplementedException();
        }
    }

    
}