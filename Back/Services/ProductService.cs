using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DTO;
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
    }
}
