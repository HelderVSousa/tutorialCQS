namespace TutorialCQS.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using TutorialCQS.Controllers.DTO_s;
    using TutorialCQS.Controllers.DTO_s.AssemblersDTO;
    using TutorialCQS.CQS;
    using TutorialCQS.CQS.Commands;
    using TutorialCQS.CQS.Querys.Interface;
    using TutorialCQS.Model.Enums;
    using TutorialCQS.Repository;

    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly UserRepository userRepositoy;

        private readonly Executer executer;

        public UserController(UserRepository userRepositoy, Executer executer)
        {
            this.userRepositoy = userRepositoy;
            this.executer = executer;
        }

        // GET api/user
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        { 
            return this.executer.Execute(new GetAllUserQuery(this.userRepositoy));
        }

        // GET api/user/5
        [HttpGet("{userId}")]
        public UserDTO Get(string userId)
        {
            return this.executer.Execute(new GetUserByIdQuery(this.userRepositoy, userId));
        }

        // POST api/user
        [HttpPost]
        public void Post(string firstName, string lastName, GenderType gender )
        {
            this.executer.Execute(new CreateUserCommand(this.userRepositoy, firstName, lastName, gender));  
        }

        // PUT api/user/5
        [HttpPut("{userId}")]
        public void Put(string userId, [FromBody]UserDTO user)
        {
            this.executer.Execute(new UpdateUserBasicInfoCommand(this.userRepositoy, userId, user));
        }

        // DELETE api/user/5
        [HttpDelete("{userId}")]
        public void Delete(string userId)
        {
            this.executer.Execute(new DeleteUserCommand(this.userRepositoy, userId));
        }

        // POST api/contact/
        [HttpPost]
        [Route("contact/")]
        public void PostUserContact(string userId, [FromBody]ContactDTO contact)
        {
          this.executer.Execute(new AddContactToUserCommand(this.userRepositoy, userId, contact));
        }

        // GET api/contact/3
        [HttpDelete]
        [Route("contact/")]
        public void DeleteUserContact(string userId, string contactId)
        {
            this.executer.Execute(new DeleteContactToUserCommand(this.userRepositoy, userId, contactId));
        }

        // Put api/contact/2
        [HttpPut]
        [Route("contact/")]
        public void UpdateUserContact(string userId, string contactId, [FromBody]ContactDTO contact)
        {
            this.executer.Execute(new UpdateContactToUserCommand(this.userRepositoy, userId, contactId,contact));
        }
    }
}
