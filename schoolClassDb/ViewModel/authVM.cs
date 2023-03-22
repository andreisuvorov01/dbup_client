using schoolClassDb.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using schoolClassDb.DB;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace schoolClassDb.ViewModel
{
    public class authVM : BaseVM
    {
        private string _btnSend = "войти";

            private USER _user;
        public string _login;
        public string _password;


        public string Login {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
           

        public string Password
    {
            get => _password;
            set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

        public string btnSend
        {
            get => _btnSend;
            set
            {
                _btnSend = value;
                OnPropertyChanged(nameof(btnSend));
            }
        }

        
      
        private async Task<bool> Authorize(string Login, string Password)
        {
            try
            {
                var result = await DbStorage.DB_S.USER.FirstOrDefaultAsync(USER => USER.login == Login && USER.PASSWORD == Password);
                _user = result;
                var authViewModel = new authVM();
                string login = authViewModel.Login;
                string password = authViewModel.Password;
                var dataGrid = new DataGridDB(login, password);


                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "необработанное исключеине", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
                    }
        }

        public async void authInApp()
        {
            var authViewModel = new authVM();
            authViewModel.Login = Login; // передача поля Login
            authViewModel.Password = Password; // передача поля Password
            btnSend = "подождите...";
            if (await Authorize(Login, Password))
            {
                var dataGrid = new DataGridDB(Login, Password);
                var applicationWindow = new applicationWindow { DataContext = dataGrid };
                applicationWindow.Show();

                foreach (var item in App.Current.Windows)
                {
                    if (item is MainWindow) {
                        (item as Window)?.Hide();
                    }
                }
                btnSend = "войти";

                return;
            }
            MessageBox.Show("неверный логин или пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            btnSend = "войти";
        }
       
    }
}
