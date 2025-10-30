using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Gebruiker
{
    public int GebruikerId { get; set; }
    public string Naam { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string WachtwoordHash { get; set; } = null!;
    public string Rol { get; set; } = null!; // "Klant" of "Veilingmeester"

    [JsonIgnore][ValidateNever]
public ICollection<Bieding>? Biedingen { get; set; } = [];

[JsonIgnore][ValidateNever]
public ICollection<Veiling>? GestarteVeilingen { get; set; } = [];

[JsonIgnore][ValidateNever]
public ICollection<Toewijzing>? Aankopen { get; set; } = [];

}
