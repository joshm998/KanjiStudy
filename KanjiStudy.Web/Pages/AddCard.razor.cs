using KanjiStudy.Web.Data;

namespace KanjiStudy.Web.Pages
{
    public partial class AddCard
    {
        private CardModel cardModel = new();
        private string test;
        private void HandleValidSubmit()
        {
            test = cardModel.EnglishMeaning;
        // Process the valid form
        }
    }
}