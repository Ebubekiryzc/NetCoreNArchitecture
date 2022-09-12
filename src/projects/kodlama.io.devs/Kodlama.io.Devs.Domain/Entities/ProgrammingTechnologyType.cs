using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingTechnologyType : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public ProgrammingTechnologyType()
        {
        }

        public ProgrammingTechnologyType(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
