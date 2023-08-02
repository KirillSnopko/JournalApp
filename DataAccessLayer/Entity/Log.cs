
namespace DataAccessLayer.Entity
{
    public class Log : EntityBase
    {
        /// <summary>
        /// Хранит информацию исключения/события
        /// </summary>
        /// <param name="Id">Ключ</param>
        /// <param name="DateTime">Дата</param>
        /// <param name="Service">название сервиса/класса</param>
        /// <param name="Message">Текст исключения</param>

        public DateTime DateTime { get; set; }
        public string Service { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }

        public Log() { }

        public Log(string service, string exception, string message)
        {
            DateTime = DateTime.Now;
            Message = message;
            Service = service;
            Exception = exception;
        }
    }
}
