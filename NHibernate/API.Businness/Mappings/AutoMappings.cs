using FluentNHibernate.Cfg;

namespace UoW.Core.Mappings
{
    public class AutoMappings
    {
        public void ConfigureMappings(MappingConfiguration mappingConfiguration)
        {
            mappingConfiguration.FluentMappings.AddFromAssemblyOf<PersonMap>();
        }
    }
}