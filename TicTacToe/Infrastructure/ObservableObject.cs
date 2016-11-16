using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.Infrastructure
{
    /// <summary>
    /// Base class for ViewModels and other objects required to expose properties to a view
    /// </summary>
    internal abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}