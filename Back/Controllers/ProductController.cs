using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Text.Json;
using Trevisharp.Security.Jwt;

namespace Back.Controllers;
using Back.Model;

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

        // Declare ms antes de usá-la
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
}
