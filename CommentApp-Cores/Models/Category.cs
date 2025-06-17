using CommentApp_Cores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Cores.Models
{
    public class Category : BaseEntity
    {
        public ICollection< Comment> Comments {  get; } = new List< Comment>();
    }
}
