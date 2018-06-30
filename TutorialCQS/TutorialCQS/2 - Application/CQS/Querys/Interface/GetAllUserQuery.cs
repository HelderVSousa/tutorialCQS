namespace TutorialCQS.CQS.Querys.Interface
{
    using System.Collections.Generic;
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.Repository;

    public class GetAllUserQuery : IQuery<IEnumerable<UserDTO>>
    {
        private readonly UserRepository userRepository;

        public GetAllUserQuery(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserDTO> Execute()
        {
            return UserDTOAssembler.ConvertListUserToListUserDTO(this.userRepository.GetAllUsers());
        }
    }
}
