using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scraping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Scraping.Core
{
    public class WebScraping<T> where T : new()
    {
        private Regex _regex  = new Regex(@"^((http|ftp|https|www)://)?([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$");
        private bool _urlValidade = false;

        private string _url = null;
        private T _object { get; set; }
        public WebScraping(string url)
        {
            _url = url;
            _urlValidade = _regex.IsMatch(url);
        }

        public List<T> GetImages()
        {

            var ListImages = new List<T>();
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (_urlValidade != false)
            {
                var options = new ChromeOptions()
                {
                    BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
                };

                options.AddArguments(new List<string>() { "headless", "disable-gpu" });
                var browser = new ChromeDriver(options);
                browser.Navigate().GoToUrl(_url);
                var images = browser.FindElementsByTagName("img");
                foreach (var url in images)
                {

                    _object = new T();
                    var property = properties.FirstOrDefault(x => x.Name.ToLower() == "url");
                    property.SetValue(_object, url.GetAttribute("src"), null);
                    ListImages.Add(_object);
                }
                return ListImages;
            }
            return null;
        }

        public List<string> GetWords()
        {
            if (_urlValidade != false)
            {
                var options = new ChromeOptions()
                {
                    BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
                };

                options.AddArguments(new List<string>() { "headless", "disable-gpu" });
                var browser = new ChromeDriver(options);
                browser.Navigate().GoToUrl(_url);
                var allTags = browser.FindElementsByTagName("*");
                var result = GenerateStringList(allTags);
                //var words = tagP.Join(tagH1);
                return result;
            }
            return null;
        }

        public List<string> GenerateStringList(ReadOnlyCollection<IWebElement> elements)
        {
            List<string> result = new List<string>();
            foreach (var value in elements)
            {
                result.Add(value.Text);
            }
            return result;
        }
    }
}
