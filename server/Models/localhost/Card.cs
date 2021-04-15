using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcardgenerator.Models.Localhost
{
  [Table("cards")]
  public partial class Card
  {
    [ConcurrencyCheck]
    public string Answer
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int briefId
    {
      get;
      set;
    }
    public Brief Brief { get; set; }
    [Key]
    public int cardId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? categoryId
    {
      get;
      set;
    }
    public Category Category { get; set; }
    [ConcurrencyCheck]
    public string Question
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? sentenceId
    {
      get;
      set;
    }
    public Sentence Sentence { get; set; }
    [ConcurrencyCheck]
    public bool? Verified
    {
      get;
      set;
    }
  }
}
