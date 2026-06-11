namespace Domain.Models
{
    public class CelestialObject
    {
        public string Name { get; set; } = string.Empty;

        public decimal Mass { get; set; }

        public decimal EquatorialDiameter { get; set; }

        public decimal SurfaceTemperature { get; set; }

        public DateTime DiscoveryDate { get; set; }

        public Guid DiscoverySourceId { get; set; }

        public DiscoverySource DiscoverySource { get; set; }

        public CelestialObjectType Type { get; set; }
    }
}
