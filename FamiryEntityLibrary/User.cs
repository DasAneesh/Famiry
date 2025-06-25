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
    [Table(nameof(User))]

    public class User: IdentifiableEntity

    {

        public class Configuration(BaseConfiguration configuration) : Configuration<User>(configuration)
        {
            /// <summary>
            ///     Задать конфигурацию для модели.
            /// </summary>
            /// <param name="builder">Набор интерфейсов настройки модели.</param>
            public override void Configure(EntityTypeBuilder<User> builder)
            {

                base.Configure(builder);
            }
        }
        public string Name { get; set; } = "";
        public string Surname{ get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
