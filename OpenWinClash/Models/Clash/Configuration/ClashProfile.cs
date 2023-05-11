namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashProfile
    {
        /// <summary>
        /// Store the `select` results in $HOME/.config/clash/.cache
        /// set false If you don't want this behavior
        /// when two different configurations have groups with the same name, the selected values are shared
        /// </summary>
        public bool StoreSelected { get; set; } = false;

        /// <summary>
        /// persistence fakeip
        /// </summary>
        public bool StoreFakeIp { get; set; } = true;
    }
}