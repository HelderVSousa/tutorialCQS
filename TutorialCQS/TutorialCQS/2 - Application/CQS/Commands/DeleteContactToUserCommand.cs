namespace TutorialCQS.CQS.Commands
{
    using TutorialCQS.Repository;

    public class DeleteContactToUserCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private string UserId { get; set; }

        private string ContactId { get; set; }


        public DeleteContactToUserCommand(UserRepository userRepository, string userId, string contactId)
        {
            this.userRepository = userRepository;
            this.UserId = userId;
            this.ContactId = contactId;
        }

        public void Execute()
        {
            this.userRepository.DeleteUserContact(this.UserId, this.ContactId);
        }
    }
}
