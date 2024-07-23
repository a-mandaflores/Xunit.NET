using CloudCustomer.API.Models;
using System;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}
public class UsersServices : IUsersService
{
    public UsersServices()
    {
    }

    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}

