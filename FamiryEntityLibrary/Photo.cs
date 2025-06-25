using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamiryEntityLibrary
{
    [Table(nameof(Photo))]
    public class Photo: IdentifiableEntity
    {
        /// <summary>
        ///     Конфигурация модели <see cref="Subject" />.
        /// </summary>
        /// <param name="configuration">Конфигурация базы данных.</param>
        public class Configuration(BaseConfiguration configuration) : Configuration<Photo>(configuration)
        {
            /// <summary>
            ///     Задать конфигурацию для модели.
            /// </summary>
            /// <param name="builder">Набор интерфейсов настройки модели.</param>
            public override void Configure(EntityTypeBuilder<Photo> builder)
            {
                builder.HasOne(photo => photo.Event)
                    .WithMany(@event => @event.Photos)
                    .HasForeignKey(photo => photo.EventId);

                base.Configure(builder);
            }
        }
        public int UserId { get; set; }
        public string Status { get; set; } = "";
        public DateTime PostTime { get; set; }    
        public int EventId { get; set; }

        public Event? Event { get; set; }
    }
}
