using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class UserTypes
    {
        public int Id { get; set; }
        public int? UserType { get; set; }
        public string UserTypeLibelle { get; set; }
    }
}
