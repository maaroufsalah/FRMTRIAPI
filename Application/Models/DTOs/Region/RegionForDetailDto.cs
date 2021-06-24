using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Region
{
    public class RegionForDetailDto
    {
        public int Id { get; set; }
        public string NomRegion { get; set; }
        public bool? IsDeleted { get; set; }


    }
}
