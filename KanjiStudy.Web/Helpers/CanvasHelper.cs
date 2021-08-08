using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace KanjiStudy.Web.Helpers
{
    public class CanvasHelper
    {
        private readonly IJSRuntime _js;
        public CanvasHelper(IJSRuntime js)
        {
            this._js = js;
        }

        public async void CreateCanvasElement(string id)
        {
            await _js.InvokeVoidAsync("createCanvasElement", id);
        }
        
        public async void ClearCanvasElement(string id)
        {
            await _js.InvokeVoidAsync("clearCanvasElement", id);
        }

        public async Task<string> GetCanvasValue(string id)
        {
            return await _js.InvokeAsync<string>("getCanvasContent", id);
        }
    }
}
