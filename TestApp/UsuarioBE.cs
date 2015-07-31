using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp
{
    public class UsuarioBE
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("ESCASADO")]
        public bool EsCasado { get; set; }
        [Column("CREADOEL")]
        public DateTime CreadoEl { get; set; }
        [Column("VDECIMAL")]
        public decimal Vdecimal { get; set; }
        [Column("VDOUBLE")]
        public double Vdouble { get; set; }
        [Column("VLONG")]
        public long Vlong { get; set; }
    }
}
