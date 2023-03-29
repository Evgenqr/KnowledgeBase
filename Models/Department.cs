using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class Department
    {
        /// <summary>
        /// Id отдела
        /// </summary>
        public int Id { get; set; }
        [Display(Name = "Название отдела")]
        [MaxLength(50)]
        public string Title { get; set; }
    }
    //public class DepartmentDBContext : DbContext
    //{
    //    public DbSet<Department> Departments { get; set; }
    //}
}
