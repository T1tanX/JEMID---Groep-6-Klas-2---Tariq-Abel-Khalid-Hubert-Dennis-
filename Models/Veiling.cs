using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Veiling
{
    public int VeilingId { get; set; }
    public DateTime StartTijd { get; set; }
    public DateTime EindTijd { get; set; }
    public string Status { get; set; } = null!;

    public int GestartDoorId { get; set; }

[JsonIgnore][ValidateNever]
public Gebruiker? GestartDoor { get; set; }   // ← nullable + ignore

[JsonIgnore][ValidateNever]
public ICollection<VeilingProduct>? Kavels { get; set; } = [];

}
