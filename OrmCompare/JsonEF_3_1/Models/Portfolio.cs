using System.ComponentModel.DataAnnotations;

namespace JsonEF_3_1.Models
{
    public class portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string PortfolioCode { get; set; }
        public string PortfolioName { get; set; }
        public string PortfolioType { get; set; }
        public string PortfolioStatus { get; set; }
    }
}
