using KanjiStudy.SRS;
using KanjiStudy.SRS.Models;
namespace KanjiStudy.Web.Pages
{
    public partial class Study
    {
        private bool sessionResult = false;
        StudySession _session = new StudySession();
        RTKItem currentItem;
        RTKItem previousItem;
        private void StartStudySession()
        {
            var item1 = new RTKItem
            {
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
            var item2 = new RTKItem
            {
                Number = 0,
                NumberStrokes = 0,
                EnglishMeaning = "In",
                Kanji = "O",
                Story = "in an item",
                Notes = "No Notes Yet",
                CorrectReviewStreak = 0,
                DifficultyRating = 100,
                PreviousCorrectReview = System.DateTime.MinValue,
                ReviewDate = System.DateTime.MinValue
            };
            var items = new[] { item1, item2 };
            sessionResult = _session.StartStudySession(items);
            currentItem = _session.GetNextItem();
        }
        private void ReviewItem()
        {
            var reviewedItem = _session.ReviewItem(currentItem, SpacedRepetition.Net.ReviewOutcome.Perfect);
            previousItem = reviewedItem;
            currentItem = _session.GetNextItem();
        }
    }
}