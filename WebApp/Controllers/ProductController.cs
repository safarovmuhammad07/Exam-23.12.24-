using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService):ControllerBase
{
    [HttpGet]
    public Task<Response<List<Product>>> Get()
    {
        return productService.GetProducts();
    }

    [HttpGet("{id}")]
    public Task<Response<Product>> Get(int id)
    {
        return productService.GetProductById(id);
        
    }

    [HttpPost]
    public Task<Response<bool>> Add(Product product)
    {
        return productService.AddProduct(product);
    }

    [HttpPut]
    public Task<Response<bool>> Update(Product product)
    {
        return productService.UpdateProduct(product);
    }

    [HttpDelete("{id}")]
    public Task<Response<bool>> Delete(int id)
    {
        return productService.DeleteProduct(id);
    }

    [HttpGet("file")]
    public Task<Response<bool>> AddTextToFile()
    {
        return productService.AddTextToFile();
    }
}