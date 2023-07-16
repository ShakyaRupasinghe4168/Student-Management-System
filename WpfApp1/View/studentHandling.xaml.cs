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
using WpfApp1.ViewModel;
using static WpfApp1.Student;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for studentHandling.xaml
    /// </summary>
    public partial class studentHandling : Window
    {
        public List<Student> DatabaseStudent { get; private set; }
        public studentHandling()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Create()
        {

            using (UserDataContext context = new UserDataContext())
            {
                var regNo = RegNoTextBox.Text;
                var name = NameTextBox.Text;
                var batch = BatchTextBox.Text;
                var department = DepartmentTextBox.Text;
                var subject1 = Subject1TextBox.Text;
                var subject2 = Subject2TextBox.Text;
                var subject3 = Subject3TextBox.Text;
                var gpa = GPATextBox.Text;


                if (regNo != null && name != null && batch != null && department != null
                    && subject1 != null && subject2 != null && subject3 != null && gpa != null)
                {
                    context.Students.Add(new Student()
                    {
                        RegNo = regNo,
                        Name = name,
                        Batch = batch,
                        Department = department,
                        Subject1 = subject1,
                        Subject2 = subject2,
                        Subject3 = subject3,
                        GPA = gpa
                    });
                    context.SaveChanges();
                }

            }
        }

        public void Read()
        {
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseStudent = context.Students.ToList();
                ItemList.ItemsSource = DatabaseStudent;
            }

        }

        public void Update()
        {


            using (UserDataContext context = new UserDataContext())
            {

                Student selectedStudent = ItemList.SelectedItem as Student;

                var regNo = RegNoTextBox.Text;
                var name = NameTextBox.Text;
                var batch = BatchTextBox.Text;
                var department = DepartmentTextBox.Text;
                var subject1 = Subject1TextBox.Text;
                var subject2 = Subject2TextBox.Text;
                var subject3 = Subject3TextBox.Text;
                var gpa = GPATextBox.Text;


                if (regNo != null && name != null && batch != null && department != null
                   && subject1 != null && subject2 != null && subject3 != null && gpa != null)
                {

                    Student student = context.Students.Find(selectedStudent.Id);
                    student.RegNo = regNo;
                    student.Name = name;
                    student.Batch = batch;
                    student.Department = department;
                    student.Subject1 = subject1;
                    student.Subject3 = subject3;
                    student.GPA = gpa;



                    context.SaveChanges();
                }

            }



        }

        public void Delete()
        {


            using (UserDataContext context = new UserDataContext())
            {

                Student selectedStudent = ItemList.SelectedItem as Student;

                if (selectedStudent != null)
                {
                    Student user = context.Students.Single(x => x.Id == selectedStudent.Id);

                    context.Remove(user);
                    context.SaveChanges();

                }



            }



        }



        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            
                var window = new MainWindow();
                window.Show();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ItemList.Items.Clear();

        }

        private void EnableCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void EnableCheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}