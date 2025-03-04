using System.ComponentModel.DataAnnotations;

namespace EasyCash.Domain.Users.Enums;

public enum EModules
{
    [Display(Name = "admin")]
    Admin,

    [Display(Name = "collaborator")]
    Collaborator,
}