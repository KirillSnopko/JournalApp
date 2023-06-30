using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Lesson : EntityBase
    {
        /// <summary>
        /// Занятие
        /// </summary>
        ///  <param name="CourseId">id курса</param>
        ///   <param name="Course">курс</param>
        ///    <param name="Topics">список тем</param>
        ///     <param name="Task">задание</param>
        ///      <param name="Description">дополнительное описание если нужно</param>
        ///       <param name="Date">дата занятия</param>
        ///       <param name="IsPaid">Оплачено</param>
        ///        <param name="Price">стоимость по факту</param>
        ///         <param name="DateOfPayment"> дата платежа</param>
        ///          <param name="IsPrepared">готовность занятия</param>
        ///           <param name="IsTaskGiven">отправка задания</param>
        ///            <param name="IsCompleted">проведение занятия</param>
        ///             <param name="IsCanceled">отмена занятия</param>
        ///              <param name="GradeHome">оценка домашки</param>
        ///               <param name="GradeLesson">оценка на занятии</param>
        ///                <param name="LessonDuration">фактическая продолжительность занятия</param>

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<Topic> Topics { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsPaid { set; get; } = false;
        public double Price { get; set; } = 0;
        public DateTime DateOfPayment { get; set; }
        public int LessonDuration { get; set; } = 0;



        public bool IsPrepared { get; set; } = false;
        public bool IsTaskGiven { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public bool IsCanceled { get; set; } = false;


        public int GradeHome { get; set; } = 0;
        public int GradeLesson { get; set; } = 0;
    }
}
