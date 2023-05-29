using Microsoft.AspNetCore.Mvc;
using picAplant.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace picAplant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialForumsController : ControllerBase
    {


        // GET api/<SocialForumsController>/5
        [HttpGet("GetForumsById&Follow")]
        public List<object> Get(int userID)
        {
            return SocialForum.GetForumByUseridFollowORnot(userID);
        }

        // POST api/<SocialForumsController>
        [HttpPost("FollowThis")]
        public IActionResult Post(int userID,int forumID)
        {
            int res = SocialForum.FollowThis(userID, forumID);
            if (res==1)
            {
                return Ok("user " + userID + " is follow now of forum id: " + forumID);
            }
            else
            {
                return BadRequest("error from SocialForum controller---> " + " parametes: userid: " + userID + " forumid: " + forumID);
            }
        }


    }
}
