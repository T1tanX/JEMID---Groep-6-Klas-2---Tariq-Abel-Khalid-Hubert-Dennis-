using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Aanmelding
{
    public int AanmeldingId { get; set; }
    public string FotoUrl { get; set; } = null!;
    public string ProductBeschrijving { get; set; } = null!;
    public int Hoeveelheid { get; set; }
    public decimal MinimumPrijs { get; set; }
    public string GewensteKlokLocatie { get; set; } = null!;
    public DateOnly GewensteVeilDatum { get; set; }

    public int AanvoerderId { get; set; }

    [JsonIgnore][ValidateNever]
public Aanvoerder? Aanvoerder { get; set; }   // ← nullable + ignore

[JsonIgnore][ValidateNever]
public VeilingProduct? VeilingProduct { get; set; }
}
