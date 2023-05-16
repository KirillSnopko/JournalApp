using System.Diagnostics.CodeAnalysis;


namespace LogicLayer.Dto
{
    public class SubjectCreateDto
    {
        [NotNull]
        public string Name { get; set; }
    }
}
