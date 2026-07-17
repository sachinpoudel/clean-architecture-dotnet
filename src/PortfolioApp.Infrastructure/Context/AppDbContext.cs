using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Context;


    
public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options) {
    

  internal DbSet<Education> Educations { get; set; } = null!;
    internal DbSet<Experience> Experiences { get; set; } = null!;
    internal DbSet<Project> Projects { get; set; } = null!;
    internal DbSet<Skills> Skills { get; set; } = null!;
    internal DbSet<SocialLinks> SocialLinks { get; set; } = null!;
    internal DbSet<Message> Messages { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}