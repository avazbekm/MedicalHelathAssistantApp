﻿using Domain.Configuration;
using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllUsersAsync();
    Task<IEnumerable<UserResultDto>> GetAllUsersAsync(PaginationParams @params);
    Task<UserResultDto> GetAsync(long id);
}
