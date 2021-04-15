using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcardgenerator.Models.Localhost
{
  [Table("categories")]
  public partial class Category
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int categoryId
    {
      get;
      set;
    }

    public ICollection<Card> Cards { get; set; }
    [ConcurrencyCheck]
    public string name
    {
      get;
      set;
    }
  }
}
