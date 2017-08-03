using API.Entities;
using API.Services;
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
        private PostService Service { get; set; }

        public PostController(IPostService service)
        {
            Service = new PostService();
        }


        [HttpGet]
        public IActionResult ListPosts()
        {
            return Ok(Service.List());
        }

        [HttpPost]
        public IActionResult CreatePost(PostCreateModel createModel)
        {
            Service.Create(createModel);
            return NoContent();
        }

    }
}
