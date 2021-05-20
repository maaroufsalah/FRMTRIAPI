using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class User
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateUser { get; set; }
        public bool? Active { get; set; }
    }
}
