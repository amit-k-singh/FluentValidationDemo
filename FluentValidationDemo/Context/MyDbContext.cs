using FluentValidationDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.Context;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}
