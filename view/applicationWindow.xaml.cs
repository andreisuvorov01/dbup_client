using schoolClassDb.DB;
using schoolClassDb.ViewModel;
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

namespace schoolClassDb
{
    /// <summary>
    /// Логика взаимодействия для applicationWindow.xaml
    /// </summary>
    public partial class applicationWindow : Window
    {
        public applicationWindow(USER user)
        {
            InitializeComponent();
            DataContext = new appVM(user);
        }
    }
}
