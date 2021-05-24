using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SnackisApp.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("subjectId")]
        public int SubjectId { get; set; }
        
        [JsonPropertyName("subject")]
        public Subject Subject { get; set; }
        
        [JsonPropertyName("postId")]
        public int? PostId { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("isPrivate")]
        public bool IsPrivate { get; set; } = false;
        
        [JsonPropertyName("onlyForUserName")]
        public string OnlyForUserName { get; set; }
        
        [JsonPropertyName("isOffensiv")]
        public bool IsOffensiv { get; set; } = false;
    }
}
