﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Course : EntityBase
    {
        [ForeignKey(nameof(StudentProfile))]
        public int StudentProfileId { get; set; }
        public virtual StudentProfile StudentProfile { get; set; }
        public Type Type { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dddd, dd MMMM yyyy}")]
        public DateTime DateOfStart { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual GradeLevel GradeLevel { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }

    public enum Type
    {
        Online, Offline
    }
}
