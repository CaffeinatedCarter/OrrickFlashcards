using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcardgenerator.Models.Localhost
{
  [Table("sentences")]
  public partial class Sentence
  {
    [ConcurrencyCheck]
    public int briefId
    {
      get;
      set;
    }
    public Brief Brief { get; set; }
    [ConcurrencyCheck]
    public string content
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int parseNum
    {
      get;
      set;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int sentenceId
    {
      get;
      set;
    }

    public ICollection<Card> Cards { get; set; }

    [Column("verified?")]
    [ConcurrencyCheck]
    public bool verified
    {
      get;
      set;
    }
  }
}
