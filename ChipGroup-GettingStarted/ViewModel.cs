
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroup_GettingStarted
{
    public class ViewModel
    {
        public ObservableCollection<Language> Languages { get; set; }

        public ViewModel()
        {
            this.Languages = new ObservableCollection<Language>();

            Languages.Add(new Language() { Name = "C#" });
            Languages.Add(new Language() { Name = "Python" });
            Languages.Add(new Language() { Name = "Java" });
            Languages.Add(new Language() { Name = "Js" });
        }
    }
}
