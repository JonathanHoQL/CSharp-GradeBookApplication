using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var studentsPerGrade = (int)Math.Ceiling(0.2 * Students.Count);
            var averageGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (averageGrade <= averageGrades[studentsPerGrade - 1])
                return 'A';
            if (averageGrade <= averageGrades[studentsPerGrade * 2 - 1])
                return 'B';
            if (averageGrade <= averageGrades[studentsPerGrade * 3 - 1])
                return 'C';
            if (averageGrade <= averageGrades[studentsPerGrade * 4 - 1])
                return 'D';


            return 'F';
        }
    }
}
