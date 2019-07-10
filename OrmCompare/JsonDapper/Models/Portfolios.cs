using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonDapper.Models
{
    public class Portfolios
    {
        public List<Portfolio> Items { get; set; }
    }

    public class Portfolio
    {
        public string Portfolio_Code { get; set; }
        public string Portfolio_Name { get; set; }
        public string Portfolio_Type { get; set; }
        public string Portfolio_Status { get; set; }
    }
}
