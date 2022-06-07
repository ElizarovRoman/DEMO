using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace sport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            lb1.Visibility = Visibility.Hidden;
            txtCAP.Visibility = Visibility.Hidden;
        }
        public DataTable SQLBase(string selectSQL)
            {
            DataTable dataTable = new DataTable("dataBase");
            string connectionString = "Server=.\\SQLEXPRESS; Trusted_Connection=Yes; Database=Trade";
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();
            SqlCommand sqlcomand= sqlconn.CreateCommand();
            sqlcomand.CommandText = selectSQL;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcomand);
            sqlAdapter.Fill(dataTable);
            return dataTable;
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(count >= 2)
            {

                btGo.IsEnabled = false;
                log.IsEnabled = false;
                pass.IsEnabled = false;
            }

            try
            {
                DataTable users = new DataTable();
                users = SQLBase("Select * FROM [User] WHERE [UserLogin] = '" + log.Text + "'AND [UserPassword] = '" + pass.Text + "'");
                if (users.Rows.Count > 0)
                {
                    SqlConnection connection = null;
                    string sql = "SELECT [UserRole] FROM [User] WHERE [UserLogin] = '" + log.Text + "' AND [UserPassword] = '" + pass.Text + "'";
                    string connectionString = "Server=.\\SQLEXPRESS; Trusted_Connection=Yes; Database=Trade";
                    connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    connection.Open();
                    string role = command.ExecuteScalar().ToString();
                    int idr = int.Parse(role);
                    connection.Close();
                    if (idr == 1)
                    {
                        MessageBox.Show("Добро пожаловать Клиент", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information); // говорим, что авторизовался
                        Form2 fr = new Form2();
                        fr.Show();
                    }
                    else
                    {
                        if (idr == 2)
                        {
                            MessageBox.Show("Добро пожаловать Администратор", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Добро пожаловать Менеджер", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information); // говорим, что авторизовался
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Не найден пользователь", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    count += 1;
                    Random rad = new Random();
                    lb1.Visibility = Visibility.Visible;
                    txtCAP.Visibility = Visibility.Visible;
                    int es = rad.Next(0, 9);
                    int es1 = rad.Next(0, 9);
                    int es2 = rad.Next(0, 9);
                    int es3 = rad.Next(0, 9);
                    lb1.Text += Convert.ToString(es);
                    lb1.Text += Convert.ToString(es1);
                    lb1.Text += Convert.ToString(es2);
                    lb1.Text += Convert.ToString(es3);
                }

                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCAP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCAP.Text == lb1.Text)
            {
                btGo.IsEnabled = true;
                MessageBox.Show("Каптча введена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                DataTable users = new DataTable();
                users = SQLBase("Select * FROM [User] WHERE [UserLogin] = '" + log.Text + "'AND [UserPassword] = '" + pass.Text + "'");
                if (users.Rows.Count > 0)
                {
                    SqlConnection connection = null;
                    string sql = "SELECT [UserRole] FROM [User] WHERE [UserLogin] = '" + log.Text + "' AND [UserPassword] = '" + pass.Text + "'";
                    string connectionString = "Server=.\\SQLEXPRESS; Trusted_Connection=Yes; Database=Trade";
                    connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    connection.Open();
                    string role = command.ExecuteScalar().ToString();
                    int idr = int.Parse(role);
                    connection.Close();
                    if (idr == 1)
                    {
                        MessageBox.Show("Добро пожаловать Клиент", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information); // говорим, что авторизовался

                    }
                    else
                    {
                        if (idr == 2)
                        {
                            MessageBox.Show("Добро пожаловать Администратор", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Добро пожаловать Менеджер", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information); // говорим, что авторизовался
                        }
                    }
                }
            }
            else
            {
                btGo.IsEnabled = false;
            }
        }
    }
}
