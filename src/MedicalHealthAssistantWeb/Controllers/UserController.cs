﻿using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Users;
using Service.Interfaces;

namespace MedicalHealthAssistantWeb.Controllers;

public class UserController : Controller
{
    private IUserService userService;
    
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await userService.GetAllUsersAsync();
        return View(result);
    }
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }


    public async Task<IActionResult> Signin(string password,string phone)
    {
        var result = await userService.SigninAsync(password, phone);
        if(result is true)
            return RedirectToRoute(new { controller = "Home", action = "AdminPage" });
        else
            return View();
    }

    public async Task<IActionResult> Signup(UserCreationDto dto)
    {
        dto.Address = "Tashkent, Yunusobod";
        var result = await userService.CreateAsync(dto);
        return RedirectToRoute(new { controller = "Home", action = "AdminPage"});
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await this.userService.DeleteAsync(id);
        return RedirectToRoute(new { controller = "User", action = "Index" });
    }
}
