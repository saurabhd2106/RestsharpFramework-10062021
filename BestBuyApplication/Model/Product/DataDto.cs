using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApplication.Model.Product
{
    public class DataDto : ProductRequestDto
    {
        public int id { get; set; }
      
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<CategoryDto> categories { get; set; }
    }
}
