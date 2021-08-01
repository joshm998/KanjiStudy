using KanjiStudy.SRS.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Data
{
    public class LocalCardStore
    {
        private readonly IJSRuntime js;
        public LocalCardStore(IJSRuntime js)
        {
            this.js = js;
        }

        public ValueTask<RTKItem[]> GetCardsAsync()
        {
            return js.InvokeAsync<RTKItem[]>(
                "localCardStore.getAll", "cardstore");
        }

        public ValueTask SaveVehicleAsync(RTKItem vehicle)
            => PutAsync("cardstore", null, vehicle);

        ValueTask PutAsync<T>(string storeName, object key, T value)
            => js.InvokeVoidAsync("localCardStore.put", storeName, key, value);
    }
}
