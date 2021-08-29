using SpacedRepetition.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using KanjiStudy.Core.Models;

namespace KanjiStudy.Core
{
    public class StudySession
    {
        private StudySession<RTKItem> _studySession;
        private List<RTKItem> _itemQueue;
        public StudyStats SessionStats;
        public int CardCount = 0;
        public int CardsAnswered = 0;
        public double PercentComplete = 0.0;
        public bool StartStudySession(SessionConfig config, IEnumerable<RTKItem> items, StudyStats stats)
        {
            _studySession = new StudySession<RTKItem>(items)
            {
                MaxExistingCards = config.MaxExistingCards,
                MaxNewCards = config.MaxNewCards
            };
            SessionStats = stats;
            _itemQueue = items.ToList();
            CardCount = _itemQueue.Count;
            return true;
        }

        public RTKItem GetNextItem()
        {
            var nextItem = _itemQueue.FirstOrDefault();
            _itemQueue.Remove(nextItem);
            return nextItem;
        }
        
        public RTKItem ReviewItem(RTKItem item, ReviewOutcome outcome)
        {
            var reviewItem = _studySession.Review(item, outcome);
            item.ReviewDate = _studySession.ReviewStrategy.NextReview(reviewItem);
            item.PreviousCorrectReview = reviewItem.PreviousCorrectReview;
            item.CorrectReviewStreak = reviewItem.CorrectReviewStreak;
            item.DifficultyRating = reviewItem.DifficultyRating;
            SessionStats.CardsAnswered++;
            switch (outcome)
            {
                case ReviewOutcome.Hesitant:
                    SessionStats.HesitantAnswers++;
                    break;
                case ReviewOutcome.Incorrect:
                    SessionStats.IncorrectAnswers++;
                    break;
                case ReviewOutcome.Perfect:
                    SessionStats.PerfectAnswers++;
                    break;
                case ReviewOutcome.NeverReviewed:
                    SessionStats.NeverReviewedAnswers++;
                    break;
            }
            if (item.ReviewDate <= DateTime.Now) {
                _itemQueue.Add(item);
                CardCount++;
            }
            UpdateSessionStatus();
            return item;
        }

        private void UpdateSessionStatus()
        {
            CardsAnswered++;
            PercentComplete = Math.Round(((double) CardsAnswered / CardCount) * 100, 2);
        }
    }
}
