namespace TutorialCQS.CQS.Querys
{
    public interface IQuery<TResult>
    {
        TResult Execute();
    }
}
