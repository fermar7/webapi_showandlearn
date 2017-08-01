using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string UserTag { get; set; }

        public string PostedAt { get; set; }

        public string Text { get; set; }
    }
}
