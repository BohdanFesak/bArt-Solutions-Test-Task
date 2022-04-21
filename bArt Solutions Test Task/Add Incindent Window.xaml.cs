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
    /// Interaction logic for Add_Incindent_Window.xaml
    /// </summary>
    public partial class Add_Incindent_Window : Window
    {
        GenericUnitOfWork Work;
        public Add_Incindent_Window(GenericUnitOfWork Work)
        {
            this.Work = Work;
            InitializeComponent();
        }

        private void IncendentDesc_GotFocus(object sender, RoutedEventArgs e)
        {
            IncendentDesc.Foreground = SystemColors.WindowTextBrush;
            IncendentDesc.Text = "";
        }

        private void IncendentDesc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IncendentDesc.Text == "")
            {
                IncendentDesc.Foreground = SystemColors.GrayTextBrush;
                IncendentDesc.Text = "Description";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IncendentDesc.Text != "Description" && IncendentDesc.Text != "")
            {
                IGenericRepository<Incident> repositoryIncident = Work.Repository<Incident>();
                repositoryIncident.Add(new Incident { Description = IncendentDesc.Text });
            }
            else
                MessageBox.Show("Empty field");
        }
    }
}
