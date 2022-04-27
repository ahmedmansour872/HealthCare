namespace WebApplication1.DTO
{
    public class PatientVM
    {
        public int Id { get; set; }
        public long MilitaryNumber { get; set; }
        public string Rank { get; set; }
        public long NationalId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Mname2 { get; set; }
        public string Lname { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public bool Reserved { get; set; }
        public int? ReceptionestId { get; set; }
        public int? Age { get; set; }

    }
}
