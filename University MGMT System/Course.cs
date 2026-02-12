using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
    public class Course
    {
        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public int Credits { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<string> Prerequisites { get; private set; }

        private int CurrentEnrollment;

        public Course(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            CourseCode = code;
            CourseName = name;
            Credits = credits;
            MaxCapacity = maxCapacity;
            Prerequisites = prerequisites ?? new List<string>();
            CurrentEnrollment = 0;
        }

        public bool IsFull()
        {
            return CurrentEnrollment >= MaxCapacity;
        }

        public bool HasPrerequisites(List<string> completedCourses)
        {
            return Prerequisites.All(p => completedCourses.Contains(p));
        }

        public void EnrollStudent()
        {
            if (IsFull())
                throw new InvalidOperationException("Course is full.");

            CurrentEnrollment++;
        }

        public void DropStudent()
        {
            if (CurrentEnrollment > 0)
                CurrentEnrollment--;
        }

        public string GetEnrollmentInfo()
        {
            return $"{CurrentEnrollment}/{MaxCapacity}";
        }
    }
}