using System.Text;

namespace SteamStorefrontAPI.Classes;

public class SteamUriBuilder
{
    public string BaseUri { get; set; }
    public string? Lang { get; set; }
    public string? CountryCode { get; set; }
    public int? AppId { get; set; }
    private bool _queryAdded = false;

    public SteamUriBuilder(string baseUri)
    {
        BaseUri = $"{baseUri}{(baseUri[^1] == '?' ? string.Empty : "?")}";
    }

    public SteamUriBuilder SetBaseUri(string baseUri)
    {
        BaseUri = baseUri;
        return this;
    }

    public SteamUriBuilder SetLang(string language)
    {
        Lang = language;
        return this;
    }

    public SteamUriBuilder SetCountryCode(string countryCode)
    {
        CountryCode = countryCode;
        return this;
    }

    public SteamUriBuilder SetAppId(int appId)
    {
        AppId = appId;
        return this;
    }

    public string Build()
    {
        var uriStringBuilder = new StringBuilder(BaseUri);
        
        if (AppId != null)
            AppendQuery(uriStringBuilder, SteamUriQueryKeys.AppId, AppId.ToString());

        if (!string.IsNullOrWhiteSpace(Lang))
            AppendQuery(uriStringBuilder, SteamUriQueryKeys.Lang, Lang);
        
        if (!string.IsNullOrWhiteSpace(CountryCode))
            AppendQuery(uriStringBuilder, SteamUriQueryKeys.CountryCode, CountryCode);

        return uriStringBuilder.ToString();
    }

    private void AppendQuery(StringBuilder uriSb, string key, string value)
    {
        if (!_queryAdded && uriSb[^1] != '?')
            uriSb.Append('?');
        
        if (_queryAdded)
            uriSb.Append('&');
        
        _queryAdded = true;
        uriSb.Append(key).Append('=').Append(value);
    }
}

public static class SteamUriQueryKeys
{
    public static readonly string Lang = "l";
    public static readonly string CountryCode = "cc";
    public static readonly string AppId = "appids";
}