using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DiscoverySource
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public DateTime EstablishmentDate { get; set; }

        public DiscoverySourceType Type { get; set; }

        public ICollection<CelestialObject> CelestialObjects { get; set; } = new List<CelestialObject>();
    }
}
