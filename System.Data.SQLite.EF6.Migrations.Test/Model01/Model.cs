using System;
using System.ComponentModel.DataAnnotations;

namespace System.Data.SQLite.EF6.Migrations.Test.Model01
{
    class Entity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
    }

    class Dependant
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public virtual Entity MainEntity { get; set; }
    }

}
