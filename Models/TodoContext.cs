using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace TodoApi.Models
{
  public class TodoContext : DbContext
  {
    // public TodoContext(DbContextOptions<TodoContext> options)
    //   : base(options)
    // {
      
    // }
    public DbSet<TodoItem> TodoItem {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=tasks;user=user;password=password");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<TodoItem>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name);
        entity.Property(e => e.IsComplete).HasColumnType("bit");
      });
    }

  }
}