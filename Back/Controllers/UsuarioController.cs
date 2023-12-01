using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace Back.Controllers;

using DTO;
using Services;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("user")]
public class UsuarioController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]UserDataLogin user,
        [FromServices]IUsuarioService service,
        [FromServices]ISecurityService security,
        [FromServices]CryptoService crypto)
    {
        var loggedUser = await service
            .GetByLogin(user.Cpf);
        
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
            isAdm = loggedUser.Adm,
            name = loggedUser.Nome
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