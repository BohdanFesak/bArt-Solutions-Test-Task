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
    /// Interaction logic for Incindent_Update_Window.xaml
    /// </summary>
    public partial class Incindent_Update_Window : Window
    {
        GenericUnitOfWork Work;
        int Id;
        public Incindent_Update_Window(GenericUnitOfWork Work, int Id)
        {
            InitializeComponent();
            this.Work = Work;
            this.Id = Id;
            IGenericRepository<Incident> repositoryIncident = Work.Repository<Incident>();
            IncindentDesc.Text = repositoryIncident.FindById(Id).Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IncindentDesc.Text != "")
            {
                IGenericRepository<Incident> repositoryIncident = Work.Repository<Incident>();
                repositoryIncident.FindById(Id).Description = IncindentDesc.Text;
                repositoryIncident.Update(repositoryIncident.FindById(Id));
                this.Close();
            }
            else
            {
                MessageBox.Show("Field is empty");
            }
        }
    }
}
