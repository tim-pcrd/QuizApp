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
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(x => x.Image)
                .WithOne()
                .HasForeignKey<Player>(x => x.ImageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
