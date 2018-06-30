namespace TutorialCQS.Repository.Assemblers
{
    using Cassandra;
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model;
    using TutorialCQS.Model.Enums;
    using TutorialCQS.Repository.CassandraEntitys;

    public static class UserAssembler
    {
        public static UserEntity ConvertRowToUserEntity(Row user)
        {
            return new UserEntity
            {
                Id = user.GetValue<string>("id"),
                FirstName = user.GetValue<string>("first_name"),
                LastName = user.GetValue<string>("last_name"),
                Gender = user.GetValue<GenderType>("gender"),
                ContactList = user.GetValue<List<ContactEntity>>("contacts")
            };
        }

        public static IEnumerable<UserEntity> ConvertRowsToUserEntity(List<Row> users)
        {
            List<UserEntity> listUser = new List<UserEntity>();

            foreach (Row r in users)
            {
                listUser.Add(ConvertRowToUserEntity(r));
            }

            return listUser;
        }

        public static UserEntity ConvertUserToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = (GenderType)user.Gender,
                ContactList = ContactAssembler.ConvertListOfContactToListContactEntity(user.ContactList)
            };
        }

        public static User ConvertRowToUser(Row user)
        {
            return new User
            {
                Id = new Guid(user.GetValue<string>("id")),
                FirstName = user.GetValue<string>("first_name"),
                LastName = user.GetValue<string>("last_name"),
                Gender = user.GetValue<GenderType>("gender"),
                ContactList = ContactAssembler.ConvertListContactEntityToListContact(user.GetValue<List<ContactEntity>>("contacts"))
            };
        }

        public static IEnumerable<User> ConvertRowsToUser(List<Row> users)
        {
            List<User> listUser = new List<User>();

            foreach (Row r in users)
            {
                listUser.Add(ConvertRowToUser(r));
            }

            return listUser;
        }
    }
}
