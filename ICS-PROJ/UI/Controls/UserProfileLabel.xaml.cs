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
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfileLabel : UserControl
    {
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(String),
            typeof(UserProfileLabel), new FrameworkPropertyMetadata(string.Empty));

        public String? UserName
        {
            get { return GetValue(UserNameProperty).ToString(); }
            set { SetValue(UserNameProperty, value); }
        }
        public UserProfileLabel()
        {
            InitializeComponent();
        }


    }
}
