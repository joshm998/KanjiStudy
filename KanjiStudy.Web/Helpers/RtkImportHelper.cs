using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using KanjiStudy.SRS.Models;

namespace KanjiStudy.Web.Helpers
{
    public class RtkImportHelper
    {
        private readonly HttpClient _http;
        private RTKImport[] ImportIndex;
        public RtkImportHelper(HttpClient http)
        {
            _http = http;
            GetRtkImportFiles();
        }

        private async void GetRtkImportFiles()
        {
            ImportIndex = await _http.GetFromJsonAsync<RTKImport[]>("data/rtk/heisig.json");
        }

        public RTKImport GetRtkImportItem(string number)
        {
            return ImportIndex.FirstOrDefault(e => e.Number == number);
        }
    }
}