using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BARBER_MOVIL_2019.Model;
using BARBER_MOVIL_2019.Services;
using System.Diagnostics;

namespace BARBER_MOVIL_2019
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public ObservableCollection<User> Users { get; }

        public MainPageViewModel()
        {
            Users = new ObservableCollection<User>();
            LoadUsers().GetAwaiter();
        }

        private async Task LoadUsers(List<User> lista = null)
        {
            Users.Clear();
            var userAPI = RestService.For<IRestClientAPI>(RestEndPoints.BaseUrl);
            ICollection<User> result = await userAPI.GetAll();
            if (result.ToList().Count > 0)
                result.ToList().ForEach(x => { Users.Add(x); });
        }
    }
}