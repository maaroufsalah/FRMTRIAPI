using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class ModuleActivite
    {
        public ModuleActivite()
        {
            Ecran = new HashSet<Ecran>();
        }

        public int MaId { get; set; }
        public int? MaModuleId { get; set; }
        public int? MaActiviteId { get; set; }
        public bool? MaIsactive { get; set; }
        public DateTime? MaDateModification { get; set; }
        public bool? MaIsgroup { get; set; }

        public virtual Activite MaActivite { get; set; }
        public virtual Module MaModule { get; set; }
        public virtual ICollection<Ecran> Ecran { get; set; }
    }
}
