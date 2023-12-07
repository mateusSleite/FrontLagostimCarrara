using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Text.Json;
using Trevisharp.Security.Jwt;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;



namespace Back.Controllers;

using Model;
using DTO;
using Services;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly BackDbContext _dbContext;

    public ProductController(BackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("new")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> CadastrarProduto(
        [FromBody] ProdutoData produto,
        [FromServices] IProductService service
    )
    {
        await service.Create(produto);
        return Ok();
    }

    [HttpGet("product")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> VerProduto(
         [FromServices] IProductService service
     )
    {
        var a = await service.Get();
        var errors = new List<string>();
        if (errors.Count > 0)
            return BadRequest(errors);

        return Ok(new { a });
    }

    [DisableRequestSizeLimit]
    [HttpPost("imagem")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> AddImage(
        [FromServices] CryptoService security
    )
    {
        var jwtData = Request.Form["jwt"];
        var jwtObj = JsonSerializer.Deserialize<JwtToken>(jwtData);

        var jwt = jwtObj.jwt;

        var userOjb = security.Validate<JwtPayload>(jwt);

        if (userOjb is null)
            return Unauthorized();

        var userId = userOjb.id;

        var files = Request.Form.Files;
        if (files is null || files.Count == 0)
            return BadRequest();

        var file = files[0];
        if (file.Length < 1)
            return BadRequest();

        using MemoryStream ms = new MemoryStream();

        await file.CopyToAsync(ms);
        var data = ms.GetBuffer();

        Imagem img = new Imagem();
        img.Foto = data;

        _dbContext.Add(img);
        await _dbContext.SaveChangesAsync();

        return Ok(new
        {
            imgID = img.Id
        });
    }

    [HttpGet("image/{photoId}")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> GetImage(
        int photoId,
        [FromServices] ISecurityService security,
        [FromServices] BackDbContext ctx
    )
    {
        var query =
            from imagem in ctx.Imagems
            where imagem.Id == photoId
            select imagem;


        var photo = await query.FirstOrDefaultAsync();
        if (photo is null)
            return NotFound();

        return File(photo.Foto, "image/jpeg");
    }
}
