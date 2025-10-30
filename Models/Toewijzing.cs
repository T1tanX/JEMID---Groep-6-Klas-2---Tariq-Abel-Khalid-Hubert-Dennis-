using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Toewijzing
{
    public int ToewijzingId { get; set; }
    public int VeilingProductId { get; set; }
    [JsonIgnore][ValidateNever]
    public VeilingProduct? VeilingProduct { get; set; }
    public int KoperId { get; set; }
    [JsonIgnore][ValidateNever]
    public Gebruiker? Koper { get; set; } 
    public decimal EindPrijs { get; set; }
    public DateOnly Datum { get; set; }
}
