using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Datalayer.Models;

public class Content
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "گروه محتوا ضروری است")]
    [Display(Name = "Content Group")]
    public int GroupId { get; set; }

    [Required(ErrorMessage = "عنوان محتوا ضروری است")]
    [Display(Name ="Content name",Prompt ="Content name")]
    public string Name { get; set; }

    [Display(Name = "Content information", Prompt = "Content information")]
    public string? Description { get; set; }

    //[Required(ErrorMessage = "the Content image is required")]
    [Display(Name = "Content image", Prompt = "Content image")]
    public string? Img { get; set; }

    [Display(Name = "price", Prompt = "price")]
    public int price { get; set; }

    [Display(Name = "sellOff", Prompt = "sellOff")]
    public int Selloff { get; set; }

    [Display(Name = "Inventory", Prompt = "Inventory")]
    public int NumberAvailable { get; set; }

    [Display(Name="Content Date",Prompt = "Content Date")]
    public string SubmitDate { get; set; }

    [Display(Name = "وضعیت نمایش محتوا")]
    public bool Visible { get; set; } = true;

    [ForeignKey(nameof(GroupId))]
    virtual public Group? Group { get; set; }
}
