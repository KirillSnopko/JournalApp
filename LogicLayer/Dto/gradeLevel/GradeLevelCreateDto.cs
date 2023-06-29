
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Dto.gradeLevel
{
    public class GradeLevelCreateDto
    {
        [Required(ErrorMessage = "Поле [SubjectId] обязательно")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Поле [уровень] обязательное для ввода")]
        [DisplayName("Уровень")]
        public int Level { get; set; } = -1;
        public string Description { get; set; } = "<no name>";
    }
}
