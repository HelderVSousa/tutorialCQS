namespace TutorialCQS.CQS.Querys.Interface
{
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.Repository;

    public class GetUserByIdQuery : IQuery<UserDTO>
    {
        private readonly UserRepository userRepository;

        private readonly string userId;

        public GetUserByIdQuery(UserRepository userRepository, string userId)
        {
            this.userRepository = userRepository;
            this.userId = userId;
        }

        public UserDTO Execute()
        {
            return UserDTOAssembler.ConvertUsertoUserDTO(this.userRepository.GetUserById(this.userId));
        }
    }
}
