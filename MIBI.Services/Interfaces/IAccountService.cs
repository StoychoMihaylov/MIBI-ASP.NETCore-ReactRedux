namespace MIBI.Services.Interfaces
{
    using MIBI.Models.BindingModels.Account;
    using MIBI.Models.ViewModels.Account;

    public interface IAccountService
    {
        AccountLoginViewModel CreateNewUserAccount(RegisterUserBindingModel bm);
        AccountLoginViewModel LoginUser(LoginUserBindingModel bm);
    }
}
