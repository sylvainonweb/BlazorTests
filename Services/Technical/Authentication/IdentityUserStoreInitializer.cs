using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlazorTests.Services.Technical.Authentication
{
    public class IdentityUserStoreInitializer
    {
        private SignInManager<IdentityUser> signInManager;

        public IdentityUserStoreInitializer(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async void CreateUsers()
        {
            var users = new Dictionary<IdentityUser, string>();
            users.Add(new IdentityUser
            {
                Id = "1",
                UserName = "test"
            }, "test");
            users.Add(new IdentityUser
            {
                Id = "2",
                UserName = "admin"
            }, "admin");

            foreach (var user in users)
            {
                // Attention, la propriété PasswordHash de user ne doit pas être définie sinon SignInManager.PasswordSignInAsync retournera toujours 'Failed'
                var result = await this.signInManager.UserManager.CreateAsync(user.Key, user.Value);
            }
        }
    }
}
