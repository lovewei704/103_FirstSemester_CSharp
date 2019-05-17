using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sell_ArrayAndFile_FormApp
{
    public class SaleRecord
    {
        public string Company { get; set; }
        public string EmployeeNumber { get; set; }
        public string ProductNumber { get; set; }
        public string Target{ get; set; }
        public string Pass { get; set; }
        public string Fail { get; set; }
        public string Average { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
        public string OverAve { get; set; }
        public string UnderAve { get; set; }
        public string show;

        public string[] EmployeeIDs;
        public string[] FirstNames;
        public string[] LastNames;
        public int[] SaleArray;

        public SaleRecord()
        {

        }
        public SaleRecord(string company,string employeenumber,string productnumber)
        {
            Company = company;
            EmployeeNumber = employeenumber;
            ProductNumber = productnumber;

            EmployeeIDs = new string[int.Parse(EmployeeNumber)];
            LastNames = new string[int.Parse(EmployeeNumber)];
            FirstNames = new string[int.Parse(EmployeeNumber)];
            SaleArray = new int[int.Parse(EmployeeNumber)];
        }
        public SaleRecord(string target,string pass,string fail,string average,string max,string min,string overAve,string underAve)
        {
            Target = target;
            Pass = pass;
            Fail = fail;
            Average = average;
            Min = min;
            Max = max;
            OverAve = overAve;
            UnderAve = underAve;
        }

        public void Display()
        {
            show += "公司名稱：" + Company;
            show += "\r\n員工人數：" + EmployeeNumber;
            show += "\r\n產品總類：" + ProductNumber;
            show += "\r\n銷售目標：" + Target;
            show += "\r\n達到銷售目標人數：" + Pass;
            show += "\r\n未達到銷售目標人數：" + Fail;
            show += "\r\n平均銷售業績：" + Average;
            show += "\r\n最高銷售業績：" + Max;
            show += "\r\n最低銷售業績：" + Min;
            show += "\r\n高於平均人數：" + OverAve;
            show += "\r\n低於平均人數：" + UnderAve;
        }

        public void SetArray(string[] employeeids,string[] firstnames,string[] lastnames,int[] salearray)
        {
            EmployeeIDs = employeeids;
            FirstNames = firstnames;
            LastNames = lastnames;
            SaleArray = salearray;
        }
        public void OutputSales()
        {

            show += "\r\n輸入結果：\r\n";
            show += "學號\t\t姓名\t平均成績\r\n";
            for (int count = 0; count < SaleArray.Length; ++count)
            {
                show += EmployeeIDs[count] + "\t" + FirstNames[count] + "\t" + LastNames[count] +"\t"+SaleArray[count]+ "\r\n\r\n\r\n";
            }
        }
    }
}
