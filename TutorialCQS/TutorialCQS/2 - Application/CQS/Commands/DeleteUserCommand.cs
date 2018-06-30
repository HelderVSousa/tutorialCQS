namespace TutorialCQS.CQS.Commands
{
    using TutorialCQS.Repository;

    public class DeleteUserCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private string UserId { get; set; }
               
        public DeleteUserCommand(UserRepository userRepository, string userId)
        {
            this.UserId = userId;
            this.userRepository = userRepository;
        }

        public void Execute()
        {
            this.userRepository.DeleteUserById(this.UserId);
        }
    }
}
