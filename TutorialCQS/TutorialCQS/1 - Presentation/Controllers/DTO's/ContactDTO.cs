namespace TutorialCQS.Controllers.DTO_s
{
    using System;

    public class ContactDTO
    {
        public Guid Id { get; set; }

        public string ContactType { get; set; }

        public string Value { get; set; }
    }
}
