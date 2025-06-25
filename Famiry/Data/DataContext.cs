using FamiryEntityLibrary;
using System.Text.RegularExpressions;
using FamiryEntityLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Famiry.Data
{
    public class DataContext(BaseConfiguration configuration) : DbContext
    {
        private BaseConfiguration Configuration { get; } = configuration;

        /// <summary>
        ///     Обработать настройку сессии.
        /// </summary>
        /// <param name="optionsBuilder">Набор интерфейсов настройки сессии.</param>
        /// <exception cref="Exception">При ошибке подключения.</exception>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration.ConfigureContext(optionsBuilder);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Попытаться асинхронно инициализировать сессию.
        ///     Используется для проверки подключения
        ///     и инициализации структуры таблиц.
        /// </summary>
        /// <returns>Статус успешности инициализации.</returns>
        public async Task<bool> TryInitializeAsync()
        {
            try
            {
                await Database.MigrateAsync();
                return await Database.CanConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Migration failed: {ex}");
                return false;
            }
        }

        /// <summary>
        ///     Обработать инициализацию модели.
        ///     Используется для дополнительной настройки модели.
        /// </summary>
        /// <param name="modelBuilder">Набор интерфейсов настройки модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Event.Configuration(Configuration));
            modelBuilder.ApplyConfiguration(new Comment.Configuration(Configuration));
            modelBuilder.ApplyConfiguration(new User.Configuration(Configuration));
            modelBuilder.ApplyConfiguration(new Photo.Configuration(Configuration));


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Groups => Set<Event>();
        public DbSet<Comment> Plants => Set<Comment>();
        public DbSet<User> GrowStagrowStages => Set<User>();
        public DbSet<Photo> LightNeeds => Set<Photo>();
    }
}
