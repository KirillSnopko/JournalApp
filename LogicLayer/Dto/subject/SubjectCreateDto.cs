using System.ComponentModel.DataAnnotations;


namespace LogicLayer.Dto.subject
{
    public class SubjectCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Не указано название")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Поле название >=2 && <=100 символов")]
        public string Name { get; set; }
    }
}
