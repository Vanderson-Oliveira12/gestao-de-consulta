namespace gestaoDeConsulta.Models
{
    public class Specialty : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Doctor> Doctors { get; private set; } = new List<Doctor>();

        public Specialty()
        {
            
        }

        public Specialty(string name, string description ,IEnumerable<Doctor> doctors)
        {
            Name = name;
            Doctors = doctors;
            Description = description;
        }


        public void ChangeName(string name) { 
            Name = name;
        }
        public void ChangeDescription(string description) { 
            Description = description;
        }
    }
}
