namespace TutorialCQS.Model
{
    using System;
    using TutorialCQS.Model.Enums;

    public class Contact
    {
        public Guid Id { get; set; }

        public ContactType ContactType { get; set; }

        public string Value { get; set; }

    }
}
