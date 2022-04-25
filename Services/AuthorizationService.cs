using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiBarApp.Abstractions;
using SushiBarApp.Data;
using SushiBarApp.Data.Models;
using SushiBarApp.ViewModels;

namespace SushiBarApp.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly SushiAppDBContext _db;
        public AuthorizationService(SushiAppDBContext context)
        {
            _db = context;
        }

        public User GetUser(IEnumerable<Claim> claims)
        {
            if (!IsAuthorized(claims))
                return null;
            var email = claims.ToList()[0].Value;
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null;
            return user;
        }

        public async Task<bool> IsAdmin(IEnumerable<Claim> claims)
        {
            if (!IsAuthorized(claims))
                return false;
            var userName = claims.ToList()[0].Value;
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == userName);
            if (user.Role == "Admin") return true;
            return false;
        }

        public bool IsAuthorized(IEnumerable<Claim> claims)
        {
            if (claims != null && claims.Count() != 0) return true;
            return false;
        }
        public string GetHash(string password)
        {
            using (var hash = SHA256.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
        
    }
}
