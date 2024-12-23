using System.Collections.ObjectModel;
using AppLauncher.Models;
using Prism.Mvvm;

namespace AppLauncher.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ApplicationListViewModel : BindableBase
    {
        private ApplicationInfo selectedItem;

        public ObservableCollection<ApplicationInfo> ApplicationInfos { get; set; } = new ();

        public ApplicationInfo SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }
    }
}