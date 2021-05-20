using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Countries
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }
    }
}
