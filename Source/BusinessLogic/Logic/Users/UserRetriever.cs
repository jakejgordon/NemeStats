﻿using System.Linq;
using BusinessLogic.DataAccess;
using BusinessLogic.Exceptions;
using BusinessLogic.Logic.GamingGroups;
using BusinessLogic.Models;
using BusinessLogic.Models.Players;
using BusinessLogic.Models.User;

namespace BusinessLogic.Logic.Users
{
    public class UserRetriever : IUserRetriever
    {
        private readonly IDataContext dataContext;

        public UserRetriever(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public UserInformation RetrieveUserInformation(string userId, ApplicationUser applicationUser)
        {
            if (userId != applicationUser.Id)
            {
                throw new UnauthorizedEntityAccessException(applicationUser.Id, typeof(ApplicationUser), userId);
            }

            var userInformation = dataContext.GetQueryable<ApplicationUser>()
                .Where(user => user.Id == userId)
                .Select(user => new UserInformation
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    GamingGroups = user.UserGamingGroups.Select(userGamingGroup => new GamingGroupInfoForUser
                    {
                        GamingGroupId = userGamingGroup.GamingGroup.Id,
                        GamingGroupName = userGamingGroup.GamingGroup.Name,
                        GamingGroupPublicDescription = userGamingGroup.GamingGroup.PublicDescription,
                        GamingGroupPublicUrl = userGamingGroup.GamingGroup.PublicGamingGroupWebsite
                    }).ToList(),
                    Players = user.Players.Select(player => new PlayerInfoForUser
                    {
                        PlayerId = player.Id,
                        PlayerName = player.Name,
                        GamingGroupId = player.GamingGroupId
                    }).ToList(),
                    BoardGameGeekUser = new BoardGameGeekUserInformation
                    {
                        Name = user.BoardGameGeekUser.Name,
                        Avatar = user.BoardGameGeekUser.Avatar
                    }
        }).First();
            //var bggUser =
            //    dataContext.GetQueryable<BoardGameGeekUserDefinition>()
            //        .FirstOrDefault(u => u.ApplicationUserId == userId);
            //BoardGameGeekUserInformation bggUserInformation = null;
            //if (bggUser != null)
            //{
            //    bggUserInformation = new BoardGameGeekUserInformation
            //    {
            //        Name = bggUser.Name,
            //        Avatar = bggUser.Avatar
            //    };
            //}

            //userInformation.BoardGameGeekUser = bggUserInformation;

            return userInformation;
        }
    }
}
