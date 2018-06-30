namespace TutorialCQS.Repository.Assemblers
{
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model;
    using TutorialCQS.Model.Enums;
    using TutorialCQS.Repository.CassandraEntitys;

    public static class ContactAssembler
    {
        public static ContactEntity ConvertContactToContactEntity(Contact contact)
        {
            return new ContactEntity {
                Id = contact.Id.ToString(),
                ContactType = contact.ContactType.ToString(),
                Value = contact.Value,
            };
        }

        public static Contact ConvertContactEntityToContact(ContactEntity contact)
        {
            return new Contact
            {
                Id = new Guid(contact.Id),
                ContactType = TranslateContact(contact.ContactType),
                Value = contact.Value,
            };
        }

        public static List<ContactEntity> ConvertListOfContactToListContactEntity(List<Contact> contacts)
        {
            List<ContactEntity> tmpList = new List<ContactEntity>();

            foreach (var c in contacts)
            {
                tmpList.Add(ConvertContactToContactEntity(c));
            }

            return tmpList;
        }

        public static List<Contact> ConvertListContactEntityToListContact(List<ContactEntity> contacts)
        {
            List<Contact> tmpList = new List<Contact>();

            foreach (var c in contacts)
            {
                tmpList.Add(ConvertContactEntityToContact(c));
            }
            
            return tmpList;
        }

        private static ContactType TranslateContact(string contactType)
        {
            switch (contactType) {
                case "MobilePhone":
                    return ContactType.MobilePhone;
                case "HomePhone":
                    return ContactType.HomePhone;
                case "PersonalEmail":
                    return ContactType.PersonalEmail;
                case "WorkEmail":
                    return ContactType.WorkEmail;
                case "WorkPhone":
                    return ContactType.WorkPhone;
                default:
                    return ContactType.NotDefined;

            }
        }
    }
}
