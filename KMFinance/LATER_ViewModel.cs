using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMFinance
{
    // добавлено, когда делал валидацию для SignUpWin
     
    

    /// <summary>ViewModel - предназначена для передачи в Контекст Данных окна</summary>
    public class ViewModelL : OnPropertyChangedClass
    {
        private MyRelayCommand _connectCommand;
        public MyRelayCommand ConnectCommand => _connectCommand
            ?? (_connectCommand = new MyRelayCommand(ConnectMethod, ConnectCanMethod));

        private bool ConnectCanMethod(object parameter)
            => parameter is bool error && !error;

        private void ConnectMethod(object parameter)
        {
            MessageBox.Show("Соединение");
        }
    }
}
