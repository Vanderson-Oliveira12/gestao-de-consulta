using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestaoDeConsulta.Models
{
    public class Patient : Base
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CPF { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }

        public Patient() { }

        public Patient(string name, DateTime dateOfBirth, string cPF, string address, string phone, string email)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CPF = cPF;
            Address = address;
            Phone = phone;
            Email = email;
        }
        public void ChangeCPF(string cPF) {
            CPF = cPF;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void changeDateOfBirth(DateTime date)
        {
            DateOfBirth = date;
        }
        public void ChangeAddress(string address)
        {
            Address = address;
        }
        public void ChangePhone(string phone)
        {
            Phone = phone;
        }

    }
}
