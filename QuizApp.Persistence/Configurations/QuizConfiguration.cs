using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();

            builder
                .HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatorId);

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Status)
                .HasDefaultValue(QuizStatus.Creating);

        }
    }
}
