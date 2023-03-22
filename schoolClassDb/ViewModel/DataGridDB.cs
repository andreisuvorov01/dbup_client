using schoolClassDb.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace schoolClassDb.ViewModel
{
    public class DataGridDB : BaseVM
    {
        private ObservableCollection<USERINFO> _userinfo;
        public string Login { get; }
        public string Password { get; }
        public ObservableCollection<USERINFO> UserInfo
        {
            get => _userinfo;
            set
            {
                var authViewModel = new authVM();
                _userinfo = value;
                
                OnPropertyChanged(nameof(UserInfo));
            }
        }

        public DataGridDB(string login, string password)
        {
            Login = login;
            Password = password;
        UserInfo = new ObservableCollection<USERINFO>();
            
                 LoadData(login, password);
            }
           
            public void LoadData(string login, string password)
        {
           
            var result = from u in DbStorage.DB_S.USER
                             join ui in DbStorage.DB_S.USERINFO on u.UserInfoId equals ui.Id
                             where u.login == Login && u.PASSWORD == Password
                             select ui;
            
            UserInfo = new ObservableCollection<USERINFO>(result.ToList());
            var resultList = result.ToList();
            

        }
    }
}
