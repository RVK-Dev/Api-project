using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "Riki", "Zeava" };
        }
        static string filePath = "file.txt";
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
            
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return Ok(user);
                }
            }
            return NotFound();
        }
        

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);

            return CreatedAtAction(nameof(Get), new { id = user.Id },user);
        }

        // POST api/<UsersController>
        [HttpPost ("login")]
        public ActionResult<User> Post([FromBody] UserLogin userLogin)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user1 = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user1.Email == userLogin.Email && user1.Password == userLogin.Password)
                        return user1;
                }
            }
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {

            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == userToUpdate.Id)
                        textToReplace = currentUserInFile;
                }
            }
            if(textToReplace != string.Empty)
{
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
