using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models
{
    public class Document
    {
        /// <summary>
        /// Id документа
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Заголовок документа
        /// </summary>
        [Display(Name = "Заголовок")]
        [MaxLength(100)]
        public string Title { get; set; }
        /// <summary>
        /// Автор документа
        /// </summary>
        //[Display(Name = "Пользователь")]
        //public User User { get; set; }
        public int CategoryId { get; set; }
        /// <summary>
        /// Категория документа
        /// </summary>
        [Display(Name = "Категория")]
        public Category Category { get; set; }
        public int? DepartmentId { get; set; }
        [Display(Name = "Отдел")]
        public Department? Department { get; set; }
        [Display(Name = "Закон")]
        public virtual ICollection<Law>? Laws { get; set; }
        [Display(Name = "Текст")]
        public string? Text { get; set; }
        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Дата обновления")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateUpdate { get; set; }
        /// <summary>
        /// Приложения (файлы)
        /// </summary>
        [Display(Name = "Приложение")]
        public List<FileModel>? Files { get; set; }
    }
}
