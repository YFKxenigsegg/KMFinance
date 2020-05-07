using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.Text.RegularExpressions;

namespace KMFinance
{
    class SUWinValidationRule : IDataErrorInfo
    {
        private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
        public SUWinValidationRule() { OkCommand = new RelayCommand(() => { }, () => IsOk); }
        public RelayCommand OkCommand { get; private set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string SecPassword { get; set; }
        public string PassportNumber { get; set; }

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
            if (string.IsNullOrEmpty(Name))
                Errors.Add(nameof(Name), "Name must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(Name, @"^[а-яА-ЯёЁa-zA-Z]{2,14}$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(Name)))
                        Errors.Remove(nameof(Name));
                    Errors.Add(nameof(Name), "Name err");
                    break;
                }
            
            if (string.IsNullOrEmpty(Surname))
                Errors.Add(nameof(Surname), "Surname must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(Surname, @"^[а-яА-ЯёЁa-zA-Z]{2,14}$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(Surname)))
                        Errors.Remove(nameof(Surname));
                    Errors.Add(nameof(Surname), "Surname err");
                    break;
                }

            if (string.IsNullOrEmpty(PassportNumber))
                Errors.Add(nameof(PassportNumber), "PassportNumber must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(PassportNumber, @"^[a-zA-Z]{2}[0-9]{7}$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(PassportNumber)))
                        Errors.Remove(nameof(PassportNumber));
                    Errors.Add(nameof(PassportNumber), "PassportNumber err");
                    break;
                }

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
            if (string.IsNullOrEmpty(SecPassword))
                Errors.Add(nameof(SecPassword), "SecPassword must be difined");
            else if (Password != SecPassword || !(Regex.IsMatch(Password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", RegexOptions.IgnoreCase))) 
            {
                Errors.Remove(nameof(SecPassword));
                Errors.Add(nameof(SecPassword), "SecPassword err"); 
            }
           

            if (string.IsNullOrEmpty(Email))
                Errors.Add(nameof(Email), "Email must be difined");
            else
                while (true)
                {
                    if (Regex.IsMatch(Email, @"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", RegexOptions.IgnoreCase))
                        break;
                    else if (Errors.ContainsKey(nameof(Email)))
                        Errors.Remove(nameof(Email));
                    Errors.Add(nameof(Email), "Email err");
                    break;
                }      
            OkCommand.RaiseCanExecuteChanged();
        }
        public string Error => string.Empty;
        public bool HasError => Errors.Any();
        public bool IsOk => !HasError;
    }
}
