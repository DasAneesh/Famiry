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
    [Table(nameof(Comment))]
    public class Comment: IdentifiableEntity
    {
        /// <summary>
        ///     Конфигурация модели <see cref="Subject" />.
        /// </summary>
        /// <param name="configuration">Конфигурация базы данных.</param>
        public class Configuration(BaseConfiguration configuration) : Configuration<Comment>(configuration)
        {
            /// <summary>
            ///     Задать конфигурацию для модели.
            /// </summary>
            /// <param name="builder">Набор интерфейсов настройки модели.</param>
            public override void Configure(EntityTypeBuilder<Comment> builder)
            {
                builder.HasOne(comment => comment.Event)
                    .WithMany(@event => @event.Comments)
                    .HasForeignKey(comment => comment.EventId);

                base.Configure(builder);
            }
        }
        public int UserId { get; set; }
        public string Status { get; set; } = "";
        public string Decription { get; set; } = "";
        public DateTime PostTime { get; set; }
        
        public int EventId { get; set; }
        public Event? Event { get; set; }

    }
}
