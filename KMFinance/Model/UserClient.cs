using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace KMFinance
{
    class UserClient
    {
        [Key]
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string RegistrationDate { get; set; }
    }
}

