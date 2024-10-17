using System.ComponentModel.DataAnnotations;

namespace gestaoDeConsulta.Models
{
    public abstract class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
