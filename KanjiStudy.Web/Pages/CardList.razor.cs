using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class CardList
    {
        [Inject]
        public virtual LocalStore LocalStore { get; set; }
        private RTKItem[] _items;
        private string _filterText = "";

        protected override async Task OnInitializedAsync()
        {
            _items = await LocalStore.GetCardsAsync();
        }

        RTKItem[] FilteredItems => _items != null ? _items
            .Where(e => 
            e.Kanji.ToLower().Contains(_filterText.ToLower()) ||
            e.EnglishMeaning.ToLower().Contains(_filterText.ToLower()))
            .ToArray() : _items;
    }
}