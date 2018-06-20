using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace GoldenFeedbacksMaker.Classes
{
    public class Comment : BaseElement
    {
        int QuestionId { get; set; }

        public Comment()
        {
            RegularFontName = Common.FontTitleRegular;
            InitializeLayout();
        }

        public Table GetComment()
        {
            Text content = new Text(Content).SetFont(regularFont);

            Text title = new Text($"{Title}. ").SetFont(boldFont);
            Paragraph titleParagraph = new Paragraph(title);

            // Create the container for the comment
            Table commentTable = new Table(new float[] { 1, 1 });
            commentTable.UseAllAvailableWidth();

            Color cellColour = new DeviceCmyk(0, 0, 0, 0.175f);
            Color cellFontColour = new DeviceCmyk(0, 0, 0, 0.950f);

            content.SetFontColor(cellFontColour);
            Cell contentCell = new Cell(1, 1);

            contentCell.SetBackgroundColor(cellColour);
            contentCell.SetBorderRadius(new BorderRadius(5.0f));
            contentCell.SetBorder(Border.NO_BORDER);

            contentCell.SetPaddings(5.0f, 10.0f, 5.0f, 10.0f);
            contentCell.Add(new Paragraph().Add(title).Add("\n").Add(content));

            commentTable.AddCell(contentCell);

            return commentTable;
        }
    }
}
