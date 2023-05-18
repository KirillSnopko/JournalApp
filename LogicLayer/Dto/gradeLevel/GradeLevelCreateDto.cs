
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Dto.gradeLevel
{
    public class GradeLevelCreateDto
    {
        [Required(ErrorMessage = "Поле [SubjectId] обязательно")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Поле [уровень] обязательное для ввода")]
        [Range(1, 12, ErrorMessage = "Недопустимое значение [ 1-11класс, 12 если это не школа]")]
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
