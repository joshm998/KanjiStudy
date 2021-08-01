

using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class Counter
    {
        [Inject]
        public virtual LocalCardStore LocalCardStore { get; set; }

        private int currentCount = 0;
        private int itemCount = 0;
        
        private void IncrementCount()
        {
            currentCount++;
        }
        async Task AddItem()
        {
            var item1 = new RTKItem
            {
                Id = Guid.NewGuid().ToString(),
                Number = 1,
                NumberStrokes = 0,
                EnglishMeaning = "Test",
                Kanji = "H",
                Story = "This is a test",
                Notes = "No Notes Yet",
                CorrectReviewStreak = 0,
                DifficultyRating = 100,
                PreviousCorrectReview = System.DateTime.MinValue,
                ReviewDate = System.DateTime.MinValue
            };
            
            await LocalCardStore.SaveCardAsync(item1);
        }
        async Task GetItems()
        {
            var items = await LocalCardStore.GetCardsAsync();
            itemCount = items.Length;
        }
    }
}