using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Activite
    {
        public Activite()
        {
            ModuleActivite = new HashSet<ModuleActivite>();
        }

        public int ActiviteId { get; set; }
        public string ActiviteCode { get; set; }
        public string ActiviteLibelle { get; set; }
        public bool ActiviteIsActif { get; set; }
        public DateTime? ActiviteDateCreation { get; set; }
        public string ActiviteUserCreation { get; set; }
        public string ActiviteIcon { get; set; }
        public int? ActiviteOrder { get; set; }

        public virtual ICollection<ModuleActivite> ModuleActivite { get; set; }
    }
}
