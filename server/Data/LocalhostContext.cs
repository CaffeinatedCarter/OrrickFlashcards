using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Flashcardgenerator.Models.Localhost;

namespace Flashcardgenerator.Data
{
  public partial class LocalhostContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public LocalhostContext(DbContextOptions<LocalhostContext> options):base(options)
    {
    }

    public LocalhostContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Flashcardgenerator.Models.Localhost.Brief>()
              .HasOne(i => i.Client)
              .WithMany(i => i.Briefs)
              .HasForeignKey(i => i.clientId)
              .HasPrincipalKey(i => i.clientId);
        builder.Entity<Flashcardgenerator.Models.Localhost.Card>()
              .HasOne(i => i.Brief)
              .WithMany(i => i.Cards)
              .HasForeignKey(i => i.briefId)
              .HasPrincipalKey(i => i.briefId);
        builder.Entity<Flashcardgenerator.Models.Localhost.Card>()
              .HasOne(i => i.Category)
              .WithMany(i => i.Cards)
              .HasForeignKey(i => i.categoryId)
              .HasPrincipalKey(i => i.categoryId);
        builder.Entity<Flashcardgenerator.Models.Localhost.Card>()
              .HasOne(i => i.Sentence)
              .WithMany(i => i.Cards)
              .HasForeignKey(i => i.sentenceId)
              .HasPrincipalKey(i => i.sentenceId);
        builder.Entity<Flashcardgenerator.Models.Localhost.Sentence>()
              .HasOne(i => i.Brief)
              .WithMany(i => i.Sentences)
              .HasForeignKey(i => i.briefId)
              .HasPrincipalKey(i => i.briefId);

        this.OnModelBuilding(builder);
    }


    public DbSet<Flashcardgenerator.Models.Localhost.Brief> Briefs
    {
      get;
      set;
    }

    public DbSet<Flashcardgenerator.Models.Localhost.Card> Cards
    {
      get;
      set;
    }

    public DbSet<Flashcardgenerator.Models.Localhost.Category> Categories
    {
      get;
      set;
    }

    public DbSet<Flashcardgenerator.Models.Localhost.Client> Clients
    {
      get;
      set;
    }

    public DbSet<Flashcardgenerator.Models.Localhost.Sentence> Sentences
    {
      get;
      set;
    }
  }
}
