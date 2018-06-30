namespace TutorialCQS.Model
{
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model.Enums;

    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public List<Contact> ContactList { get; set; }

    }
}
