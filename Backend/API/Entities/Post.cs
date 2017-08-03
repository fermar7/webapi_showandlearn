using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Post
    {
        public string Username { get; set; }

        public string UserTag { get; set; }

        public string PostText { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
