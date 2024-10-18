namespace gestaoDeConsulta.Models
{
    public class Doctor : Base
    {

        public string Name { get; private set; }
        public string CRM { get; private set; }
        public IEnumerable<Specialty> Specialtys { get; private set; } = new List<Specialty>();
        public string WorkingHours { get; set; }

        public string Phone { get; private set; }
        public string Email { get; private set; }

        public Doctor()
        {

        }

        public Doctor(string name, string cRM, IEnumerable<Specialty> specialtys, string workingHours, string phone, string email)
        {
            Name = name;
            CRM = cRM;
            Specialtys = specialtys;
            WorkingHours = workingHours;
            Phone = phone;
            Email = email;
        }
    }
}
