using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PostCreateModel
    {
        public string Username { get; set; }

        public string UserTag { get; set; }

        public string Text { get; set; }
    }
}
