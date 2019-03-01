using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseTesting
{
    public class Post
    {
        public Guid id { get; set; }
        public Content content { get; set; }
        public Guid userId { get; set; }
        public Comment comment { get; set; }
    }

    public class Content
    {
        public string text { get; set; }
        public string image { get; set; }
        public string hashTag { get; set; }
        public Location location { get; set; }
        public DateTime time { get; set; }
        public int like { get; set; }
        public int dislike { get; set; } 
}
    public class Comment
    {

    }
}
