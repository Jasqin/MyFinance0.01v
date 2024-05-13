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

namespace MyFin
{
    
    public partial class DodajWydatekWindow : Window
    {
        public DodajWydatekWindow()
        {
            InitializeComponent();
        }
        //Okienko dodawania nowego wydatku
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(AmountTextBox.Text))
            {
                MessageBox.Show("Please enter the expense amount!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            float Wartosc;
            if (!float.TryParse(AmountTextBox.Text, out Wartosc))
            {
                MessageBox.Show("Please enter a valid numeric value for the amount!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Wartosc <= 0)
            {
                MessageBox.Show("Please enter a value greater than 0 for the amount!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string Komentarz = ExpenseCommentTextBox.Text;

            (Owner as Głównywidok)?.AddExpense(Wartosc, Komentarz);
            this.Close();
        }

        private void AmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AmountTextBox.Text == "Wartość")
            {
                AmountTextBox.Text = "";
            }
        }

        private void ExpenseCommentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ExpenseCommentTextBox.Text == "Komentarz")
            {
                ExpenseCommentTextBox.Text = "";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
