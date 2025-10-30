using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class Aanvoerder
{
    public int AanvoerderId { get; set; }
    public string Naam { get; set; } = null!;
    [JsonIgnore][ValidateNever]
public ICollection<Aanmelding>? Aanmeldingen { get; set; } = []; // ignore (collectie is niet required)

}
