using petstore_vetclinic_api.Models.Orders;

namespace petstore_vetclinic_api.Models.Clinic
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
