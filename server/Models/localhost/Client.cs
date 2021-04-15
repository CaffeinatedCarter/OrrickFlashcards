using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcardgenerator.Models.Localhost
{
  [Table("clients")]
  public partial class Client
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int clientId
    {
      get;
      set;
    }

    public ICollection<Brief> Briefs { get; set; }
    [ConcurrencyCheck]
    public bool? isCurrent
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string longName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string shortName
    {
      get;
      set;
    }
  }
}
