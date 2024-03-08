using Microsoft.EntityFrameworkCore;

namespace petstore_vetclinic_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
