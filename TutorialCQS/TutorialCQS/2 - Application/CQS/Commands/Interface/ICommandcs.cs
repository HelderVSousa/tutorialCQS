namespace TutorialCQS.CQS.Commands
{    public interface ICommand<TResult> : ICommand
    {
        TResult Execute();
    }
}
