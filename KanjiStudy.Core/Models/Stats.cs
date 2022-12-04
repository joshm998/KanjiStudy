using System;

namespace KanjiStudy.Core.Models
{
    public class StudyStats
    {
        public DateTime _id { get; set; } 
        public int CardsAnswered { get; set; }
        public int NeverReviewedAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int HesitantAnswers { get; set; }
        public int PerfectAnswers { get; set; }
    }
}