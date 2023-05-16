using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;


public class CMSDbContext : DbContext
{

    public CMSDbContext(DbContextOptions<CMSDbContext> options)
    : base(options)

    { }

    public DbSet<Employees> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
