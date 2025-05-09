using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Shared;

namespace TodoApp.Domain.EntitiesConfiguration
{
    class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .ToTable("Todos")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500);

            builder
                .Property(x => x.Status)
                .HasDefaultValue(Status.Pending);

            builder
                .Property(x => x.Priority)
                .HasDefaultValue(Priority.Low);

            builder
                .Property(x => x.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
