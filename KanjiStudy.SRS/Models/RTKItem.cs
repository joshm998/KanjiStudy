using SpacedRepetition.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiStudy.SRS.Models
{
    public class RTKItem : ReviewItem
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public int NumberStrokes { get; set; }
        public string EnglishMeaning { get; set; }
        public string Kanji { get; set; }
        public string Story { get; set; }
        public string Notes { get; set; }
    }
}
