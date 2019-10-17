using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApi.Models;
using System.Text;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            PrintData();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
                
        public static void InsertData()
        {
            using(var context = new TodoContext())
            {
                context.Database.EnsureCreated();

                var todoItem = new TodoItem
                {
                    Name = "Connect to DB",
                    IsComplete = true
                };
                context.TodoItem.Add(todoItem);

                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new TodoContext())
            {
                var todoItems = context.TodoItem;
                foreach(var todoItem in todoItems)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {todoItem.ID}");
                    data.AppendLine($"Task: {todoItem.Name}");
                    data.AppendLine($"Completed: {todoItem.IsComplete}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
