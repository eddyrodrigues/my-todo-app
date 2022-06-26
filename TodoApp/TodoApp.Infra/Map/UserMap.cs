using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Domain.Entities;

namespace TodoApp.Infra.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("User");

    builder.HasKey(p => p.Id);
    
    builder.Property(p => p.Id).HasColumnName("Id");
    builder.Property(p => p.Name).HasColumnName("Name");
  }
}