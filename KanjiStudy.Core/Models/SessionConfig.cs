using System.ComponentModel.DataAnnotations;

namespace KanjiStudy.Core.Models
{
    public class SessionConfig
    {
        [Required(ErrorMessage = "Please Enter Max New Cards")]
        public int MaxNewCards { get; set; }
        [Required(ErrorMessage = "Please Enter Max Existing Cards")]
        public int MaxExistingCards { get; set; }
    }
}