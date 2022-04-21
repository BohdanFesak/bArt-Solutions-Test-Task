using ClassLibrary;
using Reprository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Add_Account_Window.xaml
    /// </summary>
    public partial class Add_Account_Window : Window
    {
        GenericUnitOfWork Work;
        public Add_Account_Window(GenericUnitOfWork Work)
        {
            this.Work = Work;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AccountName.Text != "" && IncindentId.Text != "" && IncindentId.Text != "Incendent Id")
            {
                IGenericRepository<Account> repositoryAccount = Work.Repository<Account>();
                IGenericRepository<Incident> repositoryIncident = Work.Repository<Incident>();
                List<int> ids = new List<int>();
                foreach (Incident incident in repositoryIncident.GetAll())
                {
                    ids.Add(incident.Id);
                }
                if (!ids.Contains(Int32.Parse(IncindentId.Text)))
                {
                    MessageBox.Show("Incendent with this id does not exist");
                    return;
                }
                List<string> st = new List<string>();
                foreach (Account account in repositoryAccount.GetAll())
                {
                    st.Add(account.Name);
                }
                if (st.Contains(AccountName.Text))
                {
                    MessageBox.Show("Account with this name already been in DB");
                    return;
                }
                repositoryAccount.Add(new Account
                {
                    Name = AccountName.Text,
                    GetIncindent = repositoryIncident.FindById(Int32.Parse(IncindentId.Text))
                });
                this.Close();
            }
            else
                MessageBox.Show("Empry Field");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void IncindentId_GotFocus(object sender, RoutedEventArgs e)
        {
            IncindentId.Foreground = SystemColors.WindowTextBrush;
            IncindentId.Text = "";
        }

        private void IncindentId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IncindentId.Text == "")
            {
                IncindentId.Foreground = SystemColors.GrayTextBrush;
                IncindentId.Text = "Incendent Id";
            }
        }
    }
}
