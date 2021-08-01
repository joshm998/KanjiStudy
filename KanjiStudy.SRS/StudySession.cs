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
        public bool StartStudySession(IEnumerable<RTKItem> items)
        {
            _studySession = new StudySession<RTKItem>(items);
            return true;
        }

        public RTKItem GetNextItem()
        {
            var nextItem = _studySession.First();
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
