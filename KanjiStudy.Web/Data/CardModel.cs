using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Data
{
    public class CardModel
    {
        [Required(ErrorMessage = "Please Enter Number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Strokes")]
        public int NumberStrokes { get; set; }

        [Required(ErrorMessage = "Please Enter English Meaning")]
        public string EnglishMeaning { get; set; }

        [Required(ErrorMessage = "Please Enter Kanji")]
        public string Kanji { get; set; }

        [Required(ErrorMessage = "Please Enter Story")]
        public string Story { get; set; }

        public string Notes { get; set; }

    }
}
