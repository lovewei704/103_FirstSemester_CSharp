using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.IO;

namespace Library
{
    public class CountBook
    {
        SaveAndReadFile ToSave = new SaveAndReadFile();

        public int A_level = 0, B_level = 0, C_level = 0, D_level = 0, F_level = 0, Level;
        public string show;
        public int[] grades;
        public string CourseName { get; set; }
        public int StudentNumber { get; set; }      
        public int RecordNumber { get; set; }
        public string FileName { get; set; }
        public string[] StudentIDs { get; set; }
        public string[] StudentNames { get; set; }
        public int LowCount, HighCount;

        public void GradeBook(string coursename, int studentnumber,int recordnumber)
        {
            CourseName = coursename;
            StudentNumber = studentnumber;
            RecordNumber = recordnumber;
        }

        public void GradesArray(int[] gradesArray)
        {
            grades = gradesArray;
            Switch();
        }

        public void DisplayMessage()
        {
            Console.WriteLine("\nWelcome to the grade book for \nIntroduction to {0} Program!", CourseName);
            show += "課程名稱：\t"+CourseName+"\r\n學生人數：\t"+StudentNumber+"\r\n記錄次數：\t"+RecordNumber+"\r\n\r\nWelcome to the grade book for \r\nIntroduction to " + CourseName + " Program!\r\n";
 //           Console.WriteLine("Your name is {0}\n", Name);
 //           show += "Your name is " + Name + "\r\n";
        } // end DisplayMessage

        public void ProcessGrades(string[] studentId,string[] studentName)
        {
            StudentIDs = studentId;
            StudentNames = studentName;

            OutputGrades();
            Console.WriteLine("\nClass average is {0:F}", GetAverage());
            show += "\r\nClass average is : " + GetAverage() + "\r\n";

            Console.WriteLine("Lowest grade is {0}\nHighest grade is {1}\n", GetMinimum(), GetMaximum());
            show += "\r\nLowest grade is : \r\n"+StudentIDs[LowCount]+"\t"+StudentNames[LowCount]+"\t"+ GetMinimum() + "\r\n\r\nHighest grade is : \r\n"+StudentIDs[HighCount]+"\t"+StudentNames[HighCount]+"\t"+ GetMaximum() + "\r\n\r\n";

            OutputBarChart();
        } // end ProcessGrades

        public int GetMinimum()
        {
            int lowGrade = grades[0];

            for (int count = 0; count < grades.Length; count++)
            {
                if (grades[count] < lowGrade)
                {
                    lowGrade = grades[count];
                    LowCount = count;
                }
            }
                //foreach (double grade in grades)
                //{
                //    if (grade < lowGrade)
                //        lowGrade = grade;
                //}
            return lowGrade;
        } // 最小值

        public int GetMaximum()
        {
            int highGrade = grades[0];

            for (int count = 0; count < grades.Length; count++)
            {
                if (grades[count] > highGrade)
                {
                    highGrade = grades[count];
                    HighCount = count;
                }
            }
            //foreach (double grade in grades)
            //{
            //    if (grade > highGrade)
            //        highGrade = grade;
            //}

            return highGrade;
        } // 最大值

        public int GetAverage()
        {
            int total = 0;

            foreach (int grade in grades)
                total += grade;

            return (int)total / grades.Length;
        }
        // 平均
        public void OutputBarChart()
        {
            Console.WriteLine("Grade distribution:\n");
            show += "Grade distribution:\r\n";

            int[] frequency = new int[11];

            foreach (int grade in grades)
                ++frequency[grade / 10];

            for (int count = 0; count < frequency.Length; ++count)
            {
                if (count == 10)
                {
                    Console.Write("100:");
                    show += "\r\n100 : ";
                }
                else
                {
                    Console.Write("{0:D2}-{1:D2}:", count * 10, count * 10 + 9);
                    show += "\r\n" + (count * 10) + "-" + (count * 10 + 9) + " : ";
                }

                for (int stars = 0; stars < frequency[count]; ++stars)
                {
                    Console.Write("*");
                    show += "*";
                }

                Console.WriteLine();
            } // end for
        }//end 星星~

        public void OutputGrades()
        {
            Console.WriteLine("The grades are:\n");
            show += "\r\nThe grades are:\r\n";
            show += "學號\t\t姓名\t平均成績\r\n";
            for (int student = 0; student < grades.Length; ++student)
            {
                Console.WriteLine("Student{0,2}:{1,3}", student + 1, grades[student]);
                show += StudentIDs[student]+"\t"+StudentNames[student]+"\t"+ grades[student] + "\r\n";
            }
        } // end 顯示全部學生成績

        public void SaveFile()
        {
            ToSave.Save(FileName);
        }
        public StreamWriter filewriter()
        {
            return ToSave.fileWriter;
        }
        public string Result()
        {
            return show;
        }
        public void Switch()
        {
            foreach (int grade in grades)
            {
                switch (grade / 10000)
                {
                    case 9:
                    case 8:
                        ++B_level;
                        break;
                    case 7:
                    case 6:
                        ++C_level;
                        break;
                    case 5:
                    case 4:
                        ++D_level;
                        break;
                    case 3:
                    case 2:
                    case 1:
                    case 0:
                        ++F_level;
                        break;
                    default:
                        ++A_level;
                        break;
                }
            }
        }
        public int GetA_Level()
        {
            return A_level;
        }
        public int GetB_Level()
        {
            return B_level;
        }
        public int GetC_Level()
        {
            return C_level;
        }
        public int GetD_Level()
        {
            return D_level;
        }
        public int GetF_Level()
        {
            return F_level;
        }
    }
}
