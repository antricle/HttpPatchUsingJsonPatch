using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HttpPatchUsingJsonPatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IList<UserProfile> _userProfiles = new List<UserProfile>();

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            PopulateUserProfiles();
        }

        private void PopulateUserProfiles()
        {
            _userProfiles.Add(new UserProfile { Id = new Guid("29e207ed-1f5b-48e7-957a-b2c2d07164ee"), Name = "Luke Jones", Location = "Tokyo" });
            _userProfiles.Add(new UserProfile { Id = new Guid("022e6a50-3c23-4d37-bf83-ebab0b2e091f"), Name = "Amanda Morgans", Location = "New York" });
            _userProfiles.Add(new UserProfile { Id = new Guid("83a041cb-e335-4f8f-b017-1e8cd62db8bf"), Name = "John Saville", Location = "London" });
            _userProfiles.Add(new UserProfile { Id = new Guid("575ee618-8977-43b1-97e7-9561956601e1"), Name = "Dan Lathem", Location = "Edinburgh" });
            _userProfiles.Add(new UserProfile { Id = new Guid("2aa488f4-3cab-4657-94e9-fb28f6302878"), Name = "Jun Liu", Location = "Beijing" });
            _userProfiles.Add(new UserProfile { Id = new Guid("6cc96d4d-d44b-493a-8b0f-7841d302ddab"), Name = "Mandy Fedal", Location = "Sydney" });
            _userProfiles.Add(new UserProfile { Id = new Guid("94726d0e-1265-4277-8808-22917b98e621"), Name = "Bhupinder Singh", Location = "New Delhi" });
            _userProfiles.Add(new UserProfile { Id = new Guid("a1e417ae-493b-4f3d-9dc3-ac22a43c7f03"), Name = "Tom Parker", Location = "Los Angeles" });
            _userProfiles.Add(new UserProfile { Id = new Guid("5d59cd33-f34a-4852-a69c-f60a1b897b1b"), Name = "Jito Hibiki", Location = "Tokyo" });
            _userProfiles.Add(new UserProfile { Id = new Guid("c9fe2520-7827-4590-8647-8150c3a37c29"), Name = "Sean Davies", Location = "Dublin" });
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Guid id, [FromBody] JsonPatchDocument<UserProfile> patchDoc)
        {
            var profileToUpdate = _userProfiles.FirstOrDefault(p => p.Id == id);

            if (profileToUpdate == null) return NotFound();

            patchDoc.ApplyTo(profileToUpdate);

            return Ok(profileToUpdate);
        }
    }
}