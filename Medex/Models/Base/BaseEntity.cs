using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Models.Base
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
    }
}
