using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class FileModel
    {
        /// <summary>
        /// Id файла
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название файла
        /// </summary>
        [Display(Name = "Название файла")]
        public string Title { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        [Display(Name = "Расширение")]
        public string Extension { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Display(Name = "Путь")]
        public string Path { get; set; }
        /// <summary>
        /// Id документа, к которому прикреплен данный файл
        /// </summary>
        [Display(Name = "Id документа")]
        public long DocumentId { get; set; }
    }
}
