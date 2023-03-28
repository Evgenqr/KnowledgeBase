using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class Law
    {
        public int Id { get; set; }
        [Display(Name = "Название закона")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Display(Name = "Сокращенное название закона")]
        [MaxLength(50)]
        public string shorttitle { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
