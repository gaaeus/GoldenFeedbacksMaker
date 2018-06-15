using iText.Layout.Element;
using System.Collections;

namespace GoldenFeedbacksMaker.Classes
{
    public class Answer : BaseElement
    {
        int QuestionId { get; set; }
        ICollection Images { get; set; }

        public Answer()
        {
            RegularFontName = Common.FontAnswerRegular;
            InitializeLayout();
        }

        public Paragraph GetAnswer()
        {
            Text content = new Text(Content).SetFont(regularFont);

            return new Paragraph().Add(content);
        }
    }
}
