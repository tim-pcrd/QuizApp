using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne<Quiz>()
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuizId);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
