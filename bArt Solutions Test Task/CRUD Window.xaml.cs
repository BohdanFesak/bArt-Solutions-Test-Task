using ClassLibrary;
using Reprository;
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

namespace bArt_Solutions_Test_Task
{
    /// <summary>
    /// Interaction logic for CRUDWindow.xaml
    /// </summary>
    public partial class CRUDWindow : Window
    {
        GenericUnitOfWork work = new GenericUnitOfWork(new Account_Context("conStr"));
        public CRUDWindow()
        {
            InitializeComponent();
            ReadContacts();
            ReadAccount();
            ReadIncindent();
        }
        public void ReadContacts()
        {
            IGenericRepository<Contact> repositoryContact = work.Repository<Contact>();
            ContactListBox.Items.Clear();
            foreach (Contact contact in repositoryContact.GetAll())
            {
                ContactListBox.Items.Add($"Id: {contact.Id}; First Name: {contact.FirstName}; Last Name: {contact.LastName}; Email: {contact.Email}");
            }
        }
        protected void ReadAccount()
        {
            IGenericRepository<Account> repositoryAccount = work.Repository<Account>();
            AcountListBox.Items.Clear();
            foreach (Account account in repositoryAccount.GetAll())
            {
                AcountListBox.Items.Add($"Id: {account.Id}; Acount Name: {account.Name}");
            }
        }
        protected void ReadIncindent()
        {
            IGenericRepository<Incident> repositoryIncident = work.Repository<Incident>();
            IncendentListBox.Items.Clear();
            foreach (Incident incident in repositoryIncident.GetAll())
            {
                IncendentListBox.Items.Add($"Id: {incident.Id}; Incindent Description {incident.Description}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContactListBox.SelectedItem != null)
            {
                string st = ContactListBox.SelectedItem.ToString().Substring(3, ContactListBox.SelectedItem.ToString().IndexOf(';') - 3);
                ContactListBox.SelectedItem = null;
                IGenericRepository<Contact> repositoryContact = work.Repository<Contact>();
                repositoryContact.Remove(repositoryContact.GetAll().Where(x => x.Id == Int32.Parse(st)).FirstOrDefault());
                ReadContacts();
            }
            else
                MessageBox.Show("Please select Contact");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AcountListBox.SelectedItem != null)
            {
                string st = AcountListBox.SelectedItem.ToString().Substring(3, AcountListBox.SelectedItem.ToString().IndexOf(';') - 3);
                IGenericRepository<Account> repositoryAccount = work.Repository<Account>();
                AcountListBox.SelectedItem = null;
                repositoryAccount.Remove(repositoryAccount.GetAll().Where(x => x.Id == Int32.Parse(st)).FirstOrDefault());
                ReadAccount();
            }
            else
                MessageBox.Show("Please select account");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (IncendentListBox.SelectedItem != null)
            {
                string st = IncendentListBox.SelectedItem.ToString().Substring(3, IncendentListBox.SelectedItem.ToString().IndexOf(';') - 3);
                IncendentListBox.SelectedItem = null;
                IGenericRepository<Incident> repositoryIncident = work.Repository<Incident>();
                repositoryIncident.Remove(repositoryIncident.GetAll().Where(x => x.Id == Int32.Parse(st)).FirstOrDefault());
                ReadIncindent();
            }
            else
                MessageBox.Show("Please select incendent");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ContactListBox.SelectedItem != null) 
            {
                string st = ContactListBox.SelectedItem.ToString().Substring(3, ContactListBox.SelectedItem.ToString().IndexOf(';') - 3);
                ContactListBox.SelectedItem = null;
                new Update_Contact_Window(work, Int32.Parse(st)).Show();
            }
            else
                MessageBox.Show("Please select Contact");
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (AcountListBox.SelectedItem != null)
            {
                string st = AcountListBox.SelectedItem.ToString().Substring(3, AcountListBox.SelectedItem.ToString().IndexOf(';') - 3);
                AcountListBox.SelectedItem = null;
                new Update_Acount_Window(work, Int32.Parse(st)).Show();
            }
            else
                MessageBox.Show("Please select account");
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (IncendentListBox.SelectedItem != null)
            {
                string st = IncendentListBox.SelectedItem.ToString().Substring(3, IncendentListBox.SelectedItem.ToString().IndexOf(';') - 3);
                IncendentListBox.SelectedItem = null;
                new Incindent_Update_Window(work, Int32.Parse(st)).Show();
            }
            else
                MessageBox.Show("Please select incendent");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            new Add_Contact(work).Show();
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            new Add_Account_Window(work).Show();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            new Add_Incindent_Window(work).Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ReadContacts();
            ReadAccount();
            ReadIncindent();
        }
    }
}
