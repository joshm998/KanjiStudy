namespace KanjiStudy.SRS.Models
{
    public class RTKImport
    {
        public string Number { get; set; }
        public string Character { get; set; }
        public string Image { get; set; }
        public string Keyword { get; set; }
        public int StrokeCount { get; set; }
        public bool Primitive { get; set; }
    }
}