using CommentApp_Cores.Abstract;

namespace CommentApp_Cores.Models
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }
        public string Title { get; set; }
        public int Point { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
