using chipchop.Core.ViewModels;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Http;

namespace chipchop.Core.Interface;

public interface IAdmin:IDisposable
{
    public Task<List<Content>> GetContents();
    public Task<List<Content>> GetContents(int groupId);
    public Task<List<Content>> GetContents(int groupId, int ContentId);
    public Task<List<Content>> GetContents(bool visible);
    public Task<List<Group>> GetGroups();
    public Task<Group> GetGroup(int Gid);
    public Task<bool> AddContent(Content content, IFormFile ImgFile);
    public Task<Content> GetContent(int id);
    public Task<List<Content>> Search(string ContentName);
    public Task<User> GetUser(LoginModel Login);
    public Task<User> GetUser(string register);
    public Task<bool> AddUser(RegisterViewModel register);
    public Task<bool> SetUserInfo(UserInfo userInfo);
}
