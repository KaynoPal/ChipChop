using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Datalayer.Models
{
    public class FactorDetail
    {
        [Key]
        public int Id { get; set; }

        public int FactorId { get; set; }

        public int ContentId { get; set; }

        [Display(Name = "تعداد")]
        public int DetailCount { get; set; }

        [Display(Name = "قیمت نهایی")]
        public int DetailPrice { get; set; }

        [ForeignKey(nameof(FactorId))]
        public virtual Factor? Factor { get; set; }

        [ForeignKey(nameof(ContentId))]
        public virtual Content? Content { get; set; }
    }
}
