using Scraping.Core.Roles;
using Scraping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Scraping.Core.Services
{
    public class WordService<T> : IService<T> where T : new()
    {
        public List<T> Get(string url)
        {
            var obj = new T();
            var ListWords = new List<T>();
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            try
            {
                var words = new WebScraping<T>(url).GetWords();
                var result = (
                    from word in words
                    group words by word
                    ).ToList();
                foreach(var value in result)
                {
                    var propertyQuantity = properties.FirstOrDefault(x => x.Name.ToLower() == "quantity");
                    var propertyValue = properties.FirstOrDefault(x => x.Name.ToLower() == "value");
                    propertyQuantity.SetValue(obj, value.Count(), null);
                    propertyValue.SetValue(obj, value.Key, null);
                    ListWords.Add(obj);
                    words.Where(x => x == value.Key);
                }
                var listResult = (from work in ListWords
                                  orderby work.GetType().GetProperty("quantity") descending
                                  select work).Take(10);
                return listResult.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CalculateTotalWords(List<WordEntity> words)
        {
            try
            {
                return words.Select(x => x.Quantity).Sum();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
