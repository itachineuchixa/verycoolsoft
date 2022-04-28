using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListClass.Classes
{
    class Student
    {
        string FIO;
        int number;
        int math;
        int english;
        int OAP;
        int BD;
        int PE;
        public string SetFIO
        {
            get { return FIO; }
            set { FIO = value; }
        }
        public int Setnumber
        {
            get { return number; }
            set { number = value; }
        }
        public int Setmath
        {
            get { return math; }
            set { math = value; }
        }
        public int Setenglish
        {
            get { return english; }
            set { english = value; }
        }
        public int SetOAP
        {
            get { return OAP; }
            set { OAP = value; }
        }
        public int SetBD
        {
            get { return BD; }
            set { BD = value; }
        }
        public int SetPE
        {
            get { return PE; }
            set { PE = value; }
        }
        public Student()
        {
            FIO = "Ivaniv I.I";
            number = 4;
            math = 4;
            english = 5;
            OAP = 3;
            BD = 5;
            PE = 5;
        }
        public Student(string f, int num, int m, int eng, int oap, int bd, int pe)
        {
            FIO = f;
            number = num;
            math = m;
            OAP = oap;
            BD = bd;
            PE = pe;
        }
        public void InputFromFile(StreamReader sr)
        {
            string input = sr.ReadLine();
            string[] info = input.Split(';');
            FIO = info[0];
            number = int.Parse(info[1]);
            math = int.Parse(info[2]);
            english = int.Parse(info[3]);
            OAP = int.Parse(info[4]);
            BD = int.Parse(info[5]);
            PE = int.Parse(info[6]);

        }
        public string Output()
        {
            return $"Студент {FIO}; " +
                $"группа номер {number}; " +
                $"Оценка по математике {math}; " +
                $"Оценка по английскому {english}; " +
                $"Оценка по ОАП {OAP}; " +
                $"Оценка по базам данных {BD}; " +
                $"Оценка по физкультуре {PE}; ";
        }
        public void Save()
        {
            StreamWriter sr = new StreamWriter(@"Result.txt", true);
            sr.WriteLine($"{FIO};{number};{math};{english};{OAP};{BD};{PE}");
            sr.Close();
        }
        public int Average()
        {
            return (math + english + OAP + BD + PE) / 5;
        }
    }
}
