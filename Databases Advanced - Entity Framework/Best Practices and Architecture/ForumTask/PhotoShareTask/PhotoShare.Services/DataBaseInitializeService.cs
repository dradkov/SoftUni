namespace PhotoShare.Services
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Services.Contracts;
    public class DataBaseInitializeService : IDataBaseInitializeServise
    {
        private readonly PhotoShareContext context;

        public DataBaseInitializeService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            //this.context.Database.Migrate();
        }
    }
}
