

namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Instagraph.Data;
    using Instagraph.DataProcessor.DtoModels;
    using Instagraph.Models;

    public class Deserializer
    {
        private static string errorMsg = "Error: Invalid data.";
        private static string succsessMsg = "Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {

            Picture[] jsonPics = JsonConvert.DeserializeObject<Picture[]>(jsonString);

            List<Picture> picturesToAdd = new List<Picture>();

            StringBuilder sb = new StringBuilder();


            foreach (var picture in jsonPics)
            {
                bool IsValidPic = !string.IsNullOrWhiteSpace(picture.Path) && picture.Size > 0;

                bool picExist = picturesToAdd.Any(p => p.Path == picture.Path) ||
                                context.Pictures.Any(p => p.Path == picture.Path);

                if (!IsValidPic || picExist)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                picturesToAdd.Add(picture);

                sb.AppendLine(string.Format(succsessMsg, $"Picture {picture.Path}"));


            }

            context.Pictures.AddRange(picturesToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            UserDto[] jsonUserDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            List<User> usersToAdd = new List<User>();


            foreach (var uDto in jsonUserDtos)
            {
                bool isValid = !string.IsNullOrWhiteSpace(uDto.Username) &&
                               uDto.Username.Length <= 30 &&
                               !string.IsNullOrWhiteSpace(uDto.Password) &&
                               uDto.Password.Length <= 20 &&
                               !string.IsNullOrWhiteSpace(uDto.ProfilePicture);

                Picture picture = context.Pictures.FirstOrDefault(p => p.Path == uDto.ProfilePicture);

                bool userExist = context.Users.Any(u => u.Username == uDto.Username);

                if (!isValid || picture == null || userExist)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                var user = Mapper.Map<User>(uDto);
                user.ProfilePicture = picture;

                usersToAdd.Add(user);

                sb.AppendLine(string.Format(succsessMsg, $"User {user.Username}"));

            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            UserFollowerDto[] jsonUserFollowerDtos = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            List<UserFollower> userFollowersToAdd = new List<UserFollower>();

            foreach (var uf in jsonUserFollowerDtos)
            {
                int? userId = context.Users.FirstOrDefault(c => c.Username == uf.User)?.Id;
                int? followerId = context.Users.FirstOrDefault(c => c.Username == uf.Follower)?.Id;

                if (userId == null || followerId == null)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                bool alreadyFollowed = userFollowersToAdd.Any(x => x.UserId == userId && x.FollowerId == followerId);

                if (alreadyFollowed)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                var follower = new UserFollower
                {
                    UserId = userId.Value,
                    FollowerId = followerId.Value
                };

                userFollowersToAdd.Add(follower);

                sb.AppendLine(string.Format(succsessMsg, $"Follower {uf.Follower} to User {uf.User}"));

            }

            context.UsersFollowers.AddRange(userFollowersToAdd);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XDocument xdoc = XDocument.Parse(xmlString);

            var rootElements = xdoc.Root.Elements();

            List<Post> postsToAdd = new List<Post>();

            foreach (var element in rootElements)
            {
                string caption = element.Element("caption")?.Value;
                string user = element.Element("user")?.Value;
                string picture = element.Element("picture")?.Value;

                bool isValidInfo = !string.IsNullOrWhiteSpace(caption) &&
                                   !string.IsNullOrWhiteSpace(user) &&
                                   !string.IsNullOrWhiteSpace(picture);

                if (!isValidInfo)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                int? userId = context.Users.FirstOrDefault(u => u.Username == user)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(u => u.Path == picture)?.Id;


                if (userId == null || pictureId == null)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                Post post = new Post
                {
                   Caption = caption,
                   UserId = userId.Value,
                   PictureId = pictureId.Value
                };

                postsToAdd.Add(post);

                sb.AppendLine(string.Format(succsessMsg, $"Post {caption}"));

            }
            context.Posts.AddRange(postsToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XDocument xdoc = XDocument.Parse(xmlString);

            var rootElements = xdoc.Root.Elements();

            List<Comment> commentsToAdd = new List<Comment>();

            foreach (var element in rootElements)
            {
                string content = element.Element("content")?.Value;
                string user = element.Element("user")?.Value;
                string postIdString = element.Element("post")?.Attribute("id")?.Value;

                bool isValidInfo = !string.IsNullOrWhiteSpace(content) &&
                                   !string.IsNullOrWhiteSpace(user) &&
                                   !string.IsNullOrWhiteSpace(postIdString);

                if (!isValidInfo)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }

                int postID = int.Parse(postIdString);

                int? userId = context.Users.FirstOrDefault(u => u.Username == user)?.Id;
                bool postExists = context.Posts.Any(p => p.Id == postID);

                if (userId == null || !postExists)
                {
                    sb.AppendLine(errorMsg);
                    continue;
                }
                Comment comment = new Comment
                {
                    Content = content,
                    UserId = userId.Value,
                    PostId = postID
                   
                };

                commentsToAdd.Add(comment);
                sb.AppendLine(string.Format(succsessMsg, $"Comment {content}"));

            }
            context.Comments.AddRange(commentsToAdd);

            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }
    }
}
