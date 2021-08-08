using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using KanjiStudy.Web.Helpers;

namespace KanjiStudy.Web.Pages
{
    public partial class AddCard
    {
        [Inject]
        public virtual LocalStore LocalStore { get; set; }
        [Inject]
        public virtual RtkImportHelper ImportHelper { get; set; }
        [Inject]
        public virtual NavigationManager NavManager { get; set; }
        readonly CardModel _cardModel = new();
        private async Task HandleValidSubmit()
        {
            var newItem = new RTKItem
            {
                Id = Guid.NewGuid().ToString(),
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

            await LocalStore.SaveCardAsync(newItem);
            NavManager.NavigateTo("/cards");
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