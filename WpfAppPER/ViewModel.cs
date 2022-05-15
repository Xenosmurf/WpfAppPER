using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace WpfAppPER
{
    class ViewModel : INotifyPropertyChanged
    {
        private Person selectedPerson;

        private string _name;
        private string _last_name;
        private string _email;
        DateTime _date_birth;

        private string _age;

        private  bool _isAdult;
        private  bool _isBirthday;
        private  string _sunSign;
        private  string _chineseSign;

        private string _personData;

        private RelayCommand procceed;

        public RelayCommand Proceed
        {
            get
            {
                return procceed ?? (procceed = new RelayCommand(
                           Proceed_Button, o => CanProceed()));
            }
        }
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
        public ViewModel(){
           
        }

        public DateTime Birthday
        {
            get => _date_birth;
            set
            {
                _date_birth = value;

                OnPropertyChanged("Date of birth");
                if (IsBirthday_count())
                {
                    MessageBox.Show("Happy birthday!");
                }
            }
        }

        public string F_name
        {
            get => _name;
            set
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

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public bool IsBirthday
        {
            get => _isBirthday;
            set
            {
                _isBirthday = value;

                OnPropertyChanged("isBirthday");
            }
        }

        public bool IsAdult
        {
            get => _isAdult;
            set
            {
                _isAdult = value;

                OnPropertyChanged("isAdult");
            }
        }

        public string ChineseSign
        {
            get => _chineseSign;
            set
            {
                _chineseSign = value;

                OnPropertyChanged("chineseSign");
            }
        }

        public string SunSign
        {
            get => _sunSign;
            set
            {
                _sunSign = value;

                OnPropertyChanged("SunSign");
            }
        }

        public string PersonData {
            get => _personData;
            set {
                _personData = value;
                OnPropertyChanged("PersonData");
            }
        }

   
        private bool IsBirthday_count()
        {
            return DateTime.Today.DayOfYear == _date_birth.DayOfYear;
        }


        private async void Proceed_Button(object obj)
        {
            
            Age = "";
            //SunSign = "";
            //ChineseSign = "";
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                try
                {
                    SelectedPerson = new Person(F_name, L_name, Mylo, Birthday);
                   
                    if (IsBirthday_count())
                    {
                        Age = "Happy birthday!";
                    }
                    else
                    {
                        Age = "Your age is " + SelectedPerson.Age + " full years.";
                    }
                    if (SelectedPerson.IsAdult)
                    {
                        PersonData = selectedPerson.F_name + " , " + selectedPerson.L_name + " , " + selectedPerson.Birthday.Date +" ; " + selectedPerson.Mylo + "  - is Adult.";
                    }
                    else
                    {
                        PersonData = selectedPerson.F_name + " , " + selectedPerson.L_name + " , " + selectedPerson.Birthday.Date + " ; " + selectedPerson.Mylo + " - is Underaged.";
                    }
                    SunSign = "Your sun sign is " + selectedPerson.SunSign;
                    ChineseSign = "Your Chinese zodiac sign is " + selectedPerson.ChineseSign;
                    // }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            });
        }

        private bool CanProceed()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_last_name) || string.IsNullOrWhiteSpace(_email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
