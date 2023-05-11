using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OpenWinClash.Models.ForView
{
    [ObservableObject]
    public partial class NavigationItem
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string? description;

        [ObservableProperty]
        private Type targetType;

        public NavigationItem() : this("Page", null, typeof(Page))
        {

        }

        public NavigationItem(string name, string? description, Type targetType)
        {
            this.name = name;
            this.description = description;
            this.targetType = targetType;
        }
    }
}
