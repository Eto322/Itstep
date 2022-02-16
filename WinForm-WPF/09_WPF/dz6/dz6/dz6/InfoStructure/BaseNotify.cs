using System.ComponentModel;
using System.Runtime.CompilerServices;
using dz6.Annotations;

namespace dz6.InfoStructure
{
    public class BaseNotify:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}