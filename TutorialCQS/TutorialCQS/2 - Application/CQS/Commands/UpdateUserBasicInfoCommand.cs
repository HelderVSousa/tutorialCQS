namespace TutorialCQS.CQS.Commands
{
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.Model;
    using TutorialCQS.Repository;

    public class UpdateUserBasicInfoCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private User User { get; set; }

        public string UserId { get; set; }


        public UpdateUserBasicInfoCommand(UserRepository userRepository,string userId , UserDTO user)
        {
            this.userRepository = userRepository;
            this.User = UserDTOAssembler.ConvertUserDTOtoUser(user);
            this.UserId = userId;

        }

        public void Execute()
        {
            this.userRepository.UpdateUser(this.UserId, this.User);
        }
    }
}
