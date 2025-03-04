using System.ComponentModel.DataAnnotations;

namespace EasyCash.Domain.Users.Enums;

public enum EActions
{
    [Display(Name = "read")]
    Read,

    [Display(Name = "create")]
    Create,

    [Display(Name = "update")]
    Update,

    [Display(Name = "delete")]
    Delete,

    [Display(Name = "all")]
    All
}