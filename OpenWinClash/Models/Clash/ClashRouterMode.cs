namespace OpenWinClash.Models.Clash
{
    public enum ClashRouterMode
    {
        /// <summary>
        /// rule-based packet routing
        /// </summary>
        Rule,

        /// <summary>
        /// all packets will be forwarded to a single endpoint
        /// </summary>
        Global,

        /// <summary>
        /// directly forward the packets to the Internet
        /// </summary>
        Direct
    }
}