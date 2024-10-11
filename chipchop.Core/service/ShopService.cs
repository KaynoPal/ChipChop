using chipchop.Core.Interface;
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using chipchop.Core.ViewModels;
using chipchop.Core.Classes;

namespace chipchop.Core.service;

public class ShopService : IShopping
{
    private readonly DatabaseContext _Context;
    public ShopService(DatabaseContext Context)
    {
        _Context = Context;
    }

    public async Task<Factor> AddFactor(AddShoppingVM shopping)
    {
        try
        {
            //get factor
            var factor =
                await _Context.Factors
                .FirstOrDefaultAsync(f => f.UserId == shopping.Userid && f.IsPay == false);

            if (factor != null)
            {
                //add to open factor details
                var newDetail = new FactorDetail()
                {
                    FactorId = factor.Id,
                    ContentId = shopping.Contentid,
                    DetailCount = shopping.Shoppingcount
                };

                await _Context.FactorDetails.AddAsync(newDetail);
                await _Context.SaveChangesAsync();

                factor.Details.Add(newDetail);
                return factor;
            }
            else
            {
                //create new factor
                var newFactor = new Factor()
                {
                    Id = new Random().Next(10000, 100000),
                    UserId = shopping.Userid,
                    IsPay = false,
                    Status = new FactorStatusVM().StatusArray[0]
                };
                await _Context.Factors.AddAsync(newFactor);

                //add factorDetail
                var newDetail = new FactorDetail()
                {
                    FactorId = newFactor.Id,
                    ContentId = shopping.Contentid,
                    DetailCount = shopping.Shoppingcount
                };
                await _Context.FactorDetails.AddAsync(newDetail);
                await _Context.SaveChangesAsync();
                return newFactor;
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"add factor error => {error}");
            return null;
        }
    }

    public void Dispose()
    {
        if (_Context != null)
        {
            _Context.Dispose();
        }
    }

    public async Task<Factor> GetFactor(Guid userId)
    {
        var factor = await _Context.Factors.Include(f => f.Details).Include("Details.Content").FirstOrDefaultAsync
            (f => f.UserId == userId && !f.IsPay);
        return factor;
    }

    public async Task<Factor> GetFactor(int factorId)
    {
        var factor = await _Context.Factors.Include(f => f.Details).FirstOrDefaultAsync(f => f.Id == factorId);
        return factor;
    }

    public async Task<List<Factor>> GetMyOrders(Guid userid)
    {
        var factors = await _Context.Factors.Where(f => f.UserId == userid).ToListAsync();
        return factors;
    }

    public async Task<List<Factor>> GetOrders()
    {
        var factors = await _Context.Factors.Where(f => f.IsPay == true).ToListAsync();
        return factors;
    }

    public async Task<int> SetFactor(Guid userId)
    {
        var factor = await _Context.Factors.Include(f => f.Details)
            .FirstOrDefaultAsync(f => f.UserId == userId && !f.IsPay);

        if (factor == null)
            return 0;

        var factorPrice = 0;

        foreach (var item in factor.Details)
        {
            var content = await _Context.Contents.FindAsync(item.ContentId);
            if (content == null) continue;
            //var productPrice = content.price * (100 - content.Selloff) / 100;
            factorPrice += item.DetailCount * content.price;
        }

        factor.TotalPrice = factorPrice;
        await _Context.SaveChangesAsync();
        return factor.Id;
    }

    public async Task<int> SetFactor(int factorId, string refId, bool isPay = false)
    {
        var factor = await _Context.Factors.FindAsync(factorId);

        factor.IsPay = isPay;
        factor.PayInfo = refId;

        if (isPay)
        {
            factor.PayDate = new DateTimeGen().GetPersianTime();
            factor.Status = new FactorStatusVM().StatusArray[1];
        }

        await _Context.SaveChangesAsync();
        return factor.Id;
    }
}
