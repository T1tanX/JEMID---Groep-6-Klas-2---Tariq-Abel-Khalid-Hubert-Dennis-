using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Bieding
{
    public int BiedingId { get; set; }
    public int VeilingProductId { get; set; }
    [JsonIgnore][ValidateNever]
    public VeilingProduct? VeilingProduct { get; set; }
    public int GebruikerId { get; set; }
    [JsonIgnore][ValidateNever]
    public Gebruiker? Gebruiker { get; set; } 
    public decimal Bedrag { get; set; }
    public DateTime Tijdstip { get; set; }  
}