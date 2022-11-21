using System;
using Dapper;
using System.Data;
using System.IO;
using NordicDoor.Contracts;
using NordicDoor.Models;
using NordicDoor.Controllers.Data;

namespace NordicDoor.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<FileRepository> _logger;

        public FileRepository(DapperContext context, ILogger<FileRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyList<FileModel>> GetFileInfo()
        {
            var query = "SELECT * FROM filemodel";

            using (var connection = _context.CreateConnection())
            {
                var file = await connection.QueryAsync<FileModel>(query);
                return file.ToList();
            }
        }

        public async Task<FileModel> GetFileInfoById(int Id)
        {
            var query = "SELECT * FROM filemodel WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var file = await connection.QuerySingleOrDefaultAsync<FileModel>(query, new { Id });
                return file;
            }
        }

        public async void InsertFile(string name, string content)
        {
            var query = "INSERT INTO filemodel (FileName, Content) VALUES (@FileName, @Content)";

            _logger.LogInformation(name);

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("FileName", name, DbType.String);
                parameters.Add("Content", content, DbType.String);

                using (var connection = _context.CreateConnection())
                {
                    _logger.LogInformation(connection.ToString());
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Image file upload failed", ex);
            }
        }

        public bool UploadFileServer(IFormFile file)
        {
            string path = "";

            _logger.LogInformation(file.FileName);

            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        _logger.LogInformation(Path.Combine(path, file.FileName));
                        file.CopyToAsync(fileStream);
                        _logger.LogInformation(fileStream.Length.ToString());

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

        public async Task<int> UploadFileInDB(IFormFile imageFile)
        {
            try
            {
                string filePath = Path.GetTempFileName();
                using (var stream = File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }
                // Converts image file into byte[]
                byte[] imageData = await File.ReadAllBytesAsync(filePath);

                string content = Convert.ToBase64String(imageData);

                _logger.LogInformation(content);

                InsertFile(imageFile.FileName, content);

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}

