using schoolClassDb.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace schoolClassDb.ViewModel
{
    internal class appVM : BaseVM
    {
        public USER _user;

        private string _name;
        private string _surname;
        private int _age;

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public string surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(surname));
            }
        }

        public int age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(age));

            }
        }
        public appVM(USER user)
        {
            try
            {
                if (user != null)
                {
                    name = user.USERINFO.NAME;
                    surname = user.USERINFO.SURNAME;
                    age = user.USERINFO.AGE;
                }
                else
                {
                    MessageBox.Show("Пользователь не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Необработанное исключение", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

    }
}