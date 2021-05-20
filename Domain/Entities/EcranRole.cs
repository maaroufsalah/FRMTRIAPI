using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class EcranRole
    {
        public int EcranRoleId { get; set; }
        public string RoleId { get; set; }
        public int? EcranId { get; set; }
        public bool? EcranRoleConsult { get; set; }
        public bool? EcranRoleAdd { get; set; }
        public bool? EcranRoleUpdate { get; set; }
        public bool? EcranRoleDelete { get; set; }
        public DateTime? EcranRoleDateModification { get; set; }

        public virtual Ecran Ecran { get; set; }
        public virtual AspNetRoles Role { get; set; }
    }
}
