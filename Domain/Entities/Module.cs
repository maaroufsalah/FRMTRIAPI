using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Module
    {
        public Module()
        {
            ModuleActivite = new HashSet<ModuleActivite>();
        }

        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleLibelle { get; set; }
        public bool ModuleIsActif { get; set; }
        public DateTime? ModuleDateCreation { get; set; }
        public string ModuleUserCreation { get; set; }
        public string ModuleLien { get; set; }
        public string ModuleIcon { get; set; }

        public virtual ICollection<ModuleActivite> ModuleActivite { get; set; }
    }
}
