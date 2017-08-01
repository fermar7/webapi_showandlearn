using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {

        private static List<PostModel> Posts { get; } = new List<PostModel>();

        [HttpGet]
        public IActionResult List() {
            return Ok(Posts.ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostCreateModel model) {
            var newPost = new PostModel();
            newPost.Id = Guid.NewGuid();
            newPost.PostedAt = DateTime.Now.ToString("dd.MM.yyyy, HH:mm");
            newPost.Username = model.Username;
            newPost.UserTag = model.UserTag;
            newPost.Text = model.Text;

            Posts.Add(newPost);

            return NoContent();
        }

    }
}
