using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab1
{
    class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime _birthDate = DateTime.Today;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                Change(value);

            }
        }

        public Visibility _visibleBirthday = Visibility.Hidden;
        public Visibility VisibleBirthday
        {
            get { return _visibleBirthday; }
            set
            {
                _visibleBirthday = value;
                OnPropertyChanged("VisibleBirthday");
            }
        }

        public Visibility _visibleEror = Visibility.Hidden;
        public Visibility VisibleEror
        {
            get { return _visibleEror; }
            set
            {
                _visibleEror = value;
                OnPropertyChanged("VisibleEror");
            }
        }
        public string Age
        {
            get { return " " + YourAge(BirthDate); }
            set { }
        }

        public string ChineeseCalendar
        {
            get { return ChineeseYear(BirthDate); }
            set { }
        }
        public string WestCalendar
        {
            get { return WestYear(BirthDate); }
            set { }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string ChineeseYear(DateTime BirthYear)
        {

            string chineeseYearOfBirth = "default";
           
            if ((BirthDate.Year) % 12 == 0)
            {
                chineeseYearOfBirth = "monkey";
            }
            if ((BirthDate.Year) % 12 == 1)
            {
                chineeseYearOfBirth = "cock";
            }
            if ((BirthDate.Year) % 12 == 2)
            {
                chineeseYearOfBirth = "dog";

            }
            if ((BirthDate.Year) % 12 == 3)
            {
                chineeseYearOfBirth = "pig";
            }
            if ((BirthDate.Year) % 12 == 4)
            {
                chineeseYearOfBirth = "rat";
            }
            if ((BirthDate.Year) % 12 == 5)
            {
                chineeseYearOfBirth = "bull";
            }
            if ((BirthDate.Year) % 12 == 6)
            {
                chineeseYearOfBirth = "tiger";
            }
            if ((BirthDate.Year) % 12 == 7)
            {
                chineeseYearOfBirth = "rabbit";
            }
            if ((BirthDate.Year) % 12 == 8)
            {
                chineeseYearOfBirth = "dragon";
            }
            if ((BirthDate.Year) % 12 == 9)
            {
                chineeseYearOfBirth = "snake";
            }
            if ((BirthDate.Year) % 12 == 10)
            {
                chineeseYearOfBirth = "horse";
            }
            if ((BirthDate.Year) % 12 == 11)
            {
                chineeseYearOfBirth = "goat";
            }
            return " "+chineeseYearOfBirth;
        }
        string WestYear(DateTime BirthDayMounth)
        {

            string westSignOfBirth = null;
            if ((BirthDate.Day >= 22 && BirthDate.Month == 12) ||
                (BirthDate.Day <= 19 && BirthDate.Month == 1))
            {
                westSignOfBirth = "Capricorn";
            }
            if ((BirthDate.Day >= 20 && BirthDate.Month == 1) ||
               (BirthDate.Day <= 18 && BirthDate.Month == 2))
            {
                westSignOfBirth = "Aquarius";
            }
            if ((BirthDate.Day >= 19 && BirthDate.Month == 2) ||
            (BirthDate.Day <= 20 && BirthDate.Month == 3))
            {
                westSignOfBirth = "Fish";
            }
            if ((BirthDate.Day >= 21 && BirthDate.Month == 3) ||
          (BirthDate.Day <= 19 && BirthDate.Month == 4))
            {
                westSignOfBirth = "Aries";
            }
            if ((BirthDate.Day >= 20 && BirthDate.Month == 4) ||
        (BirthDate.Day <= 20 && BirthDate.Month == 5))
            {
                westSignOfBirth = "Taurus";
            }
            if ((BirthDate.Day >= 21 && BirthDate.Month == 5) ||
    (BirthDate.Day <= 20 && BirthDate.Month == 6))
            {
                westSignOfBirth = "Twins";
            }
            if ((BirthDate.Day >= 21 && BirthDate.Month == 6) ||
(BirthDate.Day <= 22 && BirthDate.Month == 7))
            {
                westSignOfBirth = "Сancer";
            }
            if ((BirthDate.Day >= 23 && BirthDate.Month == 7) ||
(BirthDate.Day <= 22 && BirthDate.Month == 8))
            {
                westSignOfBirth = "Lion";
            }
            if ((BirthDate.Day >= 23 && BirthDate.Month == 8) ||
(BirthDate.Day <= 22 && BirthDate.Month == 9))
            {
                westSignOfBirth = "Virgo";
            }
            if ((BirthDate.Day >= 23 && BirthDate.Month == 9) ||
(BirthDate.Day <= 22 && BirthDate.Month == 10))
            {
                westSignOfBirth = "Libra";
            }
            if ((BirthDate.Day >= 23 && BirthDate.Month == 10) ||
(BirthDate.Day <= 21 && BirthDate.Month == 11))
            {
                westSignOfBirth = "Scorpion";
            }
            if ((BirthDate.Day >= 22 && BirthDate.Month == 11) ||
(BirthDate.Day <= 21 && BirthDate.Month == 12))
            {
                westSignOfBirth = "Sagittarius";
            }
            return westSignOfBirth;
        }
        int YourAge(DateTime Birthday)
        {

            int age;
            age = DateTime.Today.Year - BirthDate.Year;
            if (DateTime.Today.DayOfYear < BirthDate.DayOfYear &&
                DateTime.Today.Year != BirthDate.Year)
            {
                age = age - 1;
            }
            if (age >= 0 && age < 135 && BirthDate.DayOfYear == DateTime.Today.DayOfYear)
                _visibleBirthday = Visibility.Visible;

            if (age < 0 || age > 135)
            {
                _visibleEror = Visibility.Visible;
            }
            return age;
        }
        public async void Change(DateTime value)
        {
            await Task.Run(() => ChangeInfo(value));
        }
        internal void ChangeInfo(DateTime value)
        {
            _birthDate = value;

            OnPropertyChanged("BirthDate");
            OnPropertyChanged("Age");
            OnPropertyChanged("WestCalendar");
            OnPropertyChanged("ChineeseCalendar");
        }


    }

}
