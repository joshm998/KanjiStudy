using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class Stats
    {
        [Inject]
        public virtual LocalCardStore _localCardStore { get; set; }
        public RTKItem[] stats;

        protected override async Task OnInitializedAsync()
        {
            stats = await _localCardStore.GetCardsAsync();
        }
    }
}