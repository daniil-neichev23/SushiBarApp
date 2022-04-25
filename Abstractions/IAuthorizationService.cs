using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Abstractions
{
    public interface IAuthorizationService
    {
        public bool IsAuthorized(IEnumerable<Claim> claims);
        public Task<bool> IsAdmin(IEnumerable<Claim> claims);
        public User GetUser(IEnumerable<Claim> claims);
        public string GetHash(string password);
    }
}
