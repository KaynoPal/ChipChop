using chipchop.Datalayer.Models;
using chipchop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Core.Interface;

public interface IShopping:IDisposable
{
    public Task<Factor> AddFactor(AddShoppingVM shopping);
    public Task<Factor> GetFactor(Guid userId);
    public Task<Factor> GetFactor(int factorId);
    public Task<int> SetFactor(Guid userId);//set totall price
    public Task<int> SetFactor(int factorId, string refId, bool isPay = false);
    public Task<List<Factor>> GetOrders();
    public Task<List<Factor>> GetMyOrders(Guid userid);
}
