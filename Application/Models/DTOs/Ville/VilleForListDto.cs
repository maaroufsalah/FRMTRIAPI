using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.DTOs.Ville
{
    public class VilleForListDto
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public string NomRegion { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
