namespace TutorialCQS.CQS
{
    using TutorialCQS.CQS.Commands;
    using TutorialCQS.CQS.Querys;

    public class Executer : IExecuter
    {
        public Executer()
        {
        }

        public TResult Execute<TResult>(IQuery<TResult> query) where TResult : class
        {
            return query.Execute();
        }

        public void Execute(ICommand command)
        {
            command.Execute(); ;
        }

        public TResult Execute<TResult>(ICommand<TResult> command)
        {
            return command.Execute();
        }
    }
}
