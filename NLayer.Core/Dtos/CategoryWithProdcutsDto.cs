using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Dtos
{
    public class CategoryWithProdcutsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
