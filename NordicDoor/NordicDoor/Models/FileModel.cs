using System;
namespace NordicDoor.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string? FileName { get; set; }

        public Object? Content { get; set; }
    }
}

