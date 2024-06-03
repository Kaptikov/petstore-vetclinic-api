using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Clinic
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? AnimalId { get; set; }
        public Animal? Animal { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
