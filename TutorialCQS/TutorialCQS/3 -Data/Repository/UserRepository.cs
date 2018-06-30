namespace TutorialCQS.Repository
{
    using Cassandra.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TutorialCQS.Infrastructure;
    using TutorialCQS.Model;
    using TutorialCQS.Repository.Assemblers;

    public class UserRepository : IUserRepository
    {
        private readonly CassandraConnector cassandraConnector;

        public UserRepository(CassandraConnector cassandraConnector)
        {
            this.cassandraConnector = cassandraConnector;
        }

        public IEnumerable<User> GetAllUsers()
        {
            Cql cqlQuery = new Cql("select * from users");
            var result = this.cassandraConnector.GetSession().Execute(cqlQuery.Statement);
            var rows = result.GetRows().ToList();
            return rows != null 
                ? UserAssembler.ConvertRowsToUser(rows)
                : Enumerable.Empty<User>();
        }

        public void InsertUser(User userToADD)
        {
            var user = UserAssembler.ConvertUserToUserEntity(userToADD);
            Cql cqlQuery = new Cql("insert into users (id, first_name, last_name, gender, contacts) values (?, ?, ?, ?, ?)");
            var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
            var preparedQuery = preperadStatement.Bind(user.Id, user.FirstName, user.LastName, (int)user.Gender, user.ContactList);
            this.cassandraConnector.GetSession().Execute(preparedQuery);
        }

        public User GetUserById(string id)
        {
            Cql cqlQuery = new Cql("select * from users where id = ?");
            var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
            var preparedQuery = preperadStatement.Bind(id);
            var result = this.cassandraConnector.GetSession().Execute(preparedQuery);
            var rows = result.GetRows().ToList().FirstOrDefault();

            return rows != null 
                ? UserAssembler.ConvertRowToUser(rows)
                : null;
        }

        public void DeleteUserById(string id)
        {
            var userOnDB = this.GetUserById(id);
            if (userOnDB == null)
            {
                throw new Exception("User not found!");
            }
            Cql cqlQuery = new Cql("delete from users where id = ?");
            var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
            var preparedQuery = preperadStatement.Bind(id);
            this.cassandraConnector.GetSession().Execute(preparedQuery);
        }

        public void UpdateUser(string id, User userToUpdate)
        {
            var userOnDB = this.GetUserById(id);
            if (userOnDB == null)
            {
                throw new Exception("User not found!");
            }
            Cql cqlQuery = new Cql("UPDATE users set first_name = ?, last_name = ?, gender = ? where id = ?");
            var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
            var preparedQuery = preperadStatement.Bind(userToUpdate.FirstName, userToUpdate.LastName, (int)userToUpdate.Gender, id);
            this.cassandraConnector.GetSession().Execute(preparedQuery);
        }

        public void AddContactToUser(string userId, Contact newContact)
        {
            User user = GetUserById(userId);

            if (user != null)
            {
                List<Contact> tmpList = new List<Contact>();
                tmpList.AddRange(user.ContactList);
                tmpList.Add(newContact);
                Cql cqlQuery = new Cql("UPDATE users set contacts = ? where id = ?");
                var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
                var preparedQuery = preperadStatement.Bind(ContactAssembler.ConvertListOfContactToListContactEntity(tmpList), userId);
                this.cassandraConnector.GetSession().Execute(preparedQuery);
            }
        }

        public void DeleteUserContact(string userId, string contactId)
        {
            User user = GetUserById(userId);

            if (user != null)
            {
                var contactToRemove = user.ContactList.FirstOrDefault(c => c.Id.ToString() == contactId);
                if (contactToRemove != null)
                {
                    List<Contact> tmpList = new List<Contact>();
                    user.ContactList.Remove(contactToRemove);
                    tmpList.AddRange(user.ContactList);
                    Cql cqlQuery = new Cql("UPDATE users set contacts = ? where id = ?");
                    var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
                    var preparedQuery = preperadStatement.Bind(ContactAssembler.ConvertListOfContactToListContactEntity(tmpList), userId);
                    this.cassandraConnector.GetSession().Execute(preparedQuery);
                } 
            }
        }

        public void UpdateUserContact(string userId, string contactId, Contact contact)
        {
            User user = GetUserById(userId);

            if (user != null)
            {
                var contactToRemove = user.ContactList.FirstOrDefault(c => c.Id.ToString() == contactId);
                if (contactToRemove != null)
                {
                    List<Contact> tmpList = new List<Contact>();
                    user.ContactList.Remove(contactToRemove);
                    tmpList.AddRange(user.ContactList);
                    contact.Id = contactToRemove.Id;
                    tmpList.Add(contact);
                    Cql cqlQuery = new Cql("UPDATE users set contacts = ? where id = ?");
                    var preperadStatement = this.cassandraConnector.GetSession().Prepare(cqlQuery.Statement);
                    var preparedQuery = preperadStatement.Bind(ContactAssembler.ConvertListOfContactToListContactEntity(tmpList), userId);
                    this.cassandraConnector.GetSession().Execute(preparedQuery);
                }
            }
        }
    }
}
