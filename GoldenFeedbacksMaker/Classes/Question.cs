using iText.Kernel.Colors;
using iText.Layout.Element;

namespace GoldenFeedbacksMaker.Classes
{
    public class Question : BaseElement
    {
        public Question()
        {
            RegularFontName = Common.FontTitleRegular;
            InitializeLayout();
        }

        public Paragraph GetQuestion()
        {
            Text number = new Text($"{Number}. ").SetFont(boldFont);
            Text content = new Text(Content).SetFont(regularFont);

            return new Paragraph().Add(number).Add(content).SetBorderBottom(new iText.Layout.Borders.RoundDotsBorder(new DeviceCmyk(0, 0, 0, 0.5f), 1.0f));
        }
    }
}