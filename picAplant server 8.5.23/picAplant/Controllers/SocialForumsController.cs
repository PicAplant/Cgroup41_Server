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

        // POST api/<SocialForumsController>
        [HttpPost("CreateNewForum")]
        public IActionResult Post(int userID,string forumName,string forumDis,int photoID)
        {
            int forumid = SocialForum.CreateNewForum(userID,forumName,forumDis,photoID);
            if (forumid > 0)
            {
                return Ok("sucsses, paremetrs by order: " + userID+" "+ forumName + " " + forumDis + " " + photoID+"forumID:"+forumid);
            }
            else
            {
                return BadRequest("error from SocialForum controller---> " + " paremetrs by order: " + userID + " " + forumName + " " + forumDis + " " + photoID);
            }
        }

        // POST api/<SocialForumsController>
        [HttpPost("SendPost")]
        public IActionResult Post(int userID, int forumID, string content)
        {
            int res = SocialForum.InsertNewPost(userID,forumID,content);
            if (res >= 1)
            {
                return Ok("sucsses, paremetrs by order: " + userID + " " + forumID + " " + content );
            }
            else
            {
                return BadRequest("error from SocialForum controller---> " + " paremetrs by order: " + userID + " " + forumID + " " + content);
            }
        }
        [HttpGet("GetPosts")]
        public IActionResult GetPosts(int forumID)
        {
            return Ok(SocialForum.ReadPostByForumId(forumID));
        }

        [HttpGet("GetReplays")]
        public IActionResult GetReplays(int PostID)
        {
            return Ok(SocialForum.ReadReplayByPostId(PostID));
        }

        [HttpPost("SendReplay")]
        public IActionResult sendReplay(int postID,int userID,string content)
        {
           int res = SocialForum.SendReplay(userID,postID,content);
            if (res>=1)
            {
                return Ok("success, replay sent");
            }
            else
            {
                return BadRequest("error from SocialForum controller---> " + " paremetrs by order: " + userID + " " + postID + " " + content);
            }
        }

    }
}
