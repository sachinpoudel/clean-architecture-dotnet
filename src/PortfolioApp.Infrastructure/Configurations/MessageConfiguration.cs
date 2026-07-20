using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Configurations;


public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");
        builder.Property(m => m.SenderName).HasMaxLength(100);
        builder.Property(m => m.SenderEmail).HasMaxLength(100);
        builder.Property(m => m.Subject).HasMaxLength(200);
        builder.Property(m => m.Content).HasMaxLength(2000);
    }
}