using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models
{
    public class Document
    {
        public long Id { get; set; }
        [Display(Name = "Заголовок")]
        [MaxLength(100)]
        public string Title { get; set; }
        //[Display(Name = "Пользователь")]
        //public User User { get; set; }
        public int CategoryId { get; set; }
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
        public DateTime DateCreate { get; set; }
        [Display(Name = "Дата обновления")]
        [DataType(DataType.Date)]
        public DateTime? DateUpdate { get; set; }
        //public int? FileId { get; set; }
        //[NotMapped]
        [Display(Name = "Приложение")]
        public List<FileModel>? Files { get; set; }
        //public virtual FileModel? File { get; set; }
    }
}
