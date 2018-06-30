namespace TutorialCQS.Repository.EntityMappings
{
    using Cassandra.Mapping;
    using TutorialCQS.Repository.CassandraEntitys;

    public class MappingEntitysProfiles : Mappings
    {
        public MappingEntitysProfiles()
        {
            For<UserEntity>().TableName("users")
                      .PartitionKey("id")
                      .Column(u => u.Id, cm => cm.WithName("id"))
                      .Column(u => u.FirstName, cm => cm.WithName("first_name"))
                      .Column(u => u.LastName, cm => cm.WithName("last_name"))
                      .Column(u => u.Gender, cm => cm.WithName("gender"))
                      .Column(u => u.ContactList, cm => cm.WithName("contacts"));
        }
    }
}
