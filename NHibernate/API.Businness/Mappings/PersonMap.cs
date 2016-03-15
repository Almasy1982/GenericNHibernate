using UoW.Core.Repository;

namespace UoW.Core.Mappings
{
    public class PersonMap : AbstractMap<Person>
    {
        public PersonMap()
        {
            Id(c => c.Id);
            Map(c => c.Name);
        }
    }
}
