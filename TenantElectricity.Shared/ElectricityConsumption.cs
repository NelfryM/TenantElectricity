namespace TenantElectricity.Shared.Models
{
    public class ElectricityConsumption
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public DateTime Date { get; set; }
        public double ConsumptionKw { get; set; }
    }
}
