using System.Collections.Generic;
using UserRolModel.Models;
    namespace Commander.Data
    {
    public interface IUserRolRepo
    {
    bool SaveChanges();

    IEnumerable<UserRol> GetUserRol();

    UserRol GetUserRolById(int id);

    void CreateUserRol(UserRol cmd);
    void UpdateUserRol(UserRol cmd);
    void DeleteUserRol(UserRol cmd);
    }
}

