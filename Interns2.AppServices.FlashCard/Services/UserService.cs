using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Interns2.Domain.Domains;

namespace Interns2.AppServices.FlashCard.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<IdentityResult> SignUpAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return _userManager.ConfirmEmailAsync(user, token);
        }

        public Task<SignInResult> SignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure = false)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail)
        {
            return _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        }

        public Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
        {
            return _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<User> FindByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public string GenerateAppToken(User user)
        {
            if (user.AccessToken == null)
            {
                user.AccessToken = Guid.NewGuid().ToString();
            }

            return user.AccessToken;
        }
    }
}