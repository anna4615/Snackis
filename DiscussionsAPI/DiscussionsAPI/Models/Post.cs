using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? PostId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string OnlyForUserName { get; set; }
        public bool IsOffensiv { get; set; } = false;
    }
}
