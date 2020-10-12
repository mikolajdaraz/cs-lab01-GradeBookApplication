using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires more students (at least 5)");
            }
            var letterDrop = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (grades[letterDrop - 1] <= averageGrade)
                return 'A';
            else if (grades[(letterDrop * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(letterDrop * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(letterDrop * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
                
        }
        public override void CalculateStatistics()
        {
            
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else if (Students.Count >= 5)
            {
              base.CalculateStatistics();
            }

        }
        

    }
}
