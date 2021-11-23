using System.ComponentModel.DataAnnotations;

namespace JsonDapper.Net_6_0.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string PortfolioCode { get; set; }
        public string PortfolioName { get; set; }
        public string PortfolioType { get; set; }
        public string PortfolioStatus { get; set; }
    }
}
