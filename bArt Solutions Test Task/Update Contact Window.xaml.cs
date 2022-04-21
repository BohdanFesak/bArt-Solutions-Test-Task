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
    /// Interaction logic for Update_Contact_Window.xaml
    /// </summary>
    public partial class Update_Contact_Window : Window
    {
        GenericUnitOfWork Work;
        int Id;
        public Update_Contact_Window(GenericUnitOfWork Work, int Id)
        {
            this.Id = Id;
            this.Work = Work;
            InitializeComponent();
            IGenericRepository<Contact> repositoryContact = Work.Repository<Contact>();
            ContactFirstName.Text = repositoryContact.FindById(Id).FirstName;
            ContactLastName.Text = repositoryContact.FindById(Id).LastName;
            ContactEmail.Text = repositoryContact.FindById(Id).Email;
            AccountId.Text = repositoryContact.FindById(Id).GetAccount.Id.ToString();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var foo = new EmailAddressAttribute();
            if (!foo.IsValid(ContactEmail.Text))
            {
                MessageBox.Show("Incorrect email");
                return;
            }
            IGenericRepository<Account> repositoryAccount = Work.Repository<Account>();
            List<int> ids = new List<int>();
            foreach(Account account in repositoryAccount.GetAll())
            {
                ids.Add(account.Id);
            }
            if(!ids.Contains(Int32.Parse(AccountId.Text)))
            {
                MessageBox.Show("Account with this id does not exist");
                return;
            }
            if (ContactFirstName.Text != "" && ContactLastName.Text != "" && ContactEmail.Text != "" && AccountId.Text != "")
            {
                IGenericRepository<Contact> repositoryContact = Work.Repository<Contact>();
                repositoryContact.FindById(Id).FirstName = ContactFirstName.Text;
                repositoryContact.FindById(Id).LastName = ContactLastName.Text;
                repositoryContact.FindById(Id).Email = ContactEmail.Text;
                repositoryContact.FindById(Id).GetAccount = repositoryAccount.FindById(Int32.Parse(AccountId.Text));
                repositoryContact.Update(repositoryContact.FindById(Id));
                this.Close();
            }
            else
                MessageBox.Show("One of the field is empty");
        }
    }
}
