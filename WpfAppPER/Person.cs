using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace WpfAppPER
{
    class Person : INotifyPropertyChanged
    {
        private string _name;
        private string _last_name;
        private string _email;
        DateTime _date_birth;
        private int _age;

        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _sunSign;
        private readonly string _chineseSign;

        public Person( string n, string l, string e, DateTime d) {
            _name = n;
            _last_name = l;
            _email = e;
            _date_birth = d;
            
            _age = UserAge(d);

            _chineseSign = ChineseSign_value(d);
            _sunSign = SunSign_value(d);
            _isBirthday = IsBirthday_value(d);
            _isAdult = IsAdult_value(_age);

            CheckAge(_age);
            CheckMylo(_email);

        }

        public Person(string n, string l, string e)
        {
            _name = n;
            _last_name = l;
            _email = e;
            _date_birth = DateTime.Today;
            _age = UserAge(_date_birth);
        }

        public Person(string n, string l, DateTime d)
        {
            _name = n;
            _last_name = l;
            _date_birth = d;
            _email = "mylovarka@gmail.com";
            _age = UserAge(d);

        }
        public DateTime Birthday
        {
            get => _date_birth;
            set
            {
                _date_birth = value;
                
                OnPropertyChanged("Date of birth");
               
            }
        }

        public string F_name
        {
            get => _name;
            private set
            {
                _name = value;
               
                OnPropertyChanged("First name");
            }
        }
        public string L_name
        {
            get => _last_name;
            set
            {
                _last_name = value;
                OnPropertyChanged("Last name");
            }
        }

        public string Mylo
        {
            get => _email;
            set
            {
                _email = value;
               
                OnPropertyChanged("Email");
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        private int UserAge(DateTime a)
        {
            if (a.Month > DateTime.Today.Month)
            {
                return DateTime.Today.Year - (a.Year + 1);
            }
            else if (a.Month == DateTime.Today.Month)
            {
                if (a.Day > DateTime.Today.Day)
                {
                    return DateTime.Today.Year - (a.Year + 1);
                }
            }
            return DateTime.Today.Year - a.Year;
        }

        private void CheckAge(int age) {
            if (age > 135)
            {

                throw new TooOld("Wrong date of birth");
            }
            else if (age < 0) {
                throw new TooYoung("Wrong date of birth");
            }
        }

        private void CheckMylo(string mylo)
        {
            try
            {
                MailAddress Address = new MailAddress(mylo);

            }
            catch (FormatException)
            {
                throw new WrongMylo("Wrong email!");
              
            }
        }

        private bool IsBirthday_value(DateTime d)
        {
            return DateTime.Today.Day == d.Day && DateTime.Today.Month == d.Month;
        }

        private bool IsAdult_value(int a)
        {
            return a >= 18;
        }

        private string ChineseSign_value(DateTime d)
        {
            int a = d.Year;
            string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            int ai = (a - 4) % 12;
            return animals[ai];
        }

        private string SunSign_value(DateTime a)
        {
            int days = a.Day;
            switch (a.Month)
            {
                case 1:
                    if (days >= 1 & days <= 19)
                    {
                        return "Capricorn";
                    }
                    else return "Aquarius";
                case 2:
                    if (days >= 1 & days <= 19) { return "Aquarius"; }
                    else return "Pisces";
                case 3:
                    if (days >= 1 & days <= 20) { return "Pisces"; }
                    else return "Aries";
                case 4:
                    if (days >= 1 & days <= 20) { return "Aries"; }
                    else return "Taurus";
                case 5:
                    if (days >= 1 & days <= 20) { return "Taurus"; }
                    else return "Gemini";
                case 6:
                    if (days >= 1 & days <= 20) { return "Gemini"; }
                    else return "Cancer";
                case 7:
                    if (days >= 1 & days <= 22) { return "Cancer"; }
                    else return "Leo";
                case 8:
                    if (days >= 1 & days <= 22) { return "Leo"; }
                    else return "Virgo";
                case 9:
                    if (days >= 1 & days <= 22) { return "Virgo"; }
                    else return "Libra";
                case 10:
                    if (days >= 1 & days <= 22) { return "Libra"; }
                    else return "Scorpio";
                case 11:
                    if (days >= 1 & days <= 22) { return "Scorpio"; }
                    else return "Sagittarius";
                case 12:
                    if (days >= 1 & days <= 21) { return "Sagittarius"; }
                    else return "Capricorn";

            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
