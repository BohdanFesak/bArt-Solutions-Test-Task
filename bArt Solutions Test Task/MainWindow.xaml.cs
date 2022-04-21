using ClassLibrary;
using Newtonsoft.Json;
using Reprository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


namespace bArt_Solutions_Test_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // заглушка щоб було можна праюцвати з json якщо запит з даними приходив би від користувача у цьому формаматі
            var foo = new EmailAddressAttribute();
            if (!foo.IsValid(ContactEmail.Text)) 
            {
                MessageBox.Show("Incorrect email");
                return;
            }
            RequestClass requestClass = new RequestClass(AccountName.Text, ContactFirstName.Text, ContactLastName.Text, ContactEmail.Text, IncendentDesc.Text) ;
            RequestProcessing requestProcessing = new RequestProcessing(JsonConvert.SerializeObject(requestClass));
            requestProcessing.Request();
        }

        private void TextBox_GotFocusAccountName(object sender, RoutedEventArgs e)
        {
            AccountName.Foreground = SystemColors.WindowTextBrush;
            AccountName.Text = "";
        }

        private void AcountName_LostFocusAccountName(object sender, RoutedEventArgs e)
        {
            if (AccountName.Text == "")
            {
                AccountName.Foreground = SystemColors.GrayTextBrush;
                AccountName.Text = "Account Name";
            }
        }

        private void TextBox_GotFocusContactFirstName(object sender, RoutedEventArgs e)
        {
            ContactFirstName.Foreground = SystemColors.WindowTextBrush;
            ContactFirstName.Text = "";
        }

        private void TextBox_LostFocusContactFirstName(object sender, RoutedEventArgs e)
        {
            if (ContactFirstName.Text == "")
            {
                ContactFirstName.Foreground = SystemColors.GrayTextBrush;
                ContactFirstName.Text = "Contact First Name";
            }
        }

        private void ContactLastName_GotFocusContactLastName(object sender, RoutedEventArgs e)
        {
            ContactLastName.Foreground = SystemColors.WindowTextBrush;
            ContactLastName.Text = "";
        }

        private void ContactLastName_LostFocusContactLastName(object sender, RoutedEventArgs e)
        {
            if (ContactLastName.Text == "")
            {
                ContactLastName.Foreground = SystemColors.GrayTextBrush;
                ContactLastName.Text = "Contact Last Name";
            }
        }

        private void ContactEmail_GotFocusContactEmail(object sender, RoutedEventArgs e)
        {
            ContactEmail.Foreground = SystemColors.WindowTextBrush;
            ContactEmail.Text = "";
        }

        private void ContactEmail_LostFocusContactEmail(object sender, RoutedEventArgs e)
        {
            if (ContactEmail.Text == "")
            {
                ContactEmail.Foreground = SystemColors.GrayTextBrush;
                ContactEmail.Text = "Contact Email";
            }
        }

        private void IncendentDesc_GotFocusIncendentDesc(object sender, RoutedEventArgs e)
        {
            IncendentDesc.Foreground = SystemColors.WindowTextBrush;
            IncendentDesc.Text = "";
        }

        private void IncendentDesc_LostFocusIncendentDesc(object sender, RoutedEventArgs e)
        {
            if (IncendentDesc.Text == "")
            {
                IncendentDesc.Foreground = SystemColors.GrayTextBrush;
                IncendentDesc.Text = "Incendent Description";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // альтернативна версія яка приймає класс а не json строку
            var foo = new EmailAddressAttribute();
            if (!foo.IsValid(ContactEmail.Text))
            {
                MessageBox.Show("Incorrect email");
                return;
            }
            RequestProcessing requestProcessing = new RequestProcessing(new RequestClass(AccountName.Text, ContactFirstName.Text, ContactLastName.Text, ContactEmail.Text, IncendentDesc.Text));
            requestProcessing.Request();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // я подумав що було б ще непогано зробити CRUD операції для управління базою даних з додатку
            new CRUDWindow().Show();
        }
    }
}
