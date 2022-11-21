using System;
using NordicDoor.Models;

namespace NordicDoor.Contracts
{
    public interface IFileRepository
    {
        public Task<FileModel> GetFileInfoById(int id);
        public Task<IReadOnlyList<FileModel>> GetFileInfo();
        public bool UploadFileServer(IFormFile allFile);
        public Task<int> UploadFileInDB(IFormFile imageFile);
    }
}

