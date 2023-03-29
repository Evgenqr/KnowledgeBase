using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class Category
    {
        /// <summary>
        /// Id категории
        /// </summary>
        public int Id { get; set; }
        [Display(Name = "Название категории")]
        [MaxLength(50)]
        public string Title { get; set; }

    }

}