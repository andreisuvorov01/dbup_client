using System;
using FitnesSuvorov.Db;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnesSuvorov.ViewModel
{
    public class DataGridVM : BaseVm
    {
        private USERINFO _SelectedItem;
        private ObservableCollection<USERINFO> _userinfot;

        public ObservableCollection<USERINFO> userinfo
        {
            get => _userinfot;
            set
            {
                _userinfot = value;
                OnpropertyChanged(nameof(userinfo));
            }
        }
        public USERINFO SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnpropertyChanged(nameof(SelectedItem));
            }
        }
        public DataGridVM()
        {
            userinfo = new ObservableCollection<USERINFO>();

            LoadData();
        }

        public void LoadData()
        {
            if (userinfo.Count != 0)
            {
                userinfo.Clear();
            }

            var result = DbStorage.Db_s.USERINFO.ToList();
            result.ForEach(elem => userinfo?.Add(elem));
        }
        public void DeleteItenData()
        {
            if (!(SelectedItem is null))
            {
                using (var db = new FitnesDbEntities())
                {
                    var result = MessageBox.Show("вы действительно хотите удалить этот элемент?", "предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var ItemForDelete = db.USERINFO.Where(elem => elem.Id == SelectedItem.Id).FirstOrDefault();
                            db.USERINFO.Remove(ItemForDelete);
                            db.SaveChanges();
                            LoadData();
                            MessageBox.Show("данные успешно удалены", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }
    }
}
