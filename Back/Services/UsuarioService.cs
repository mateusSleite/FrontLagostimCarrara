using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DTO;
using Back.Model;
using System;

namespace Back.Services;

public class UsuarioService : IUsuarioService
{
    BackDbContext ctx;
    ISecurityService security;
    public UsuarioService(BackDbContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }

    public async Task Create(UserData data)
    {
        Usuario usuario = new Usuario();
        var salt = await security.GenerateSalt();

        usuario.Nome = data.Nome;
        usuario.Cpf = data.Cpf;
        usuario.Email = data.Email;
        usuario.DataNasc = data.DataNasc;
        usuario.Numero = data.Numero;
        usuario.Senha = await security.HashPassword(
            data.Senha, salt
        );
        usuario.Salt = salt;
        usuario.Adm = false;

        this.ctx.Add(usuario);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Usuario> GetByLogin(string cpf)
    {
        var query =
            from u in this.ctx.Usuarios
            where u.Cpf == cpf
            select u;
        
        return await query.FirstOrDefaultAsync();
    }
}