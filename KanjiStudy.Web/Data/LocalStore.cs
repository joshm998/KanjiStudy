using KanjiStudy.SRS.Models;
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

        public ValueTask SaveCardAsync(RTKItem card)
            => AddAsync("card", card);
        
        public ValueTask<StudyStats[]> GetStatsAsync()
        {
            return GetAllAsync<StudyStats>("stat");
        }
        
        public ValueTask SaveStatsAsync(StudyStats stats)
            => AddAsync("stat", stats);

        ValueTask AddAsync<T>(string objectType, T value)
            => js.InvokeVoidAsync("pouchDb.add", value, objectType);
        
        ValueTask UpdateAsync<T>(T value)
            => js.InvokeVoidAsync("pouchDb.update", value);
        
        ValueTask<T[]> GetAllAsync<T>(string objectType)
            => js.InvokeAsync<T[]>("pouchDb.getByType", objectType);
        
        private ValueTask GenerateIndexAsync()
            => js.InvokeVoidAsync("pouchDb.generateIndex");
    }
}
