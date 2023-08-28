using System;
using System.ComponentModel;

namespace SteveMAUI.MVVM
{
    public abstract class CsBaseContexte : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifierChangement(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public void NotifierChangement(object sender, string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
