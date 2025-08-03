

using NewsAnalysisAPI.DTOs;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace NewsAnalysisAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly string _connectionString;

        public NewsService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            var newsList = new List<NewsDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Id, Title, Content, Author, Source FROM News";
                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var news = new NewsDTO
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Content = reader.GetString(2),
                        Author = reader.GetString(3),
                        Source = reader.GetString(4)
                    };

                    newsList.Add(news);
                }
            }

            return newsList;
        }
        public NewsDTO? GetNewsById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT Id, Title, Content, Author, Source FROM News WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new NewsDTO
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Content = reader.GetString(2),
                    Author = reader.GetString(3),
                    Source = reader.GetString(4)
                };
            }

            return null;
        }
    }
}
