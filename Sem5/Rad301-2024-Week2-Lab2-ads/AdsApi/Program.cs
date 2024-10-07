using AdsApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdsDb>(opt => opt.UseInMemoryDatabase("AdsDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

RouteGroupBuilder adItems = app.MapGroup("/ads");

adItems.MapGet("/", GetAllAds);
adItems.MapGet("/{id}", GetAd);
adItems.MapPost("/", CreateAd);
adItems.MapPut("/{id}", UpdateAd);
adItems.MapDelete("/{id}", DeleteAd);

adItems.MapGet("/byseller/{sellerName}", GetAdsBySeller);
adItems.MapGet("/bycategory/{categoryName}", GetAdsByCategory);

app.Run();

static async Task<IResult> GetAdsBySeller(string sellerName, AdsDb db)
{
    return TypedResults.Ok(await db.Ads
        .Include(a => a.Seller)
        .Include(a => a.Category)
        .Where(a => a.Seller.Name == sellerName)
        .ToListAsync());
}

static async Task<IResult> GetAdsByCategory(string categoryName, AdsDb db)
{
    return TypedResults.Ok(await db.Ads
        .Include(a => a.Seller)
        .Include(a => a.Category)
        .Where(a => a.Category.Name == categoryName)
        .OrderBy(a => a.Description)
        .ToListAsync());
}


static async Task<IResult> GetAllAds(AdsDb db)
{
    return TypedResults.Ok(await db.Ads.Include(a => a.Seller).Include(a => a.Category).ToArrayAsync());
}

static async Task<IResult> GetAd(int id, AdsDb db)
{
    return await db.Ads.Include(a => a.Seller).Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id)
        is Ad ad
            ? TypedResults.Ok(ad)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateAd(Ad ad, AdsDb db)
{
    var seller = await db.Sellers.FirstOrDefaultAsync(s => s.Name == ad.Seller.Name);
    if (seller == null)
    {
        seller = ad.Seller;
        db.Sellers.Add(seller);
    }
    else
    {
        ad.Seller = seller;
    }

    var category = await db.Categories.FirstOrDefaultAsync(c => c.Name == ad.Category.Name);
    if (category == null)
    {
        category = ad.Category;
        db.Categories.Add(category);
    }
    else
    {
        ad.Category = category;
    }

    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/ads/{ad.Id}", ad);
}

static async Task<IResult> UpdateAd(int id, Ad newAd, AdsDb db)
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return TypedResults.NotFound();

    ad.Seller = newAd.Seller;
    ad.Category = newAd.Category;
    ad.Description = newAd.Description;
    ad.Price = newAd.Price;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteAd(int id, AdsDb db)
{
    if (await db.Ads.FindAsync(id) is Ad ad)
    {
        db.Ads.Remove(ad);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}