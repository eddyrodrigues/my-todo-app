using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Domain.Entities;

namespace TodoApp.Infra.Map;

public class TodoItemMap : IEntityTypeConfiguration<TodoItem>
{
  public void Configure(EntityTypeBuilder<TodoItem> builder)
  {
    builder.ToTable("Todos");

    builder.HasKey(o => o.Id);

    builder.Property(o => o.Description).HasMaxLength(400).HasColumnName("Description");
    builder.Property(o => o.Title).HasMaxLength(200).HasColumnName("Title");
    builder.Property(o => o.UserId).HasColumnName("UserId");
    // relationship
    builder.HasOne(o => o.User).WithMany(o => o.TodoItems).HasForeignKey(o => o.UserId).HasPrincipalKey(o => o.Id);
  }
}
