using System.Threading.Tasks;
using Blazored.LocalStorage;
using KanjiStudy.Core.Models;

namespace KanjiStudy.Web.Data
{
    public class StudyConfig
    {
        public SessionConfig Settings { get; set; }
        private ILocalStorageService LocalStorageService { get; set; }
        
        public StudyConfig(ILocalStorageService localStorage)
        {
            LocalStorageService = localStorage;
            LoadSettings();
        }

        public async void SaveSettings(SessionConfig settings)
        {
            Settings = settings;
            await LocalStorageService.SetItemAsync("settings", Settings);
        }

        private async void LoadSettings()
        {
            Settings = await LocalStorageService.GetItemAsync<SessionConfig>("settings");
            if (Settings == null)
            {
                Settings = new SessionConfig()
                {
                    MaxExistingCards = 100,
                    MaxNewCards = 25
                };
                await LocalStorageService.SetItemAsync("settings", Settings);
            }
        }
    }
}