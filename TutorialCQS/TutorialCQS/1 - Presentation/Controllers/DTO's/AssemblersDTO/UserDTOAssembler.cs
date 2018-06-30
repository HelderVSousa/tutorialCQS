using System;
using System.Collections.Generic;
using TutorialCQS.Model;

namespace TutorialCQS.Controllers.DTO_s.AssemblersDTO
{
    public static class UserDTOAssembler
    {
        public static User ConvertUserDTOtoUser(UserDTO userDTO)
        {
            return new User
            {
                Id = new Guid(userDTO.Id.ToString()),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Gender = userDTO.Gender,
                ContactList = ContactDTOAssemblers.ConvertContactsDTOToListContact(userDTO.ContactList)
            };
        }

        public static UserDTO ConvertUsertoUserDTO(User user)
        {
            return new UserDTO
            {
                Id = new Guid(user.Id.ToString()),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                ContactList = ContactDTOAssemblers.ConvertContactsToListContactDTO(user.ContactList)
            };
        }

        public static IEnumerable<UserDTO> ConvertListUserToListUserDTO(IEnumerable<User> users)
        {
            var list = new List<UserDTO>();
            foreach (var u in users)
            {
                list.Add(ConvertUsertoUserDTO(u));
            }
            return list;
        }
    }
}
