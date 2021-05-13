using Microsoft.EntityFrameworkCore;

namespace Project.Data.Mapping
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
