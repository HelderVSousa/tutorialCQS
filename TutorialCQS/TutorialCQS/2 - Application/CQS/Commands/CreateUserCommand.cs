namespace TutorialCQS.CQS.Commands
{
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model;
    using TutorialCQS.Model.Enums;
    using TutorialCQS.Repository;

    public class CreateUserCommand : ICommand
    {
        private readonly UserRepository userRepository;

        private User User { get; set; }

       
        public CreateUserCommand(UserRepository userRepository, string firstName, string lastName, GenderType gender)
        {
            this.User = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                ContactList = new List<Contact>()
            }; ;
            this.userRepository = userRepository;
        }

        public void Execute()
        {
            this.userRepository.InsertUser(this.User);
        }
    }
}
