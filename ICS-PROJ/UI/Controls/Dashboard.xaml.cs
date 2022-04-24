using BL.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private readonly Grid grid;

        public Dashboard(Grid grid, UserListModel model)
        {
            InitializeComponent();

            UserName.Content = model.Name;
            this.grid = grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(new Accounts(grid));
        }
    }
}
