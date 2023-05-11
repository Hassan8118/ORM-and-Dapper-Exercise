using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

          var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

          string connString = config.GetConnectionString("DefaultConnection");

          IDbConnection conn = new MySqlConnection(connString);

//var departmentRepo = new DapperDepartmentRepository(conn);

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//    Console.WriteLine();
//}

var productRepository = new DapperProductRepository(conn);
//var productToUpdate = productRepository.GetProduct(941);
//productToUpdate.Name = "UPDATED!!!";
//productToUpdate.Price = 12.99;
//productToUpdate.CategoryID = 1;
//productToUpdate.OnSale = false;
//productToUpdate.StockLevel = 1000;
//productRepository.UpdateProduct(productToUpdate);

productRepository.DeleteProduct(941);
var products = productRepository.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.ProductId);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}