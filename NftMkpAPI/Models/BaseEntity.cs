using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NftMkpAPI.Models;

public class BaseEntity
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
}
