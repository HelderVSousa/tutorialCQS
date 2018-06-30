namespace TutorialCQS.Repository.CassandraEntitys
{
    using System.Collections.Generic;
    using TutorialCQS.Model.Enums;

    public class UserEntity
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public List<ContactEntity> ContactList { get; set; }
    }
}
