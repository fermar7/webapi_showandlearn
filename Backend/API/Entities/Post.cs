using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string UserTag { get; set; }

        public DateTime PostedAt { get; set; }

        public string Text { get; set; }
    }
}
