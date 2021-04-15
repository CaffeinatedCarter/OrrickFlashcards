using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcardgenerator.Models.Localhost
{
  [Table("briefs")]
  public partial class Brief
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int briefId
    {
      get;
      set;
    }

    public ICollection<Card> Cards { get; set; }
    public ICollection<Sentence> Sentences { get; set; }
    [ConcurrencyCheck]
    public string briefType
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int clientId
    {
      get;
      set;
    }
    public Client Client { get; set; }

    [Column("isTestBrief?")]
    [ConcurrencyCheck]
    public bool? isTestBrief
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string opposingParty
    {
      get;
      set;
    }
  }
}
