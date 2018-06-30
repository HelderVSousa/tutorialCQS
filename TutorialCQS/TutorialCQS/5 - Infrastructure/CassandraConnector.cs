namespace TutorialCQS.Infrastructure
{
    using Cassandra;
    using Cassandra.Mapping;
    using Microsoft.Extensions.Options;
    using TutorialCQS.Infrastructure.POCO;
    using TutorialCQS.Repository.CassandraEntitys;
    using TutorialCQS.Repository.EntityMappings;

    public class CassandraConnector
    {
        private readonly DataBaseConnection DataBaseConnection;

        private Cluster Cluster { get; set; }

        private ISession Session { get; set; }

        private IMapper databaseMapper;

        public CassandraConnector(IOptions<DataBaseConnection> dataBaseConnection)
        {
            this.DataBaseConnection = dataBaseConnection.Value;
            this.Cluster = Cluster.Builder()
                                 .AddContactPoints(this.DataBaseConnection.Host)
                                 .WithPort(this.DataBaseConnection.Port)
                                 .WithDefaultKeyspace(this.DataBaseConnection.Keyspace)
                                 //.WithAuthProvider(new PlainTextAuthProvider(this.DataBaseConnection.Username, this.DataBaseConnection.Password))
                                 .WithQueryOptions(new QueryOptions()
                                    .SetConsistencyLevel(ConsistencyLevel.All))
                                 .Build();

            this.Session = this.Cluster.Connect(this.DataBaseConnection.Keyspace);


            // Define Entity Mappings 
            MappingConfiguration.Global.Define<MappingEntitysProfiles>();
            this.Session.UserDefinedTypes.Define(UdtMap.For<ContactEntity>("contact"));

            this.databaseMapper = new Mapper(this.Session);
        }

        public ISession GetSession()
        {
            return this.Session;
        }

        public IMapper GetCqlClient()
        {
            return this.databaseMapper;
        }
    }
}
