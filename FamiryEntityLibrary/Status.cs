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
    [Table(nameof(Status))]
    public class Status : IdentifiableEntity
    {
        /// <summary>
        ///     Конфигурация модели <see cref="Subject" />.
        /// </summary>
        /// <param name="configuration">Конфигурация базы данных.</param>
        public class Configuration(BaseConfiguration configuration) : Configuration<Status>(configuration)
        {
            /// <summary>
            ///     Задать конфигурацию для модели.
            /// </summary>
            /// <param name="builder">Набор интерфейсов настройки модели.</param>
            public override void Configure(EntityTypeBuilder<Status> builder)
            {
                base.Configure(builder);
            }
        }
        public List<Event> Events { get; set; }
        public string Name { get; set; }
    }
}
