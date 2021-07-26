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
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne<Question>()
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
