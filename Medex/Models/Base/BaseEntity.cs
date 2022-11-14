using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Models.Base
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}
