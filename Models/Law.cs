using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class Law
    {
        /// <summary>
        /// Id закона
        /// </summary>
        public int Id { get; set; }
        [Display(Name = "Название закона")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Display(Name = "Сокращенное название закона")]
        [MaxLength(50)]
        public string shorttitle { get; set; }
        /// <summary>
        /// Документы, которые связаны с законом
        /// </summary>
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
