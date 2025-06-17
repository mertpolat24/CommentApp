using CommentApp_Cores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Repositories.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.CommentContent).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar()");
            builder.Property(t => t.Title).IsRequired().HasColumnType("nvarchar(50)");
        }
    }
}
