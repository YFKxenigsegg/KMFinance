using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace KMFinance
{
    class LIWinValidationRule : IDataErrorInfo
    {
        private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
        public LIWinValidationRule() { OkCommand = new RelayCommand(() => { }, () => IsOk); }
        public RelayCommand OkCommand { get; private set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }

        public string this[string propertyName]
        {
            get
            {
                collectErrors();
                return Errors.ContainsKey(propertyName) ? Errors[propertyName] : string.Empty;
            }
        }
        private void collectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrEmpty(UserLogin))
                Errors.Add(nameof(UserLogin), "UserLogin must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(UserLogin, @"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(UserLogin)))
                        Errors.Remove(nameof(UserLogin));
                    Errors.Add(nameof(UserLogin), "UserLogin err");
                    break;
                }

            if (string.IsNullOrEmpty(Password))
                Errors.Add(nameof(Password), "Password must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(Password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(Password)))
                        Errors.Remove(nameof(Password));
                    Errors.Add(nameof(Password), "Password err");
                    break;
                }
           
            OkCommand.RaiseCanExecuteChanged();
        }
        public string Error => string.Empty;
        public bool HasError => Errors.Any();
        public bool IsOk => !HasError;
    }
}
