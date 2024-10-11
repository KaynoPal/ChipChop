using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Datalayer.Models;

public class Group
{
    [Key]
    public int Id { get; set; }

    [Display(Name ="Name Of Group",Prompt = "Name Of Group")]
    [Required(ErrorMessage = "عنوان گروه ضروری است")]
    [MaxLength(15,ErrorMessage ="atmost 15 char")]
    public string GroupName {  get; set; }

    [Display(Name = "Image", Prompt = "Image Code")]
    public string? Img {  get; set; }

    [Display(Name = "visible")]
    public bool Visible { get; set; } = false;

    virtual public ICollection<Content>? Contents { get; set; }

}
