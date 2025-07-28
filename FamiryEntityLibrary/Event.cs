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
    [Table(nameof(Event))]
    public class Event : IdentifiableEntity
    {

        /// <summary>
        ///     Конфигурация модели <see cref="Subject" />.
        /// </summary>
        /// <param name="configuration">Конфигурация базы данных.</param>
        public class Configuration(BaseConfiguration configuration) : Configuration<Event>(configuration)
        {
            /// <summary>
            ///     Задать конфигурацию для модели.
            /// </summary>
            /// <param name="builder">Набор интерфейсов настройки модели.</param>
            public override void Configure(EntityTypeBuilder<Event> builder)
            {
                builder.HasOne(e => e.Priority).WithMany(p => p.Events).HasForeignKey(e => e.PriorityId);
                builder.HasOne(e => e.Status).WithMany(p => p.Events).HasForeignKey(e => e.StatusId);
                builder.HasOne(e => e.Type).WithMany(p => p.Events).HasForeignKey(e => e.TypeId);
                base.Configure(builder);
            }
        }

        public string Name { get; set; } = "";
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public Priority Priority { get; set; }

        public int PriorityId { get; set; }

        public Status Status { get; set; }

        public int StatusId { get; set; }

        public Type Type { get; set; }

        public int TypeId { get; set; }

        public List<Comment>? Comments { get; set; }
        public List<Photo>? Photos { get; set; }


    }
}
