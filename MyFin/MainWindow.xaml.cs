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
using System.Data;
using System.Data.SqlClient;

namespace MyFin
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SqlConnection Connect = new SqlConnection(@"Data Source=The_chosen_one\SQLEXPRESS;Initial Catalog=MyFinance;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NSecName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RegButt_Click(object sender, RoutedEventArgs e)
        {
            if (NUserName.Text is null || NSecName.Text is null || NPass.Text is null || NName.Text is null)
            {
                MessageBox.Show("Fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Connect.State != ConnectionState.Open)
                {
                    try
                    {
                        Connect.Open();

                        string countUsernames = "select count(UserId) from Users where Username = @user";

                        using(SqlCommand tryUser = new SqlCommand(countUsernames, Connect))
                        {
                            tryUser.Parameters.AddWithValue("@user", NName.Text.Trim());
                            int count = (int)(tryUser.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show(NName.Text.Trim() + " is taken", "nope", MessageBoxButton.OK, MessageBoxImage.Stop);
                            } else
                            {
                                string insertData = "INSERT INTO Users (Name, SecondName, Username, Password)\r\nVALUES (@Name, @SName, @UName, @Pass);";

                                using (SqlCommand Inse = new SqlCommand(insertData, Connect))
                                {
                                    Inse.Parameters.AddWithValue("@Name", NName.Text.Trim());
                                    Inse.Parameters.AddWithValue("@SName", NSecName.Text.Trim());
                                    Inse.Parameters.AddWithValue("@UName", NUserName.Text.Trim());
                                    Inse.Parameters.AddWithValue("@Pass", NPass.Text.Trim());

                                    Inse.ExecuteNonQuery();

                                    MessageBox.Show("All done!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error! " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        Connect.Close();
                    }
                }
            }
        }

        private void LogUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LogUserName.Text is null || LogUserName.Text is null || LogPassword.Text is null || LogPassword.Text is null)
            {
                MessageBox.Show("Fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(Connect.State != ConnectionState.Open)
                {
                    try
                    {
                        Connect.Open();
                        string logindata = "select * from users where Username = @username and Password = @password;";

                        using (SqlCommand Log = new SqlCommand(logindata, Connect))
                        {
                            Log.Parameters.AddWithValue("@username", LogUserName.Text.Trim());
                            Log.Parameters.AddWithValue("@password", LogPassword.Text.Trim());
                            Log.ExecuteNonQuery();

                            SqlDataAdapter Adap = new SqlDataAdapter(Log);
                            DataTable table = new DataTable();
                            Adap.Fill(table);
                            if (table.Rows.Count == 1)
                            {

                                MessageBox.Show("Login successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Inncorect logins!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error! " + ex , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally 
                    {
                        Connect.Close();
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
