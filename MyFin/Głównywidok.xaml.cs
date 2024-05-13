using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
using System.Xml.Linq;

namespace MyFin
{
    
    public partial class Głównywidok : Window
    {
        private int loggedUserId;
        private string loggedUserName;
        private string loggedUserSecondName;
        private string Connectsql;
        public Głównywidok(int userId, string uName, string SecondName, string Connect)
        {
            
            InitializeComponent();

            loggedUserId = userId;
            loggedUserName = uName;
            loggedUserSecondName = SecondName;
            Connectsql = Connect;

            UserIdTextBox.Text = "Witaj: " + loggedUserName.ToString() + "!";
            CalculateExpensesSum();
            ShowExpensesList();
        }
        //Suma całkowita wydatków
        private void CalculateExpensesSum()
        {
            decimal expensesSum = 0;

            try
            {
                using (SqlConnection Connect = new SqlConnection(Connectsql))
                {
                    Connect.Open();

                    string query = "SELECT SUM(Wartość) FROM Wydatki WHERE UserID = @userId;";
                    using (SqlCommand command = new SqlCommand(query, Connect))
                    {
                        command.Parameters.AddWithValue("@userId", loggedUserId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            expensesSum = Convert.ToDecimal(result);
                        }
                    }
                }
                ExpensesSumTextBox.Text = "Suma twoich wydatków: " + expensesSum.ToString("C"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Lista wydatków
        private void ShowExpensesList()
        {
            try
            {
                using (SqlConnection Connect = new SqlConnection(Connectsql))
                {
                    Connect.Open();

                    string query = "SELECT IDWydatku as ID, Wartość, DataWydatku, Komentarz FROM Wydatki WHERE UserID = @userId;";
                    using (SqlCommand command = new SqlCommand(query, Connect))
                    {
                        command.Parameters.AddWithValue("@userId", loggedUserId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        TDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Otwieranie okn
        private void DodajWydatekButton_Click(object sender, RoutedEventArgs e)
        {
            DodajWydatekWindow dod = new DodajWydatekWindow();
            dod.Owner = this;
            dod.ShowDialog();
            ShowExpensesList();
        }
        public void AddExpense(float wartość,string komentarz)
        {
            try
            {
                using (SqlConnection Connect = new SqlConnection(Connectsql))
                {
                    Connect.Open();

                    string query = "INSERT INTO Wydatki  VALUES (@userId, @wart,getdate() ,@komentarz);";
                    using (SqlCommand command = new SqlCommand(query, Connect))
                    {
                        command.Parameters.AddWithValue("@userId", loggedUserId);
                        command.Parameters.AddWithValue("@wart", wartość);
                        command.Parameters.AddWithValue("@komentarz", komentarz);
                        command.ExecuteNonQuery();
                    }
                }
                CalculateExpensesSum();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void WylogujButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Log = new MainWindow();
            Log.Show();
            this.Hide();

        }

        private void Mini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
