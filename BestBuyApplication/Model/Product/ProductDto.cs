using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApplication.Model.Product
{
    public class ProductDto
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<DataDto> data { get; set; }
    }
}
