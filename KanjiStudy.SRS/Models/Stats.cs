using System;

namespace KanjiStudy.SRS.Models
{
    public class StudyStats
    {
        public DateTime Date { get; set; } 
        public int CardsAnswered { get; set; }
        public int NeverReviewedAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int HesitantAnswers { get; set; }
        public int PerfectAnswers { get; set; }
    }
}