using API.Controllers;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace API.Services
{
    public class PostService : IPostService
    {
        public static List<Post> Posts = new List<Post>();

        public List<PostModel> List()
        {
            var viewModels = new List<PostModel>();

            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\mssqllocaldb";
            builder.InitialCatalog = "TestDB";
            builder.IntegratedSecurity = true;

            var connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            var command = new SqlCommand("select * from Posts", connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var viewModel = new PostModel();
                viewModel.Username = reader["Username"].ToString();
                viewModel.UserTag = reader["UserTag"].ToString();
                viewModel.PostText = reader["PostText"].ToString();
                viewModel.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]).ToString("dd.MM.yyyy, HH:mm");
                
                viewModels.Add(viewModel);
            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            command.Dispose();

            return viewModels;
        }

        public void Create(PostCreateModel createModel)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\mssqllocaldb";
            builder.InitialCatalog = "TestDB";
            builder.IntegratedSecurity = true;

            var connection = new SqlConnection(builder.ConnectionString);

            connection.Open();
            
            var command = new SqlCommand("insert into Posts (Username, UserTag, PostText, CreatedAt) values(@Username, @UserTag, @PostText, @CreatedAt)", connection);

            command.Parameters.AddRange( new[] {
                new SqlParameter("@Username", createModel.Username),
                new SqlParameter("@UserTag", createModel.UserTag),
                new SqlParameter("@PostText", createModel.PostText),
                new SqlParameter("@CreatedAt", DateTime.Now) });

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            command.Dispose();
        }
    }
}
