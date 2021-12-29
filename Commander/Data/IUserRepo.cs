using System.Collections.Generic;
using UserModel.Models;
    namespace Commander.Data
    {
    public interface IUserRepo
    {
    bool SaveChanges();

    IEnumerable<User> GetUsers();

    User GetUserById(int id);

    void CreateUser(User cmd);
    void UpdateUser(User cmd);
    void DeleteUser(User cmd);
    }
}

