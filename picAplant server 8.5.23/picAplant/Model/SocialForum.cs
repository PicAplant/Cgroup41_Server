﻿using UniServer.Models.DAL;

namespace picAplant.Model
{
    public class SocialForum
    {
        int socialForumID;
        string socialForumTimeStamp;
        string socialForumName;
        string socialForumDisc;
        int profilePhotoID;

        public int SocialForumID { get => socialForumID; set => socialForumID = value; }
        public string SocialForumTimeStamp { get => socialForumTimeStamp; set => socialForumTimeStamp = value; }
        public string SocialForumName { get => socialForumName; set => socialForumName = value; }
        public string SocialForumDisc { get => socialForumDisc; set => socialForumDisc = value; }
        public int ProfilePhotoID { get => profilePhotoID; set => profilePhotoID = value; }


        static public List <object> GetForumByUseridFollowORnot(int userID)
        {
            DBservices db = new DBservices();
            return db.GetListOfUNforums(userID);
        }

    }
}
