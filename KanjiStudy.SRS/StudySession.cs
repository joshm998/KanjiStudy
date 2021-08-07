using KanjiStudy.SRS.Models;
using SpacedRepetition.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanjiStudy.SRS
{
    public class StudySession
    {
        private StudySession<RTKItem> _studySession;
        private List<RTKItem> _itemQueue;
        public bool StartStudySession(SessionConfig config, IEnumerable<RTKItem> items)
        {
            _studySession = new StudySession<RTKItem>(items);
            _studySession.MaxExistingCards = config.MaxExistingCards;
            _studySession.MaxNewCards = config.MaxNewCards;
            _itemQueue = items.ToList();
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
            item.ReviewDate = reviewItem.ReviewDate;
            item.PreviousCorrectReview = reviewItem.PreviousCorrectReview;
            item.CorrectReviewStreak = reviewItem.CorrectReviewStreak;
            item.DifficultyRating = reviewItem.DifficultyRating;
            return item;
        }

    }
    
}
