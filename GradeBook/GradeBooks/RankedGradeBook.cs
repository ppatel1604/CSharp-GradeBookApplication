﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        protected override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var threshold = (int) Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            return grades[threshold - 1] <= averageGrade ? 'A' :
                grades[(threshold * 2) - 1] <= averageGrade ? 'B' : 
                grades[(threshold * 3) - 1] <= averageGrade ? 'C' : 
                grades[(threshold * 4) - 1] <= averageGrade ? 'D' : 
                base.GetLetterGrade(averageGrade);
        }
    }
}
