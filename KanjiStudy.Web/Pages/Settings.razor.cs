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
        public virtual LocalCardStore _localCardStore { get; set; }
        public RTKItem[] settings;

        protected override async Task OnInitializedAsync()
        {
            settings = await _localCardStore.GetCardsAsync();
        }
    }
}