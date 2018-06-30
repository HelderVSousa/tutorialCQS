namespace TutorialCQS.Infrastructure.POCO
{
    public class DataBaseConnection
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Keyspace { get; set; }
    }
}
