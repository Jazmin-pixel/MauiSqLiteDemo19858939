
using SQLite;

namespace MauiSqLiteDemo19858939
{
    [Table("Cliente")]
    public class Cliente
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]

        public int Id { get; set; }

        [Column("nombrecliente")]
        public string NombreCliente { get; set; }

        [Column("movil")]
        public string Movil { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
