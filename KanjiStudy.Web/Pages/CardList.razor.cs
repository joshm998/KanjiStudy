using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class CardList
    {
        [Inject]
        public virtual LocalCardStore _localCardStore { get; set; }
        public RTKItem[] items;

        protected override async Task OnInitializedAsync()
        {
            items = await _localCardStore.GetCardsAsync();
        }
    }
}