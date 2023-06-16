namespace Proxfield.GoogleDdns.Updater.Domain.Models
{
    /// <summary>
    /// App DDNS settings class
    /// </summary>
    public class DdnsSettings
    {
        /// <summary>
        /// Hosts, or DDNS pointers
        /// </summary>
        public List<Host> Hosts { get; set; }
        /// <summary>
        /// Update interval in seconds
        /// </summary>
        public int UpdateInterval { get; set; }
        /// <summary>
        /// Max parallel executions
        /// </summary>
        public int MaxParallelExecutions { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public DdnsSettings()
        {
            this.Hosts= new List<Host>();
        }
    }
}