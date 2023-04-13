using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace net_mvc_vue_i18n_sample.ApiControllers;

public class ResourceController : ControllerBase
{
    // GET
    [HttpGet("/resources")]
    public Dictionary<string, Dictionary<string, string>> Index()
    {
        var rawResources = new List<LanguageResource>()
        {
            new()
            {
                Language = "en-us",
                Key = "hello_world",
                Text = "Hello World!"
            },
            new()
            {
                Language = "zh-tw",
                Key = "hello_world",
                Text = "你好世界！"
            },
            new()
            {
                Language = "ja-jp",
                Key = "hello_world",
                Text = "こんにちは世界!"
            },
            new()
            {
                Language = "en-us",
                Key = "only_english",
                Text = "there is no translation for this sentence."
            }, 
        };
        
        return rawResources.GroupBy(r => r.Language)
            .ToDictionary(
                r => r.Key,
                r => r.ToDictionary(
                    x => x.Key,
                    x => x.Text));
    }
}

public class LanguageResource
{
    public string Language { get; set; }
    public string Key { get; set; }
    public string Text { get; set; }
}