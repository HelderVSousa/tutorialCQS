namespace TutorialCQS.Controllers.DTO_s
{
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model.Enums;

    public class UserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public List<ContactDTO> ContactList { get; set; }
    }
}
