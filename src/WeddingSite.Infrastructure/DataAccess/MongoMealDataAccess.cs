using LanguageExt.Common;
using MongoDB.Driver;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess;

public class MongoMealDataAccess : IMealDataAccess
{
    private IMongoCollection<Meal> _mealCollection;
    
    public MongoMealDataAccess(
        IMongoClient client)
    {
        var database = client.GetDatabase("weddingsite");
        _mealCollection = database.GetCollection<Meal>("meals");
    }
    
    public async Task<Result<Meal[]>> GetAllMeals(CancellationToken cancellationToken)
    {
        try
        {
            var result = await (await _mealCollection.FindAsync(m => true, cancellationToken: cancellationToken))
                .ToListAsync(cancellationToken);

            return new Result<Meal[]>(result.ToArray());
        }
        catch (Exception e)
        {
            return new Result<Meal[]>(e);
        }
    }
}