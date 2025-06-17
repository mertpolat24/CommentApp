using CommentApp_Cores.Enums;

namespace CommentApp_Cores.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
