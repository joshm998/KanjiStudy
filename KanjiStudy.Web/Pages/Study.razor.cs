using System;
using System.Collections.Generic;
using System.Linq;
using KanjiStudy.Core;
using KanjiStudy.Core.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using SpacedRepetition.Net;
using System.Threading.Tasks;
using KanjiStudy.Web.Helpers;

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
        private string _canvasData = "";
        private string _sidebarStyle = "width: 0%;";
        private List<RTKItem> _queue;
        RTKItem _currentItem;
        
        protected override async Task OnInitializedAsync()
        {
            GetItemQueue();
        }

        private async void GetItemQueue()
        {
            var items = await LocalStore.GetCardsAsync();
            _queue = items.Where(e => e.ReviewDate <= DateTime.Now).ToList();
            StateHasChanged();
        }
        
        private async Task StartStudySession()
        {
            var stats = await LocalStore.GetStatsAsync();
            var todayStats = stats.FirstOrDefault();
            if (todayStats == null)
            {
                todayStats = new StudyStats()
                {
                    _id = DateTime.UtcNow.Date,
                    CardsAnswered = 0,
                    IncorrectAnswers = 0,
                    PerfectAnswers = 0,
                    HesitantAnswers = 0,
                    NeverReviewedAnswers = 0
                };
                await LocalStore.AddStatsAsync(todayStats);
            }
            _sessionResult = Session.StartStudySession(StudyConfig.Settings, _queue, todayStats);
            _currentItem = Session.GetNextItem();
        }
        private async void ReviewItem(ReviewOutcome outcome)
        {
            var reviewedItem = Session.ReviewItem(_currentItem, outcome);
            await LocalStore.UpdateCardAsync(reviewedItem);
            _currentItem = Session.GetNextItem();
            _sidebarStyle = $"width: {Session.PercentComplete}%";
            await LocalStore.UpdateStatsAsync(Session.SessionStats);
            _flippedCard = false;
            StateHasChanged();
        }
        private void FlipCard()
        {
            _flippedCard = !_flippedCard;
            StateHasChanged();
        }

        private void CanvasValueChanged(string value)
        {
            _canvasData = value;
        }
    }
} 