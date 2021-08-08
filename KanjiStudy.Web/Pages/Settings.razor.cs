using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class Settings
    {
        [Inject]
        private StudyConfig StudyConfig { get; set; }
        
        [Inject]
        private NavigationManager NavManager { get; set; }

        private SessionConfig _settingsModel = new();
        private void HandleValidSubmit()
        {
            var settings = new SessionConfig()
            {
                MaxExistingCards = _settingsModel.MaxExistingCards,
                MaxNewCards = _settingsModel.MaxNewCards
            };

            StudyConfig.SaveSettings(settings);
        }

        protected override async Task OnInitializedAsync()
        {
            _settingsModel = StudyConfig.Settings;
        }
    }
}