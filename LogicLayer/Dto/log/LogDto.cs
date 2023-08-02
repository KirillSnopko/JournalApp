
namespace LogicLayer.Dto.log
{
    public class LogDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Service { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
    }
}
