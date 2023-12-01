using SATapp.DATA.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATapp.DATA.EF.Models/*.metadata*/
{
   public class CourseMetadata
    {
        //No changes
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is required!")]
        [StringLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [Display(Name= "Course Title")]
        public string CourseName { get; set; } = null!;
        [Required(ErrorMessage = "Course Description is required!")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; } = null!;
        [Required(ErrorMessage = "Credit Hours Are Required!")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }
        [StringLength(250, ErrorMessage = "Must not exceed 250 characters.")]
        [Display(Name = "Cirriculum")]
        public string? Curriculum { get; set; }
        [StringLength(500, ErrorMessage = "Must not exceed 500 characters.")]
        [Display(Name = "Notes")]

        public string? Notes { get; set; }
        [Required(ErrorMessage ="Must Select If Active.")]
        [Display (Name = "Active Class")]
        public bool IsActive { get; set; }
    }

   public class EnrollmentMetadata
    {
        public int EnrollmentId { get; set; }
        [Required (ErrorMessage = "Student ID is required")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required (ErrorMessage = "Class ID is required")]
        [Display(Name = "Class ID ")]
        public int ScheduledClassId { get; set; }
        [DataType(DataType.Date)]
        [Required (ErrorMessage ="Must select a enrollment date")]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public virtual ScheduledClass ScheduledClass { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }

   public class ScheduledClassMetadata
   {

        public int ScheduledClassId { get; set; }
        [Required(ErrorMessage = "Must Include a Course ID ")]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        [DataType (DataType.Date)]
        [Required(ErrorMessage ="Must select a Start Date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Must select a End Date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Must include the Instructor")]
        [StringLength(40, ErrorMessage = "Must not exceed 40 characters.")]
        [Display(Name = "Course Instructor")]
        public string InstructorName { get; set; } = null!;
        [Required(ErrorMessage = "Must include the Course Location")]
        [StringLength(20, ErrorMessage = "Must not exceed 20 characters.")]
        [Display(Name = "Course Location")]
        public string Location { get; set; } = null!;
        public int Scsid { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ScheduledClassStatus Scs { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

   public class StudentMetadata
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Must include the Student's First Name")]
        [StringLength(20, ErrorMessage = "Must not exceed 20 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Must include the Student's Last Name")]
        [StringLength(20, ErrorMessage = "Must not exceed 20 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [StringLength(15, ErrorMessage = "Must not exceed 15 characters.")]
        [Display(Name = "Major")]
        public string? Major { get; set; }
        [StringLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [Display(Name = "Address")]
        public string? Address { get; set; }
 
        [StringLength(25, ErrorMessage = "Must not exceed 25 characters.")]
        [Display(Name = "City")]
        public string? City { get; set; }
        [StringLength(2, ErrorMessage = "Use Two Letters")]
        [Display(Name = "Last Name")]
        public string? State { get; set; }
      
        [StringLength(10, ErrorMessage = "Must not exceed 10 characters.")]
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, ErrorMessage = "Must not exceed 13 characters.")]
        [Display(Name = "Phone Number ")]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
      
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters.")]
        [Display(Name = "Photo URL")]
        public string? PhotoUrl { get; set; }
        [Display(Name = "Ssid")]
        public int Ssid { get; set; }

    }

   public class StudentStatusMetadata
    {
        public int Ssid { get; set; }
        [Required(ErrorMessage = "Must include the Student's Name")]
        [StringLength(30, ErrorMessage = "Must not exceed 30 characters.")]
        [Display(Name = "Scheduled Student's Name")]
        public string Ssname { get; set; } = null!;
        
        [StringLength(30, ErrorMessage = "Must not exceed 30 characters.")]
        [Display(Name = "Schedule Description")]
        public string? Ssdescription { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

   public class ScheduledClassStatusMetadata
    {
        public int Scsid { get; set; }
        [Required(ErrorMessage = "Must include the Status")]
        [StringLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [Display(Name = "Scheduled Course Status Name")]
        public string Scsname { get; set; } = null!;

        public virtual ICollection<ScheduledClass> ScheduledClasses { get; set; }

    }

}
