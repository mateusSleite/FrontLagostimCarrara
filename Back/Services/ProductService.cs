using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DTO;
using System.Collections.Generic;
using Back.Model;

namespace Back.Services
{
    public class ProductService : IProductService 
    {
        BackDbContext ctx;

        public ProductService(BackDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task Create(ProdutoData data)
        {
            Produto produto = new Produto();
            
            produto.Nome = data.Nome;
            produto.Ingredientes = data.Ingredientes;
            produto.Descricao = data.Descricao;
            produto.Preco = data.Preco;
            produto.Idimagem = data.Idimagem;

            this.ctx.Add(produto);
            await this.ctx.SaveChangesAsync();
        }

        public async Task<List<Produto>> Get()
        => await this.ctx.Produtos.ToListAsync();
    }
}
