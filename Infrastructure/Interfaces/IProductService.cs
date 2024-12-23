using DoMain.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetProducts();
    Task<Response<Product>> GetProductById(int id);
    Task<Response<bool>> AddProduct(Product product);
    Task<Response<bool>> UpdateProduct(Product product);
    Task<Response<bool>> DeleteProduct(int id);
    Task<Response<bool>> AddTextToFile();
    
    
    
}