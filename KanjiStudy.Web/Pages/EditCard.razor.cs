using KanjiStudy.Core.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using KanjiStudy.Web.Helpers;

namespace KanjiStudy.Web.Pages
{
    public partial class EditCard
    {
        [Inject] public virtual LocalStore LocalStore { get; set; }
        [Inject] public virtual RtkImportHelper ImportHelper { get; set; }
        [Inject] public virtual NavigationManager NavManager { get; set; }
        [Parameter] public string Id { get; set; }
        private RTKItem Item { get; set; }
        readonly CardModel _cardModel = new();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
                await LoadExistingCard(Id);
        }

        private async Task LoadExistingCard(string id)
        {
            Item = await LocalStore.GetCardById(id);
            if (Item != null)
            {
                _cardModel.Number = Item.Number;
                _cardModel.NumberStrokes = Item.NumberStrokes;
                _cardModel.Kanji = Item.Kanji;
                _cardModel.Story = Item.Story;
                _cardModel.Notes = Item.Notes;
                _cardModel.EnglishMeaning = Item.EnglishMeaning;
            }
        }
        
        private async Task HandleValidSubmit()
        {
            if (Item != null)
            {
                Item.Number = _cardModel.Number;
                Item.NumberStrokes = _cardModel.NumberStrokes;
                Item.EnglishMeaning = _cardModel.EnglishMeaning;
                Item.Kanji = _cardModel.Kanji;
                Item.Story = _cardModel.Story;
                Item.Notes = _cardModel.Notes;
                await LocalStore.UpdateCardAsync(Item);
            }
            else
            {
                Item = new RTKItem
                {
                    _id = Guid.NewGuid().ToString(),
                    Number = _cardModel.Number,
                    NumberStrokes = _cardModel.NumberStrokes,
                    EnglishMeaning = _cardModel.EnglishMeaning,
                    Kanji = _cardModel.Kanji,
                    Story = _cardModel.Story,
                    Notes = _cardModel.Notes,
                    CorrectReviewStreak = 0,
                    DifficultyRating = 100,
                    PreviousCorrectReview = DateTime.MinValue,
                    ReviewDate = DateTime.MinValue
                };
                await LocalStore.AddCardAsync(Item);
            }
            NavManager.NavigateTo("cards");
        }

        private void OnNumberChange(ChangeEventArgs args)
        {
            var number = (string)args.Value;
            _cardModel.Number = number;
            var item = ImportHelper.GetRtkImportItem(number);

            if (item != null)
            {
                _cardModel.Kanji = item.Character;
                _cardModel.NumberStrokes = item.StrokeCount;
                _cardModel.EnglishMeaning = item.Keyword;
                _cardModel.Notes = item.Primitive ? "Primitive" : "";

            }
        }
    }
}