using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Ecran
    {
        public int EcranId { get; set; }
        public string EcranLibelle { get; set; }
        public string EcranDescription { get; set; }
        public int? EcranOrdre { get; set; }
        public string EcranNom { get; set; }
        public DateTime? EcranDateModification { get; set; }
        public int? EcranModuleId { get; set; }
        public string EcranLien { get; set; }

        public virtual ModuleActivite EcranModule { get; set; }
    }
}
