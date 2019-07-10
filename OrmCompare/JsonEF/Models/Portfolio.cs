using System.ComponentModel.DataAnnotations;

namespace JsonEF.Models
{
    public class tbl_pm01_portfolio
    {
        [Key]
        public int Portfolio_Id { get; set; }
        public string Portfolio_Code { get; set; }
        public string Portfolio_Name { get; set; }
        public string Portfolio_Type { get; set; }
        public string Portfolio_Status { get; set; }
    }
}
