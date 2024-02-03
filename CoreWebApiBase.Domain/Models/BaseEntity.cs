using System.ComponentModel.DataAnnotations;

namespace CoreWebApiBase.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}