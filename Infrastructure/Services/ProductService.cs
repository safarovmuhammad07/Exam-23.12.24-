using System.Net;
using Dapper;
using DoMain.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Primitives;

namespace Infrastructure.Services;

public class ProductService(IContext _context):IProductService
{
   
    public async Task<Response<List<Product>>> GetProducts()
    {
        try
        {
            const string sql = @"select * from Products";
            var res = await _context.Connection().QueryAsync<Product>(sql);
            return new Response<List<Product>>(res.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
        try
        {
            const string sql = @"select * from Products where ProductId = @id";
            var res = await _context.Connection().QuerySingleOrDefaultAsync<Product>(sql, new { id });
            return new Response<Product>(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> AddProduct(Product product)
    {
        try
        {
            const string sql = @"insert into Products (ProductName,Price,Stock ) values (@ProductName, @Price, @Stock)";
            var res = await _context.Connection().ExecuteAsync(sql, product);
            return res == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.Created, "Product added successfully");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> UpdateProduct(Product product)
    {
        try
        {
            const string sql = @"update Products set ProductName = @ProductName, Price=@Price, Stock=@Stock where ProductId = @ProductId";
            var res = await _context.Connection().ExecuteAsync(sql, product);
            return res == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.OK, "Product updated successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

   

    public async Task<Response<bool>> DeleteProduct(int id)
    {
        try
        {
            const string sql = @"delete from Products where ProductId = @id";
            var res = await _context.Connection().ExecuteAsync(sql, new { id });
            return res == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.OK, "Product deleted successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Response<bool>> AddTextToFile()
    {
        IProductService service = new ProductService(_context);
        var products = service.GetProducts();
        const string path = "C:\\Users\\Safarov\\Desktop\\.Net Course\\Examination(23.12.24)\\DoMain\\Exam_Task.md";
        while (File.Exists(path))
        {
            foreach (var s in  products.Result.Date)
            {
                File.AppendAllText(path, $"{s.Name} , {s.Description} , {s.Price} , {s.StockQuantity} , {s.CategoryName} , {s.CreatedDate}");
            }
        }
        return Task.FromResult(new Response<bool>(HttpStatusCode.OK, "Product added successfully"));
    }
    
}