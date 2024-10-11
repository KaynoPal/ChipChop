using chipchop.Core.Classes;
using chipchop.Core.Interface;
using chipchop.Core.ViewModels;
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace chipchop.Core.service
{
    public class AdminService : IAdmin
    {
        private readonly DatabaseContext _Context;
        public AdminService(DatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<bool> AddContent(Content content, IFormFile ImgFile)
        {

            try
            {
                //upload img 
                content.Img = await new ImageClass().SaveContentImg(ImgFile);
                //add content
                await _Context.Contents.AddAsync(content);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error has been detected : " + error);
                return false;
            }
        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
        }

        public async Task<Content> GetContent(int id)
        {
            // first metod
            /*var Content = await _Context.Contents.include.FindAsync(id)*/

            //firstOrDefault // singleOrDfault metod
            var Content = await _Context.Contents.Include(C=>C.Group).FirstOrDefaultAsync(C=>C.Id == id);
            return Content;

            //where metod
            /*var content = _Context.Contents.Where(C => C.Id == id).Select(C => new Content()
            {
                Id = C.Id,
                GroupId = C.GroupId
            }).FirstOrDefaultAsync();*/
        }

        public async Task<List<Content>> GetContents()
        {
            var Contents = await _Context.Contents.ToListAsync();
            return Contents;
        }

        public async Task<List<Group>> GetGroups()
        {
            var groups = await _Context.Groups.ToListAsync();
            return groups;
        }

        public async Task<Group> GetGroup(int Gid)
        {
            var group = await _Context.Groups.FindAsync(Gid);
            return group;
        }

        public async Task<List<Content>> GetContents(int groupId)
        {
            var Contents = await _Context.Contents.Include(C => C.Group).Where(C => C.GroupId == groupId).ToListAsync();
            return Contents;
        }

        public async Task<List<Content>> GetContents(int groupId, int ContentId)
        {
            var Contents = await _Context.Contents.Include(C => C.Group).Where(C => C.GroupId == groupId && C.Id !=ContentId && !C.Visible).ToListAsync();
            return Contents;
        }

        public async Task<List<Content>> GetContents(bool visible)
        {
            var Contents = await _Context.Contents.Where(C=> C.Visible == visible).ToListAsync();
            return Contents;
        }

        public async Task<List<Content>> Search(string ContentName)
        {
            var contents = await _Context.Contents.Where(C => C.Name.Contains(ContentName) || C.Description.Contains(ContentName) && !C.Visible).OrderByDescending(C => C.SubmitDate).ToListAsync();
            return contents;
        }

        public async Task<User> GetUser(LoginModel Login)
        {
            var hash = await new Security().GetHash(Login.Password);
            var user = await _Context.Users.Include(U => U.Role).FirstOrDefaultAsync(U => U.UserName == Login.UserName && U.Password == hash);
            return user;
        }

        public async Task<User> GetUser(string register)
        {
            var user = await _Context.Users.Include(d=>d.UserInfo).FirstOrDefaultAsync(U => U.UserName == register);
            return user;
        }

        public async Task<bool> AddUser(RegisterViewModel register)
        {
            try
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    RoleId = await CheckUserRoleId(),
                    UserName = register.UserName,
                    Password = await new Security().GetHash(register.Password),
                    IsActive = true
                };
                await _Context.Users.AddAsync(user);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine($" error -> (adduser) : {error}");
                return false;
            }
        }

        private protected async Task<Guid> CheckUserRoleId()
        {
            var userRole = await _Context.Roles.FirstOrDefaultAsync(R => R.RoleName == "user");
            if (userRole != null)
            {
                return userRole.Id;
            }
            //add user role
            var Role = new Role()
            {
                Id = new Guid(),
                RoleName = "user",
                RoleTitle = "کاربر"
            };
            await _Context.Roles.AddAsync(Role);
            await _Context.SaveChangesAsync();
            return Role.Id;
        }

        public async Task<bool> SetUserInfo(UserInfo userInfo)
        {
            try
            {
                var detail = await _Context.UserInfos.FindAsync(userInfo.UserId);
                if (detail != null)
                {
                    //_context.userInfos.Entry(userDetail).CurrentValues.SetValues(userDetail);
                    detail.Fname = userInfo.Fname;
                    detail.Lname = userInfo.Lname;
                    detail.City = userInfo.City;
                    detail.PostalCode = userInfo.PostalCode;
                    detail.Address = userInfo.Address;
                    detail.Province = userInfo.Province;
                    await _Context.SaveChangesAsync();
                    return true;
                }
                await _Context.UserInfos.AddAsync(userInfo);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine($"ERROR : SetUserDetails {error}");
                return false;
            }
        }
    }
}
