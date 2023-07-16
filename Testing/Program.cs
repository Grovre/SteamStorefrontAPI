using NUnit.Framework;
using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;

[TestFixture]
public class ApiTesting
{
    /*
     * Any information expected in the tests may change in the future,
     * but it does not necessarily mean the library became a failure.
     * Just update the expected arguments
     */
    
    [Test]
    public async Task AppDetailsTests()
    {
        var app = await AppDetails.GetAsync(460810);
        Assert.AreEqual("Vanquish", app.Name);
        Assert.AreEqual("USD", app.PriceOverview.Currency);
        Assert.Contains("SEGA", app.LegalNotice.Split());
        Assert.AreEqual(19.99, app.PriceOverview.Initial);
        Assert.AreEqual("game", app.Type);
        Assert.AreEqual("http://www.vanquishgame.com", app.Website);
        Assert.AreEqual(false, app.IsFree);

        app = await AppDetails.GetAsync(322330, "fr");
        Assert.AreEqual("Don't Starve Together", app.Name);
        Assert.AreEqual("EUR", app.PriceOverview.Currency);
        Assert.AreEqual(null, app.LegalNotice);
        Assert.AreEqual(14.99, app.PriceOverview.Initial);
        Assert.AreEqual("game", app.Type);
        Assert.AreEqual("http://www.dontstarvegame.com", app.Website);
        Assert.AreEqual(false, app.IsFree);

        app = await AppDetails.GetAsync(107410, "us", "en");
        Assert.AreEqual("Arma 3", app.Name);
        Assert.AreEqual("USD", app.PriceOverview.Currency);
        Assert.Contains("BattlEye", app.LegalNotice.Split());
        Assert.AreEqual(29.99, app.PriceOverview.Initial);
        Assert.AreEqual("game", app.Type);
        Assert.AreEqual("http://www.arma3.com", app.Website);
        Assert.AreEqual(false, app.IsFree);
    }

    [Test]
    public async Task FeaturedTests()
    {
        var featured = await Featured.GetAsync();
        var allFeatured = featured.FeaturedWin.Concat(featured.FeaturedMac).Concat(featured.FeaturedLinux).ToArray();
        Assert.IsTrue(allFeatured.Length > 0);
        Assert.That(featured.FeaturedWin.TrueForAll(info => info.WindowsAvailable));
        Assert.That(featured.FeaturedMac.TrueForAll(info => info.MacAvailable));
        Assert.That(featured.FeaturedLinux.TrueForAll(info => info.LinuxAvailable));
    }
    
    // Someone else can finish the tests
}