using KanjiStudy.SRS;
using KanjiStudy.SRS.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using SpacedRepetition.Net;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class Study
    {
        [Inject]
        public virtual LocalCardStore _localCardStore { get; set; }

        private bool sessionResult = false;
        private bool flippedCard = false;
        StudySession _session = new StudySession();
        RTKItem currentItem;
        private async Task StartStudySession()
        {
            var items = await _localCardStore.GetCardsAsync();
            sessionResult = _session.StartStudySession(items);
            currentItem = _session.GetNextItem();
        }
        private async void ReviewItem(ReviewOutcome outcome)
        {
            var reviewedItem = _session.ReviewItem(currentItem, outcome);
            await _localCardStore.SaveCardAsync(reviewedItem);
            currentItem = _session.GetNextItem();
            flippedCard = false;
            StateHasChanged();
        }
        private void FlipCard()
        {
            flippedCard = !flippedCard;
        }
    }
} 