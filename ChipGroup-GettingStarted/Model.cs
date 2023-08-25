using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroup_GettingStarted
{
    public class Language : INotifyPropertyChanged
    {
        public string Name
        {
            get;
            set;
        }

        private bool isChecked = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
