using System;
using ULaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor.Models
{
    public class Application
    {
        public Application(DegreeGradeEnum degreeGrade, DegreeSubjectEnum degreeSubject, 
            string faculty, string courseCode, DateTime startdate, 
            string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa) //wrapping parameter lists can make viewing on smaller screens easier.
        {

            //Sometimes it's nice to make variable assignment even nicer to read!
            ApplicationId = new Guid();

            DegreeGrade     = degreeGrade;
            DegreeSubject   = degreeSubject;
            
            Faculty     = faculty;
            CourseCode  = courseCode;
            StartDate   = startdate;
            
            Title           = title;
            FirstName       = firstName;
            LastName        = lastName;
            DateOfBirth     = dateOfBirth;
            RequiresVisa    = RequiresVisa;
        }

        public Guid ApplicationId { get; private set; }
        public string Faculty { get; private set; }
        public string CourseCode { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool RequiresVisa { get; private set; }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }
    }
}
