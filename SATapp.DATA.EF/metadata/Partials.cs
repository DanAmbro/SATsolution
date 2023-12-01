using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SATapp.DATA.EF.Models/*.metadata*/
{
    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course { }
    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }
    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        public string CourseInfo => $"Start: {StartDate} | Location: {Location}";
    }
    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string FullName => $"{FirstName} {LastName}";
    }
    [ModelMetadataType(typeof(StudentStatusMetadata))]

    public partial class StudentStatus { }
    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClassStatus { }
}
