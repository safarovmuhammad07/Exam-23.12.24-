

using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IContext, DapperContext>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Rest API"));
}

app.UseHttpsRedirection();




app.MapControllers();
app.Run();






//
// ﻿
//
// #region 1.Создание и удаление файла
//
// using System.IO.Compression;
// using System.Net;
// using System.Text;
// using System.Threading.Channels;
//
// // string path = @"C:\Users\VICTUS\Desktop\text.txt";
// // File.Create(path);
// // File.AppendAllText(path:path,"Hello, world!");
// // Console.WriteLine("File created");
// // File.Delete(path);
// // Console.WriteLine("file deleted");
// #endregion
//
// #region 3.Работа с файлами и папками
// // string path2 = @"C:\Users\VICTUS\Desktop\test4";
// // Directory.CreateDirectory(path2);
// // File.Create(path2+"\\test.txt");
// // File.Create(path2+"\\test2.txt");
// // File.Create(path2+"\\test3.txt");
// // List<string> files = new List<string>(Directory.GetFiles(path2));
// //
// // foreach (var item in files)
// // {
// //     Console.WriteLine(item);
// // }
//
// #endregion
//
// #region 4.Архивирование файлов в ZIP
//
// // string path = @"C:\Users\VICTUS\Desktop\test4";
// // string zip = @"C:\Users\VICTUS\Desktop\backup.zip";
// // ZipFile.CreateFromDirectory(path, zip);
//
// #endregion
//
// #region 5.Поиск файла по имени
//
// // string path = @"C:\Users\VICTUS\Desktop\test4";
// // string searchPattern = "test3.txt";
// // string result = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).FirstOrDefault();
// //
// // if (result!= null)
// // {
// //     Console.WriteLine($"File '{searchPattern}' found: {result}");
// // }
//
// #endregion
//
// #region 6. Сравнение двух файлов
// // string file1 = @"C:\Users\VICTUS\Desktop\test4\test3.txt";
// // string file2 = @"C:\Users\VICTUS\Desktop\test4\test2.txt";
// //
// // File.AppendAllText(file1,"sasas");
// //
// // bool isEqual = File.ReadAllText(file1) == File.ReadAllText(file2);
// //
// // Console.WriteLine($"Files are equal: {isEqual}");
// #endregion
//
// #region 7. Чтение большого файла частями
// // string path = @"C:\Users\VICTUS\Desktop\text.txt";
// //
// //
// // using (FileStream fileStream = File.OpenRead(path))
// // {
// //         byte[] buffer = new byte[path.Length];
// //         fileStream.Read(buffer, 0, buffer.Length);
// //         Console.WriteLine(Encoding.UTF8.GetString(buffer));
// // }
// #endregion
//
// #region 8. Переименование файла
// // string path = @"C:\Users\VICTUS\Desktop\test4\test3.txt";
// // string newPath = @"C:\Users\VICTUS\Desktop\test4\test10.txt";
// //
// // File.Move(path, newPath);
// #endregion
//
// #region  9.Копирование файлов
// // string path = @"C:\Users\VICTUS\Desktop\test4";
// // string destPath = @"C:\Users\VICTUS\Desktop\test5";
// //
// // Directory.CreateDirectory(destPath);
// //
// // foreach (var file in Directory.GetFiles(path))
// // {
// //     string destFile = Path.Combine(destPath, Path.GetFileName(file));
// //     File.Copy(file, destFile, true);
// // }
//
// #endregion
//
// #region 11. Проверка существования файла
// // string path = @"C:\Users\VICTUS\Desktop\test4\tes10.txt";
// // bool exists = File.Exists(path);
// // Console.WriteLine($"File exists: {exists}");
// #endregion
//
// #region 12. Чтение содержимого директории
// // string dirPath = @"C:\Users\VICTUS\Desktop\test4";
// //
// // foreach (var file in Directory.GetFiles(dirPath))
// // {
// //     Console.WriteLine(file);
// // }
// #endregion
//
// #region 13. Удаление всех файлов с определённым расширением
// // string dirPath = @"C:\Users\VICTUS\Desktop\test4";
// // string res = ".txt";
// //
// // string[] m =Directory.GetFiles(dirPath, $"*{res}", SearchOption.AllDirectories);
// //
// // foreach (var item in m)
// // {
// //     Console.WriteLine(item);
// // }
//
// // foreach (var file in Directory.GetFiles(dirPath, $"*{res}", SearchOption.AllDirectories))
// // {
// //     File.Delete(file);
// // }
// #endregion
//
// #region 14. Копирование текстового файла с изменением содержания
// // string path = @"C:\Users\VICTUS\Desktop\test5\test.txt";
// // string newPath = @"C:\Users\VICTUS\Desktop\test5\test_toupper.txt";
// // // File.AppendAllText(path,"testtt");
// //
// // using (StreamReader reader = new StreamReader(path))
// // using (StreamWriter writer = new StreamWriter(newPath))
// // {
// //     string line;
// //     while ((line = reader.ReadLine())!= null)
// //     {
// //         writer.WriteLine(line.ToUpper());
// //     }
// // }
// #endregion
//
// #region 15. Извлечение файлов из ZIP-архива
// // string zipPath = @"C:\Users\VICTUS\Desktop\backup.zip";
// // string extractPath = @"C:\Users\VICTUS\Desktop\test6";
// // ZipFile.ExtractToDirectory(zipPath, extractPath);
// #endregion
//
// #region 16. Получение размера файла 
// // string filePath = @"C:\Users\VICTUS\Desktop\test5\test_uppercase.txt";
// // FileInfo fileInfo = new FileInfo(filePath);
// // Console.WriteLine(fileInfo.Length+"bytes");
// #endregion
//
// #region 17. Получение даты последнего изменения файла
// // string path = @"C:\Users\VICTUS\Desktop\test5\test.txt";
// // FileInfo fileInfo = new FileInfo(path);
// // Console.WriteLine(fileInfo.LastWriteTime);
// #endregion
//
// #region 18. Перемещение файлов
// //
// // string path = @"C:\Users\VICTUS\Desktop\test5\test.txt";
// // string dirpath = @"C:\Users\VICTUS\Desktop\test4";
// // string destPath = Path.Combine(dirpath, Path.GetFileName(path));
// // File.Move(path, destPath);
// #endregion
//
// #region 19. Запись строки в текстовый файл
// //
// // string path = @"C:\Users\VICTUS\Desktop\test.txt";
// // using (StreamWriter writer = new StreamWriter(path, true))
// // {
// //     writer.WriteLine("Hello, world!");
// // }
// #endregion
//
// #region 20. Поиск всех файлов с определённым расширением
// // string dirPath = @"C:\Users\VICTUS\Desktop\test6";
// // string res = ".txt";
// // string[] m = Directory.GetFiles(dirPath, $"*{res}", SearchOption.AllDirectories);
// // foreach (var item in m)
// // {
// //     Console.WriteLine(item);
// // }
// #endregion







