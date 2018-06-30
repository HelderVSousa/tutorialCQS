namespace TutorialCQS.CQS
{
    using TutorialCQS.CQS.Commands;
    using TutorialCQS.CQS.Querys;

    public interface IExecuter
    {
        TResult Execute<TResult>(IQuery<TResult> query) where TResult : class;
        void Execute(ICommand command);
        TResult Execute<TResult>(ICommand<TResult> command);
    }
}
