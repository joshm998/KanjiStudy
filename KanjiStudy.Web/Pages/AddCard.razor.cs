using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class AddCard
    {
        [Inject]
        public virtual LocalCardStore LocalCardStore { get; set; }
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

            await LocalCardStore.SaveCardAsync(newItem);
            NavManager.NavigateTo("/cards");
        }
    }
}