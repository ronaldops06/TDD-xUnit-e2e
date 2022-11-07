using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDtoResult> Get(Guid id);
        Task<IEnumerable<UserDtoResult>> GetAll();
        Task<UserDtoResult> Post(UserDto user);
        Task<UserDtoResult> Put(UserDto user);
        Task<bool> Delete(Guid id);
    }
}
