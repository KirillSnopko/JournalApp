
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Dto.gradeLevel
{
    public class GradeLevelCreateDto
    {
        [Required(ErrorMessage = "Поле [SubjectId] обязательно")]
        public int SubjectId { get; set; }
        public string Description { get; set; } = "<no name>";
    }
}
