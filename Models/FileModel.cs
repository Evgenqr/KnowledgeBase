using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;


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
        public string Title { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Id документа, к которому прикреплен данный файл
        /// </summary>
        public long DocumentId { get; set; }
    }
}
