using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int Price { get; set; }

        public string Description { get; set; } = null!;


        public int NumberofProducts { get; set; }
    }
}
