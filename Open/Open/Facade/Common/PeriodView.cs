using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
namespace Open.Facade.Common {
    public abstract class PeriodView : Archetype {
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }

    }
}


