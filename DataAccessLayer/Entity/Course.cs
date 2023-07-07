using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{

    public class Course : EntityBase
    {
        /// <summary>
        /// Занятие
        /// </summary>
        ///  <param name="StudentProfileId">id профиля/студента</param>
        ///   <param name="StudentProfile">профиль</param>
        ///    <param name="Type">типа занятия</param>
        ///     <param name="DateOfStart">начало курса</param>
        ///      <param name="DateOfFinish">окончание курса</param>
        ///       <param name="Price">договорная цена</param>
        ///        <param name="LessonDuration">договоная продолжительность занятия</param>
        ///         <param name="Description">описание/дополнения</param>
        ///          <param name="GradeLevel">программа</param>
        ///           <param name="Lessons">список занятия</param>


        [ForeignKey(nameof(StudentProfile))]
        public int StudentProfileId { get; set; }
        public virtual StudentProfile StudentProfile { get; set; }
        public Type Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        //договорная цена
        public double Price { get; set; }
        public int LessonDuration { get; set; } = 0;
        public string Description { get; set; } = String.Empty;

        public virtual GradeLevel GradeLevel { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }

    public enum Type
    {
        Online, Offline
    }
}
