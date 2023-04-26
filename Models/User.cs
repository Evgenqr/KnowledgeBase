namespace KnowledgeBase.Models
{
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
        public string Password { get; set; }
        /// <summary>
        /// Права доступа пользователя
        /// </summary>
        public string Role { get; set; }
    }
}
