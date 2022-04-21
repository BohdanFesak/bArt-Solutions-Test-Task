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
    /// Interaction logic for Update_Acount_Window.xaml
    /// </summary>
    public partial class Update_Acount_Window : Window
    {
        GenericUnitOfWork Work;
        int Id;
        public Update_Acount_Window(GenericUnitOfWork Work, int Id)
        {
            InitializeComponent();
            this.Id = Id;
            this.Work = Work;
            IGenericRepository<Account> repositoryAccount = Work.Repository<Account>();
            AccountName.Text = repositoryAccount.FindById(Id).Name;
            IncindentId.Text = repositoryAccount.FindById(Id).GetIncindent.Id.ToString();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IGenericRepository<Account> repositoryAccount = Work.Repository<Account>();
            IGenericRepository<Incident> repositoryIncident = Work.Repository<Incident>();
            List<int> ids = new List<int>();
            foreach(Incident incident in repositoryIncident.GetAll())
            {
                ids.Add(incident.Id);
            }
            if (!ids.Contains(Int32.Parse(IncindentId.Text)))
            {
                MessageBox.Show("Incindent with this id does not exist");
                return;
            }
            if (AccountName.Text != "" && IncindentId.Text != "")
            {
                repositoryAccount.FindById(Id).Name = AccountName.Text;
                repositoryAccount.FindById(Id).GetIncindent = repositoryIncident.FindById(Int32.Parse(IncindentId.Text));
                repositoryAccount.Update(repositoryAccount.FindById(Id));
                this.Close();
            }
            else
            {
                MessageBox.Show("One of the field is empty");
            }
        }
    }
}
