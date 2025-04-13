using Microsoft.EntityFrameworkCore; // ต้องมีการ import
using TaskyApp.Domain.Entities; // ต้องมีการ import

namespace TaskyApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> TaskItems => Set<TaskItem>(); // กำหนด DbSet สำหรับ TaskItem
}
