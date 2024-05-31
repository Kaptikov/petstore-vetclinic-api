namespace petstore_vetclinic_api.Models.Clinic
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
