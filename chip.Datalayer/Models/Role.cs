using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Datalayer.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام نقش", Prompt = "نام نقض")]
        [MaxLength(15, ErrorMessage = "حداکثر 15 کارکتر")]
        [MinLength(4, ErrorMessage = "حداقل 4 کارکتر")]
        public string RoleName { get; set; } = "user";//en

        [Display(Name = "توضیح نقش", Prompt = "توضیح نقض")]
        [MaxLength(15)]
        public string? RoleTitle { get; set; }//fa

        virtual public ICollection<User> Users { get; set;}
    }
}
