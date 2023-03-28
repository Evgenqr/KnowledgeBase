using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;


namespace KnowledgeBase.Models
{
    public class FileModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public long DocumentId { get; set; }
        //public IFormFile File { get; set; }
    }
}
