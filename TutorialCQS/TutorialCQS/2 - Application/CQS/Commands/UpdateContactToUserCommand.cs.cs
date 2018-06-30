namespace TutorialCQS.CQS.Commands
{
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.Model;
    using TutorialCQS.Repository;

    public class UpdateContactToUserCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private Contact Contact { get; set; }

        private string UserId { get; set; }

        private string ContactId { get; set; }


        public UpdateContactToUserCommand(UserRepository userRepository, string userId, string contactId, ContactDTO contact)
        {
            this.userRepository = userRepository;
            this.UserId = userId;
            this.ContactId = contactId;
            this.Contact = ContactDTOAssemblers.ConvertContactDTOtoContact(contact);
        }

        public void Execute()
        {
            this.userRepository.UpdateUserContact(this.UserId, this.ContactId, this.Contact);
        }
    }
}
