using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VeilingApi.Models;

public class VeilingProduct
{
    public int VeilingProductId { get; set; }
    public int VeilingId { get; set; }
    [JsonIgnore][ValidateNever]
    public Veiling? Veiling { get; set; }  
    public int AanmeldingId { get; set; }
    [JsonIgnore][ValidateNever]
    public Aanmelding? Aanmelding { get; set; }
    public int VolgordeVeiling { get; set; }

    [JsonIgnore][ValidateNever]
    public ICollection<Bieding>? Biedingen { get; set; } = [];
    [JsonIgnore][ValidateNever]
    public Toewijzing? Toewijzing { get; set; }
}
