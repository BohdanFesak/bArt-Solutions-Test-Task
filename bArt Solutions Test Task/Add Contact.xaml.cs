using ClassLibrary;
using Reprository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bArt_Solutions_Test_Task
{
    /// <summary>
    /// Interaction logic for Add_Contact.xaml
    /// </summary>
    public partial class Add_Contact : Window
    {
        GenericUnitOfWork Work;
        public Add_Contact(GenericUnitOfWork Work)
        {
            this.Work = Work;
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContactFirstName.Text != "" && ContactLastName.Text != "" && ContactEmail.Text != "" && AccountId.Text != "" && AccountId.Text != "Account Id")
            {
                var foo = new EmailAddressAttribute();
                if (!foo.IsValid(ContactEmail.Text))
                {
                    MessageBox.Show("Incorrect email");
                    return;
                }
                IGenericRepository<Account> repositoryAccount = Work.Repository<Account>();
                List<int> ids = new List<int>();
                foreach (Account account in repositoryAccount.GetAll())
                {
                    ids.Add(account.Id);
                }
                if (!ids.Contains(Int32.Parse(AccountId.Text)))
                {
                    MessageBox.Show("Account with this id does not exist");
                    return;
                }
                IGenericRepository<Contact> repositoryContact = Work.Repository<Contact>();
                repositoryContact.Add(new Contact
                {
                    FirstName = ContactFirstName.Text,
                    LastName = ContactLastName.Text,
                    Email = ContactEmail.Text,
                    GetAccount = repositoryAccount.FindById(Int32.Parse(AccountId.Text))
                });
                this.Close();
            }
            else
                MessageBox.Show("Empty field");
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
                ContactLastName.Text = "Contact First Name";
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

        private void AccountId_GotFocus(object sender, RoutedEventArgs e)
        {
            AccountId.Foreground = SystemColors.WindowTextBrush;
            AccountId.Text = "";
        }

        private void AccountId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ContactEmail.Text == "")
            {
                ContactEmail.Foreground = SystemColors.GrayTextBrush;
                ContactEmail.Text = "Account Id";
            }
        }
    }
}
