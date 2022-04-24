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
using UI.ViewModels;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : UserControl
    {
        private readonly Grid grid;

        public Accounts(Grid grid)
        {
            InitializeComponent();

            UserListBox.DataContext = new UserListViewModel();
            this.grid = grid;

            //EventManager.RegisterClassHandler(typeof(ListBoxItem),
            //ListBoxItem.MouseLeftButtonDownEvent,
            //new RoutedEventHandler(this.OnMouseLeftButtonDown));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(new NewUser(grid));
        }

        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (ListBoxItem)sender;
            var user = item.Content as UserListModel;
            if (user == null)
                return;

            grid.Children.Clear();
            grid.Children.Add(new Dashboard(grid, user));
        }
    }
}
