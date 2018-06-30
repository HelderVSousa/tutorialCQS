namespace TutorialCQS.Controllers.DTO_s.AssemblersDTO
{
    using System;
    using System.Collections.Generic;
    using TutorialCQS.Model;
    using TutorialCQS.Model.Enums;

    public static class ContactDTOAssemblers
    {
        public static Contact ConvertContactDTOtoContact(ContactDTO contactDto)
        {
            return new Contact
            {
                Id = Guid.NewGuid(),
                ContactType = TranslateContact(contactDto.ContactType),
                Value = contactDto.Value

            };
        }

        public static ContactDTO ConvertContactToContactDTO(Contact contactDto)
        {
            return new ContactDTO
            {
                Id = contactDto.Id,
                ContactType = contactDto.ContactType.ToString(),
                Value = contactDto.Value

            };
        }

        public static List<ContactDTO> ConvertContactsToListContactDTO(List<Contact> contacts)
        {
            var list = new List<ContactDTO>();
            foreach (var c in contacts)
            {
                list.Add(ConvertContactToContactDTO(c));
            }
            return list;
        }

        public static List<Contact> ConvertContactsDTOToListContact(List<ContactDTO> contacts)
        {
            var list = new List<Contact>();
            foreach (var c in contacts)
            {
                list.Add(ConvertContactDTOtoContact(c));
            }
            return list;
        }

        private static ContactType TranslateContact(string contactType)
        {
            switch (contactType)
            {
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
