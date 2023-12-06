using System.Threading.Tasks;

namespace Back.Services;

using DTO;
using Model;

public interface IProductService
{
    Task Create(ProdutoData data);

}