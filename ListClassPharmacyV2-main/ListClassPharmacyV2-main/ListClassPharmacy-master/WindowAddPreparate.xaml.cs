using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPreparate.xaml
    /// </summary>
    public partial class WindowAddPreparate : Window
    {
        public WindowAddPreparate()
        {
            InitializeComponent();
        }

        private void BtnAddPreparate_Click(object sender, RoutedEventArgs e)
        {
            Student students = new Student()
            {
                SetFIO = FIONAME.Text,
                Setnumber = int.Parse(numbername.Text),
                Setmath = int.Parse(mathname.Text),
                Setenglish = int.Parse(engname.Text),
                SetOAP = int.Parse(oapname.Text),
                SetBD = int.Parse(bdname.Text),
                SetPE = int.Parse(pename.Text),
            };
            ConnectHelper.students.Add(students);
            StreamWriter sr = new StreamWriter(@"Input.txt", true);
            sr.WriteLine($"{students.SetFIO};{students.Setnumber};{students.Setmath};{students.Setenglish};{students.SetOAP};{students.SetBD};{students.SetPE};");
            sr.Close();
            this.Close();
        }
    }
}
