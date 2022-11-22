using System;
namespace NordicDoor.Models
{

    /*
   create TABLE FileModel
   (
       Id INT NOT NULL AUTO_INCREMENT,
       FileName VARCHAR(40),
       Content LONGBLOB,
       PRIMARY KEY (Id)
   );      
   */

    public class FileModel
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[]? Content { get; set; }    
    }
}

