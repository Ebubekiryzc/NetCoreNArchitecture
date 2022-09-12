using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingTechnologyTypeId { get; set; }
        public string Name { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public virtual ProgrammingTechnologyType? ProgrammingTechnologyType { get; set; }

        public ProgrammingTechnology()
        {
        }

        public ProgrammingTechnology(int id, int programmingLanguageId, int programmingTechnologyTypeId, string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            ProgrammingTechnologyTypeId = programmingTechnologyTypeId;
        }
    }
}
