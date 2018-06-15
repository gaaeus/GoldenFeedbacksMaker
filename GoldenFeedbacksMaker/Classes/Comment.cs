namespace GoldenFeedbacksMaker.Classes
{
    public class Comment : BaseElement
    {
        int QuestionId { get; set; }

        public Comment()
        {
            InitializeLayout();
        }
    }
}
