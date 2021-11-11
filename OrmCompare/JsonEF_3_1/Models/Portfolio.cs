using System.ComponentModel.DataAnnotations;

namespace JsonEF_3._1.Models
{
    public class portfolio
    {
        [Key]
        public int Portfolio_Id { get; set; }
        public string Portfolio_Code { get; set; }
        public string Portfolio_Name { get; set; }
        public string Portfolio_Type { get; set; }
        public string Portfolio_Status { get; set; }
    }
}
