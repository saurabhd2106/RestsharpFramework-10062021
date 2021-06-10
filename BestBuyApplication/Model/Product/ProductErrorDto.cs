using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApplication.Model.Product
{
    public class ProductErrorDto
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string className { get; set; }
        public DataDto data { get; set; }
        public List<string> errors { get; set; }
    }
}
