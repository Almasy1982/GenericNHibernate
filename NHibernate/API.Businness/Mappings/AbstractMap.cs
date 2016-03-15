using FluentNHibernate.Mapping;

namespace UoW.Core.Mappings
{
    public class AbstractMap<T> : ClassMap<T>
    {
        public AbstractMap()
        {
            DynamicUpdate();
        }
    }
}
