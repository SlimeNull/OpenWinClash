namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashShadowsocksProxy : ClashProxy
    {
        public override ClashProxyType Type => ClashProxyType.Shadowsocks;

        public string Cipher { get; set; } = "chacha20-ietf-poly1305";
        public string Password { get; set; } = string.Empty;
    }


}