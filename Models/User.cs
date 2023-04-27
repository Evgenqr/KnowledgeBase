using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    /// <summary>
    /// Роли
    /// </summary>
   public enum Role
    {
        Administrator,
        Moderator,
        User
    }
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// Пароль от учетной записи пользователя
        /// </summary>
        /*[Required]*/
        //[Display(Name = "Запомнить?")]
        //public bool RememberMe { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Права доступа пользователя
        /// </summary>
        public Role Role { get; set; }
    }
}
