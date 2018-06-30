namespace TutorialCQS.Repository
{
    using System.Collections.Generic;
    using TutorialCQS.Model;

    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        void InsertUser(User userToADD);

        User GetUserById(string id);

        void DeleteUserById(string id);

        void UpdateUser(string id, User userToUpdate);

        void AddContactToUser(string userId, Contact newContact);

        void DeleteUserContact(string userId, string contactId);

        void UpdateUserContact(string userId, string contactId, Contact contact);


    }
}
