using API.Entities;
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

        private static List<Post> Posts { get; } = new List<Post>();

        [HttpGet]
        public IActionResult List() {
            return Ok(Posts
                .OrderByDescending(x => x.PostedAt)
                .Select(x => new PostModel {
                    Id = x.Id,
                    PostedAt = x.PostedAt.ToString("dd.MM.yyyy, HH:mm"),
                    Username = x.Username,
                    UserTag = x.UserTag,
                    Text = x.Text
                })
                .ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostCreateModel model) {
            var newPost = new Post();
            newPost.Id = Guid.NewGuid();
            newPost.PostedAt = DateTime.Now;
            newPost.Username = model.Username;
            newPost.UserTag = model.UserTag;
            newPost.Text = model.Text;

            Posts.Add(newPost);

            return NoContent();
        }

    }
}
