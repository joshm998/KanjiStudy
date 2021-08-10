using KanjiStudy.Core.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Data
{
    public class LocalStore
    {
        private readonly IJSRuntime js;
        public LocalStore(IJSRuntime js)
        {
            this.js = js;
            GenerateIndexAsync();
        }

        public ValueTask<RTKItem[]> GetCardsAsync()
        {
            return GetAllAsync<RTKItem>("card");
        }
        
        public ValueTask<RTKItem> GetCardById(string id)
        {
            return GetById<RTKItem>(id);
        }

        public ValueTask AddCardAsync(RTKItem card)
            => AddAsync("card", card);
        
        public ValueTask UpdateCardAsync(RTKItem card)
            => UpdateAsync(card);
        
        public ValueTask<StudyStats[]> GetStatsAsync()
        {
            return GetAllAsync<StudyStats>("stat");
        }
        
        public ValueTask AddStatsAsync(StudyStats stats)
            => AddAsync("stat", stats);
        public ValueTask UpdateStatsAsync(StudyStats stats)
            => UpdateAsync(stats);

        ValueTask AddAsync<T>(string objectType, T value)
            => js.InvokeVoidAsync("pouchDb.add", value, objectType);
        
        ValueTask UpdateAsync<T>(T value)
            => js.InvokeVoidAsync("pouchDb.update", value);
        
        ValueTask<T[]> GetAllAsync<T>(string objectType)
            => js.InvokeAsync<T[]>("pouchDb.getByType", objectType);
        
        ValueTask<T> GetById<T>(string id)
            => js.InvokeAsync<T>("pouchDb.getById", id);
        
        private ValueTask GenerateIndexAsync()
            => js.InvokeVoidAsync("pouchDb.generateIndex");
    }
}
