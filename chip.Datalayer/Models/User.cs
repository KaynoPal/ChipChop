using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Datalayer.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(RoleId))]
    virtual public Role? Role {  get; set; }

    public virtual List<Factor>? Factors { get; set; }

    //public virtual UserDetail? UserDetail { get; set; }
    public virtual UserInfo? UserInfo { get; set; }
}
