using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAppLogin.Domain.Entities;

namespace TodoAppLogin.Infra.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("User");

    builder.HasKey(p => p.Id);
    
    builder.Property(p => p.Id).HasColumnName("Id");
    builder.Property(p => p.Name).HasColumnName("Name");
    builder.Property(p => p.Email).HasColumnName("Email");
    builder.Property(p => p.Password).HasColumnName("Password");
  }
}