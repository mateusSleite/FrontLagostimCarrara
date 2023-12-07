using System.Threading.Tasks;
using System.Collections.Generic;

namespace Back.Services;

using DTO;
using Model;

public interface IProductService
{
    Task Create(ProdutoData data);
    Task<List<Produto>> Get();

}