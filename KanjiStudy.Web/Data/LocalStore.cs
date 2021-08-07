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
        }

        public ValueTask<RTKItem[]> GetCardsAsync()
        {
            return GetAllAsync<RTKItem>("cardstore");
        }

        public ValueTask SaveCardAsync(RTKItem card)
            => PutAsync("cardstore", null, card);
        
        public ValueTask<StudyStats[]> GetStatsAsync()
        {
            return GetAllAsync<StudyStats>("statstore");
        }
        
        public ValueTask SaveStatsAsync(StudyStats stats)
            => PutAsync("statstore", null, stats);

        ValueTask PutAsync<T>(string storeName, object key, T value)
            => js.InvokeVoidAsync("localCardStore.put", storeName, key, value);
        
        ValueTask<T[]> GetAllAsync<T>(string storeName)
            => js.InvokeAsync<T[]>("localCardStore.getAll", storeName);
    }
}
