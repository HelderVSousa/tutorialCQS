namespace TutorialCQS.CQS.Commands
{
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.Model;
    using TutorialCQS.Repository;

    public class AddContactToUserCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private Contact Contact { get; set; }

        private string UserId { get; set; }


        public AddContactToUserCommand(UserRepository userRepository, string userId, ContactDTO contact)
        {
            this.userRepository = userRepository;
            this.UserId = userId;
            this.Contact = ContactDTOAssemblers.ConvertContactDTOtoContact(contact);
        }

        public void Execute()
        {
            this.userRepository.AddContactToUser(this.UserId, this.Contact);
        }
    }
}
