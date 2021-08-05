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
        public virtual LocalCardStore LocalCardStore { get; set; }
        
        [Inject]
        public virtual StudySession Session { get; set; }

        private bool _sessionResult = false;
        private bool _flippedCard = false;
        RTKItem _currentItem;
        private async Task StartStudySession()
        {
            var items = await LocalCardStore.GetCardsAsync();
            _sessionResult = Session.StartStudySession(items);
            _currentItem = Session.GetNextItem();
        }
        private async void ReviewItem(ReviewOutcome outcome)
        {
            var reviewedItem = Session.ReviewItem(_currentItem, outcome);
            await LocalCardStore.SaveCardAsync(reviewedItem);
            _currentItem = Session.GetNextItem();
            _flippedCard = false;
            StateHasChanged();
        }
        private void FlipCard()
        {
            _flippedCard = !_flippedCard;
            StateHasChanged();
        }
    }
} 