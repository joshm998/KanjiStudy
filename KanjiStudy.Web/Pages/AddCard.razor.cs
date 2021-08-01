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
        public virtual LocalCardStore _localCardStore { get; set; }
        private CardModel cardModel = new();
        private string test;
        private async Task HandleValidSubmit()
        {
            var item1 = new RTKItem
            {
                Id = Guid.NewGuid().ToString(),
                Number = cardModel.Number,
                NumberStrokes = cardModel.NumberStrokes,
                EnglishMeaning = cardModel.EnglishMeaning,
                Kanji = cardModel.Kanji,
                Story = cardModel.Story,
                Notes = cardModel.Notes,
                CorrectReviewStreak = 0,
                DifficultyRating = 100,
                PreviousCorrectReview = System.DateTime.MinValue,
                ReviewDate = System.DateTime.MinValue
            };

            await _localCardStore.SaveCardAsync(item1);
        }
    }
}