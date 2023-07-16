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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using static WpfApp1.User;


namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for adminHandling.xaml
    /// </summary>
    public partial class adminHandling : Window
    {
        public List<User> DatabaseUser{ get; private set; }
        public adminHandling()
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
                var userName = UserNameTextBox.Text;
                var password = PasswordTextBox.Text;


                if (regNo != null && userName != null && password != null)
                {
                    context.Users.Add(new User()
                    {
                        RegNo = regNo,
                        UserName = userName,
                        Password = password,

                    });
                    context.SaveChanges();
                }

            }
        }

        public void Read()
        {
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseUser = context.Users.ToList();
                ItemList.ItemsSource = DatabaseUser;
            }

        }

        public void Update()
        {


            using (UserDataContext context = new UserDataContext())
            {

                User selectedUser = ItemList.SelectedItem as User;


                var regNo = RegNoTextBox.Text;
                var userName = UserNameTextBox.Text;
                var password = PasswordTextBox.Text;

                if (regNo != null && userName != null && password != null)
                {

                    User user = context.Users.Find(selectedUser.ID);
                    user.RegNo = regNo;
                    user.UserName = userName;
                    user.Password = password;




                    context.SaveChanges();
                }

            }



        }

        public void Delete()
        {


            using (UserDataContext context = new UserDataContext())
            {

                User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser != null)
                {
                    User user = context.Users.Single(x => x.ID == selectedUser.ID);

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
   