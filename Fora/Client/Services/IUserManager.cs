﻿using Fora.Shared;

namespace Fora.Client.Services
{
    public interface IUserManager
    {
        Task<UserModel> GetUserByToken(string accessToken);
        Task<List<string>> SignUpUser(UserDTOModel user);
        Task<List<string>> SignInUser(SignInModel user);
        Task DeleteUser(int userId, string userToken);
        Task<UserStatusDTOModel> CheckUserLogin(string token);

        //Task UpdateUserModel(UserModel updatedUser);
        Task SignOutUser();
        Task UpdatePassword(PasswordDTOModel UserToUpdate);
        Task ChangeDeletedStateToTrue(UserModel UserToChange);
        Task ChangeDeletedStateToFalse(UserModel UserToChange);
        Task<List<UserModel>> GetAllUsers();


    }
}
