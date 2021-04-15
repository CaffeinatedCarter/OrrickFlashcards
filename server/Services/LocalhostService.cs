using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Flashcardgenerator.Data;

namespace Flashcardgenerator
{
    public partial class LocalhostService
    {
        LocalhostContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly LocalhostContext context;
        private readonly NavigationManager navigationManager;

        public LocalhostService(LocalhostContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportBriefsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/briefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/briefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBriefsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/briefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/briefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBriefsRead(ref IQueryable<Models.Localhost.Brief> items);

        public async Task<IQueryable<Models.Localhost.Brief>> GetBriefs(Query query = null)
        {
            var items = Context.Briefs.AsQueryable();

            items = items.Include(i => i.Client);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBriefsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBriefCreated(Models.Localhost.Brief item);
        partial void OnAfterBriefCreated(Models.Localhost.Brief item);

        public async Task<Models.Localhost.Brief> CreateBrief(Models.Localhost.Brief brief)
        {
            OnBriefCreated(brief);

            Context.Briefs.Add(brief);
            Context.SaveChanges();

            OnAfterBriefCreated(brief);

            return brief;
        }
        public async Task ExportCardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/cards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/cards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/cards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/cards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCardsRead(ref IQueryable<Models.Localhost.Card> items);

        public async Task<IQueryable<Models.Localhost.Card>> GetCards(Query query = null)
        {
            var items = Context.Cards.AsQueryable();

            items = items.Include(i => i.Brief);

            items = items.Include(i => i.Category);

            items = items.Include(i => i.Sentence);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCardCreated(Models.Localhost.Card item);
        partial void OnAfterCardCreated(Models.Localhost.Card item);

        public async Task<Models.Localhost.Card> CreateCard(Models.Localhost.Card card)
        {
            OnCardCreated(card);

            Context.Cards.Add(card);
            Context.SaveChanges();

            OnAfterCardCreated(card);

            return card;
        }
        public async Task ExportCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/categories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/categories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/categories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/categories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCategoriesRead(ref IQueryable<Models.Localhost.Category> items);

        public async Task<IQueryable<Models.Localhost.Category>> GetCategories(Query query = null)
        {
            var items = Context.Categories.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCategoryCreated(Models.Localhost.Category item);
        partial void OnAfterCategoryCreated(Models.Localhost.Category item);

        public async Task<Models.Localhost.Category> CreateCategory(Models.Localhost.Category category)
        {
            OnCategoryCreated(category);

            Context.Categories.Add(category);
            Context.SaveChanges();

            OnAfterCategoryCreated(category);

            return category;
        }
        public async Task ExportClientsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/clients/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/clients/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClientsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/clients/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/clients/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClientsRead(ref IQueryable<Models.Localhost.Client> items);

        public async Task<IQueryable<Models.Localhost.Client>> GetClients(Query query = null)
        {
            var items = Context.Clients.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClientsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClientCreated(Models.Localhost.Client item);
        partial void OnAfterClientCreated(Models.Localhost.Client item);

        public async Task<Models.Localhost.Client> CreateClient(Models.Localhost.Client client)
        {
            OnClientCreated(client);

            Context.Clients.Add(client);
            Context.SaveChanges();

            OnAfterClientCreated(client);

            return client;
        }
        public async Task ExportSentencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/sentences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/sentences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSentencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/localhost/sentences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/localhost/sentences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSentencesRead(ref IQueryable<Models.Localhost.Sentence> items);

        public async Task<IQueryable<Models.Localhost.Sentence>> GetSentences(Query query = null)
        {
            var items = Context.Sentences.AsQueryable();

            items = items.Include(i => i.Brief);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSentencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSentenceCreated(Models.Localhost.Sentence item);
        partial void OnAfterSentenceCreated(Models.Localhost.Sentence item);

        public async Task<Models.Localhost.Sentence> CreateSentence(Models.Localhost.Sentence sentence)
        {
            OnSentenceCreated(sentence);

            Context.Sentences.Add(sentence);
            Context.SaveChanges();

            OnAfterSentenceCreated(sentence);

            return sentence;
        }

        partial void OnBriefDeleted(Models.Localhost.Brief item);
        partial void OnAfterBriefDeleted(Models.Localhost.Brief item);

        public async Task<Models.Localhost.Brief> DeleteBrief(int? briefId)
        {
            var itemToDelete = Context.Briefs
                              .Where(i => i.briefId == briefId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBriefDeleted(itemToDelete);

            Context.Briefs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBriefDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBriefGet(Models.Localhost.Brief item);

        public async Task<Models.Localhost.Brief> GetBriefBybriefId(int? briefId)
        {
            var items = Context.Briefs
                              .AsNoTracking()
                              .Where(i => i.briefId == briefId);

            items = items.Include(i => i.Client);

            var itemToReturn = items.FirstOrDefault();

            OnBriefGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Localhost.Brief> CancelBriefChanges(Models.Localhost.Brief item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnBriefUpdated(Models.Localhost.Brief item);
        partial void OnAfterBriefUpdated(Models.Localhost.Brief item);

        public async Task<Models.Localhost.Brief> UpdateBrief(int? briefId, Models.Localhost.Brief brief)
        {
            OnBriefUpdated(brief);

            var itemToUpdate = Context.Briefs
                              .Where(i => i.briefId == briefId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(brief);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterBriefUpdated(brief);

            return brief;
        }

        partial void OnCardDeleted(Models.Localhost.Card item);
        partial void OnAfterCardDeleted(Models.Localhost.Card item);

        public async Task<Models.Localhost.Card> DeleteCard(int? cardId)
        {
            var itemToDelete = Context.Cards
                              .Where(i => i.cardId == cardId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCardDeleted(itemToDelete);

            Context.Cards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCardDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCardGet(Models.Localhost.Card item);

        public async Task<Models.Localhost.Card> GetCardBycardId(int? cardId)
        {
            var items = Context.Cards
                              .AsNoTracking()
                              .Where(i => i.cardId == cardId);

            items = items.Include(i => i.Brief);

            items = items.Include(i => i.Category);

            items = items.Include(i => i.Sentence);

            var itemToReturn = items.FirstOrDefault();

            OnCardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Localhost.Card> CancelCardChanges(Models.Localhost.Card item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCardUpdated(Models.Localhost.Card item);
        partial void OnAfterCardUpdated(Models.Localhost.Card item);

        public async Task<Models.Localhost.Card> UpdateCard(int? cardId, Models.Localhost.Card card)
        {
            OnCardUpdated(card);

            var itemToUpdate = Context.Cards
                              .Where(i => i.cardId == cardId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(card);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCardUpdated(card);

            return card;
        }

        partial void OnCategoryDeleted(Models.Localhost.Category item);
        partial void OnAfterCategoryDeleted(Models.Localhost.Category item);

        public async Task<Models.Localhost.Category> DeleteCategory(int? categoryId)
        {
            var itemToDelete = Context.Categories
                              .Where(i => i.categoryId == categoryId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCategoryDeleted(itemToDelete);

            Context.Categories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCategoryDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCategoryGet(Models.Localhost.Category item);

        public async Task<Models.Localhost.Category> GetCategoryBycategoryId(int? categoryId)
        {
            var items = Context.Categories
                              .AsNoTracking()
                              .Where(i => i.categoryId == categoryId);

            var itemToReturn = items.FirstOrDefault();

            OnCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Localhost.Category> CancelCategoryChanges(Models.Localhost.Category item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCategoryUpdated(Models.Localhost.Category item);
        partial void OnAfterCategoryUpdated(Models.Localhost.Category item);

        public async Task<Models.Localhost.Category> UpdateCategory(int? categoryId, Models.Localhost.Category category)
        {
            OnCategoryUpdated(category);

            var itemToUpdate = Context.Categories
                              .Where(i => i.categoryId == categoryId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(category);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCategoryUpdated(category);

            return category;
        }

        partial void OnClientDeleted(Models.Localhost.Client item);
        partial void OnAfterClientDeleted(Models.Localhost.Client item);

        public async Task<Models.Localhost.Client> DeleteClient(int? clientId)
        {
            var itemToDelete = Context.Clients
                              .Where(i => i.clientId == clientId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClientDeleted(itemToDelete);

            Context.Clients.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClientDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClientGet(Models.Localhost.Client item);

        public async Task<Models.Localhost.Client> GetClientByclientId(int? clientId)
        {
            var items = Context.Clients
                              .AsNoTracking()
                              .Where(i => i.clientId == clientId);

            var itemToReturn = items.FirstOrDefault();

            OnClientGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Localhost.Client> CancelClientChanges(Models.Localhost.Client item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnClientUpdated(Models.Localhost.Client item);
        partial void OnAfterClientUpdated(Models.Localhost.Client item);

        public async Task<Models.Localhost.Client> UpdateClient(int? clientId, Models.Localhost.Client client)
        {
            OnClientUpdated(client);

            var itemToUpdate = Context.Clients
                              .Where(i => i.clientId == clientId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(client);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterClientUpdated(client);

            return client;
        }

        partial void OnSentenceDeleted(Models.Localhost.Sentence item);
        partial void OnAfterSentenceDeleted(Models.Localhost.Sentence item);

        public async Task<Models.Localhost.Sentence> DeleteSentence(int? sentenceId)
        {
            var itemToDelete = Context.Sentences
                              .Where(i => i.sentenceId == sentenceId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSentenceDeleted(itemToDelete);

            Context.Sentences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSentenceDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSentenceGet(Models.Localhost.Sentence item);

        public async Task<Models.Localhost.Sentence> GetSentenceBysentenceId(int? sentenceId)
        {
            var items = Context.Sentences
                              .AsNoTracking()
                              .Where(i => i.sentenceId == sentenceId);

            items = items.Include(i => i.Brief);

            var itemToReturn = items.FirstOrDefault();

            OnSentenceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Localhost.Sentence> CancelSentenceChanges(Models.Localhost.Sentence item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSentenceUpdated(Models.Localhost.Sentence item);
        partial void OnAfterSentenceUpdated(Models.Localhost.Sentence item);

        public async Task<Models.Localhost.Sentence> UpdateSentence(int? sentenceId, Models.Localhost.Sentence sentence)
        {
            OnSentenceUpdated(sentence);

            var itemToUpdate = Context.Sentences
                              .Where(i => i.sentenceId == sentenceId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(sentence);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterSentenceUpdated(sentence);

            return sentence;
        }
    }
}
