using System;
using System.Linq;
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
        private LocalStore LocalStore { get; set; }
        [Inject]
        private StudySession Session { get; set; }
        [Inject]
        private StudyConfig StudyConfig { get; set; }
        
        private bool _sessionResult = false;
        private bool _flippedCard = false;
        RTKItem _currentItem;
        
        private async Task StartStudySession()
        {
            var items = await LocalStore.GetCardsAsync();
            var stats = await LocalStore.GetStatsAsync();
            var e = stats.FirstOrDefault();
            if (e == null)
            {
                e = new StudyStats()
                {
                    Date = DateTime.UtcNow.Date,
                    CardsAnswered = 0,
                    IncorrectAnswers = 0,
                    PerfectAnswers = 0,
                    HesitantAnswers = 0,
                    NeverReviewedAnswers = 0
                };
            }
            
            _sessionResult = Session.StartStudySession(StudyConfig.Settings, items, e);
            _currentItem = Session.GetNextItem();
        }
        private async void ReviewItem(ReviewOutcome outcome)
        {
            var reviewedItem = Session.ReviewItem(_currentItem, outcome);
            await LocalStore.SaveCardAsync(reviewedItem);
            _currentItem = Session.GetNextItem();
            await LocalStore.SaveStatsAsync(Session.SessionStats);
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