using System.Collections.Generic;
using API.Controllers;

namespace API.Services
{
    public interface IPostService
    {
        void Create(PostCreateModel createModel);
        List<PostModel> List();
    }
}