using System.ComponentModel.DataAnnotations;


namespace LogicLayer.Dto.topic
{
    public class TopicCreateDto
    {
        [Required(ErrorMessage = "Поле [GradeLevelId] обязательно")]
        public int GradeLevelId { get; set; }
        [Required(ErrorMessage = "Поле [Название] обязательное для ввода")]
        public string Title { get; set; }
        public string Description { get; set; } = "<пусто>";
    }
}
