using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers;

using System.Security.Cryptography;
using DTO;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Model;
using Services;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("user")]
public class UsuarioController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]UserData user,
        [FromServices]IUsuarioService service,
        [FromServices]ISecurityService security,
        [FromServices]CryptoService crypto)
    {
        var loggedUser = await service
            .GetByLogin(user.Cpf);

        Console.WriteLine(user.Cpf);
        
        if (loggedUser == null)
            return Unauthorized("Usuário não existe.");
        
        var password = await security.HashPassword(
            user.Senha, loggedUser.Salt
        );
        var realPassword = loggedUser.Senha;
        if (password != realPassword)
            return Unauthorized("Senha incorreta.");

        var jwt = crypto.GetToken(new {
            id = loggedUser.Id,
            photoId = loggedUser.ImagemId,
            isAdm = loggedUser.Adm
        });
        
        return Ok(new { jwt });
    }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]UserData user,
        [FromServices]IUsuarioService service)
    {
        var errors = new List<string>();
        if (user is null || user.Cpf is null)
            errors.Add("É necessário informar um CPF.");
        if (user.Cpf.Length < 11)
            errors.Add("O CPF deve conter ao menos 11 caracteres.");

        if (errors.Count > 0)
            return BadRequest(errors);

        await service.Create(user);
        return Ok();
    }
}