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
            var options = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            };

            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);

            try
            {
                var ListImages = new List<T>();
                var type = typeof(T);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (_urlValidade != false)
                {                    
                    browser.Navigate().GoToUrl(_url);
                    var images = browser.FindElementsByTagName("img");
                    foreach (var url in images)
                    {
                        _object = new T();
                        var attribute = url.GetAttribute("src").ToString();
                        if (!string.IsNullOrEmpty(attribute))
                        {
                            var property = properties.FirstOrDefault(x => x.Name.ToLower() == "url");
                            property.SetValue(_object, attribute);
                            ListImages.Add(_object);
                        }
                    }
                    return ListImages;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                browser.Quit();
            }
            
        }

        public List<string> GetWords()
        {
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            };

            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            try
            {
                if (_urlValidade != false)
                {
                    browser.Navigate().GoToUrl(_url);
                    var tags_p = browser.FindElementsByTagName("p");
                    //var tags_h1 = browser.FindElementsByTagName("h1");
                    //var tags_h2 = browser.FindElementsByTagName("h2");
                    //var tags_h3 = browser.FindElementsByTagName("h3");
                    //var tags_td = browser.FindElementsByTagName("td");
                    //var tags_i = browser.FindElementsByTagName("i");
                    //var tags_b = browser.FindElementsByTagName("b");
                    //var tags_a = browser.FindElementsByTagName("a");

                    var result_p = GenerateStringList(tags_p);
                    //var result_h1 = GenerateStringList(tags_h1);
                    //var result_h2 = GenerateStringList(tags_h2);
                    //var result_h3 = GenerateStringList(tags_h3);
                    //var result_td = GenerateStringList(tags_td);
                    //var result_i = GenerateStringList(tags_i);
                    //var result_b = GenerateStringList(tags_b);
                    //var result_a = GenerateStringList(tags_a);

                    var result = new List<string>();
                    result.AddRange(result_p);
                    //result.AddRange(result_h1);
                    //result.AddRange(result_h2);
                    //result.AddRange(result_h3);
                    //result.AddRange(result_td);
                    //result.AddRange(result_i);
                    //result.AddRange(result_b);
                    //result.AddRange(result_a);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                browser.Quit();
            }
        }

        public List<string> GenerateStringList(ReadOnlyCollection<IWebElement> elements)
        {
            List<string> result = new List<string>();
            foreach (var value in elements)
            {
                var values = value.Text.Split();
                foreach (var item in values)
                {
                    if (!string.IsNullOrEmpty(item))
                        result.Add(Regex.Replace(item, "[^a-zA-Z]+", ""));
                }
            }
            return result;
        }
    }
}
