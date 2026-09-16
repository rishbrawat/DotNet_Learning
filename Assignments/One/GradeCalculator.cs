using System;

class GradeCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter student marks (0 to 100):");
        int marks = Convert.ToInt32(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("invalid marks, must be between 0 and 100");
        }
        else
        {
            char grade;
            if (marks >= 90)
            {
                grade = 'A';
            }
            else if (marks >= 75)
            {
                grade = 'B';
            }
            else if (marks >= 60)
            {
                grade = 'C';
            }
            else
            {
                grade = 'D';
            }

            Console.WriteLine($"student grade is: {grade}");
        }
    }
}