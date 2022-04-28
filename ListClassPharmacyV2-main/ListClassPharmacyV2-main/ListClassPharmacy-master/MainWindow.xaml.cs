﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
       // List<Pharmacy> pharmacies = new List<Pharmacy>();
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.pharmacies.Add(new Pharmacy("Цитрамон", 100, 199.90, 36));
            int count = System.IO.File.ReadAllLines(@"Input.txt").Length;
            StreamReader sr = new StreamReader(@"Input.txt");
            for (int i = 0; i < count; i++)
            {
                string input = sr.ReadLine();
                string[] info = input.Split(';');
                string FIO = info[0];
                int number = int.Parse(info[1]);
                int math = int.Parse(info[2]);
                int english = int.Parse(info[3]);
                int OAP = int.Parse(info[4]);
                int BD = int.Parse(info[5]);
                int PE = int.Parse(info[6]);
                Student students = new Student()
                {
                    SetFIO = FIO,
                    Setnumber = number,
                    Setmath = math,
                    Setenglish = english,
                    SetOAP = OAP,
                    SetBD = BD,
                    SetPE = PE,
                };
                ConnectHelper.students.Add(students);
            }

            DtgListPreparate.ItemsSource = ConnectHelper.pharmacies;
            //pharmacies.Add(new Pharmacy("Цитрамон", 100, 199.90, 36));
            //pharmacies.Add(new Pharmacy("Парацетамол", 200, 279.90, 24));
            //pharmacies.Add(new Pharmacy("Нурофен", 255, 356.90, 24));
            //pharmacies.Add(new Pharmacy("Спазган", 99, 555.01, 36));
            //pharmacies.Add(new Pharmacy("Витамин C", 1000, 50.00, 12));
            //pharmacies.Add(new Pharmacy("Зодак", 5, 356.90, 24));
            //pharmacies.Add(new Pharmacy("Ибупрофен", 35, 555.01, 36));
            //pharmacies.Add(new Pharmacy("Пенталгин", 8, 50.00, 12));
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.students.ToList();
            DtgListPreparate.SelectedIndex = -1;
           
        }
        /// <summary>
        /// сортировка по алфавиту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.students.OrderBy(x=>x.SetFIO).ToList();
        }
        /// <summary>
        /// сортировка в обратном порядке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.students.OrderByDescending(x => x.SetFIO).ToList();
        }
        /// <summary>
        /// поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.students.Where(x => 
                x.SetFIO.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

       /// <summary>
       /// фильтр по количеству
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (CmbFiltr.SelectedIndex == 0)
            {
                DtgListPreparate.ItemsSource = ConnectHelper.students.Where(x =>
                   (x.Setenglish + x.SetBD + x.Setmath + x.SetOAP + x.SetPE) / 5 >= 4.5).ToList();
                MessageBox.Show("Список отличников",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (CmbFiltr.SelectedIndex == 1)
            {
                DtgListPreparate.ItemsSource = ConnectHelper.students.Where(x =>
                    (x.Setenglish + x.SetBD + x.Setmath + x.SetOAP + x.SetPE)/5 >= 3.5).ToList();
                MessageBox.Show("Список хорошистов",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DtgListPreparate.ItemsSource = ConnectHelper.students.Where(x =>
                    (x.Setenglish + x.SetBD + x.Setmath + x.SetOAP + x.SetPE) / 5 >= 1).ToList();
                MessageBox.Show("Список неуспевающих учеников!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }

       

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = null;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
