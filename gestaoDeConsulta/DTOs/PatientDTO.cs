namespace gestaoDeConsulta.DTOs
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public PatientDTO()
        {
            
        }
        public PatientDTO(string name, string email, DateTime dateOfBirth, string cPF, string address, string phone)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            CPF = cPF;
            Address = address;
            Phone = phone;
        }
    }
}
