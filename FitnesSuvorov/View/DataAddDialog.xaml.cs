using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FitnesSuvorov.Db;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity.Migrations;

namespace FitnesSuvorov.View
{
    /// <summary>
    /// Логика взаимодействия для DataAddDialog.xaml
    /// </summary>
    public partial class DataAddDialog : Window
    {
        private USERINFO _userinfo;
        public DataAddDialog(USERINFO userinfo)
        {
            InitializeComponent();

            foreach (var item in App.Current.Windows)
            {
                if (item is DataGridProduct)
                {
                    this.Owner = item as Window;
                }
            }

            if (userinfo is null)
            {
                _userinfo = userinfo = new USERINFO();
            }
            else
            {
                _userinfo = userinfo;
            }
            this.DataContext = _userinfo;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FitnesDbEntities())
            {
                try
                {


                    db.USERINFO.AddOrUpdate(_userinfo);
                    db.SaveChanges();
                    MessageBox.Show("данные успешно сохранены", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    (Owner as DataGridProduct)?.refres();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private StringBuilder ValidateEntities()
        {
            var result = new StringBuilder();
            if (_userinfo != null)
            {
                if (string.IsNullOrEmpty(_userinfo.NAME))
                {
                    result.AppendLine("поле названия не может быть пустым");
                }
                if (string.IsNullOrEmpty(_userinfo.SURNAME))
                {
                    result.AppendLine("поле фамилия не может быть пустым");
                }
                if (_userinfo.AGE <= 0)
                {
                    result.AppendLine("поле Возраст не может быть пустым");
                }
            }
            return result;
        }
    }
}
