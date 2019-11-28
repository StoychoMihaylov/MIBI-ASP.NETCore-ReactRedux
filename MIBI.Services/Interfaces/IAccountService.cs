namespace MIBI.Services.Interfaces
{
    using MIBI.Data.Entities;
    using MIBI.Models.BindingModels.Account;
    using MIBI.Models.ViewModels.Account;

    public interface IAccountService
    {
        AccountCredentialsViewModel CreateNewUserAccount(RegisterUserBindingModel bm);
        AccountCredentialsViewModel LoginUser(LoginUserBindingModel bm);
        void DeleteUserToken(LogoutBindingModel bm);
        User RetrieveCurrentUser(string token);
    }
}
