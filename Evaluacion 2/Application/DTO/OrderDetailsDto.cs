using System;
using System.Collections.Generic;

namespace Evaluacion_2.Models.DTO
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
