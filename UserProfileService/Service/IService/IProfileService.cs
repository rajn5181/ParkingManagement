using UserProfileService.Model;

namespace UserProfileService.Service.IService
{
    public interface IProfileService
    {
        List<ProfileModel> FetchUserDataByUserId(string userId);
        ProfileModel FetchUserDataByUserEmail(string userEmail);


    }
}
