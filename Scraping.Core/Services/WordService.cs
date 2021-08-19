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
            var ListWords = new List<T>();
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            try
            {

                var propertyQuantity = properties.FirstOrDefault(x => x.Name.ToLower() == "quantity");
                var propertyValue = properties.FirstOrDefault(x => x.Name.ToLower() == "value");

                var words = new WebScraping<T>(url).GetWords();
                var result = (
                    from word in words
                    group words by word
                    ).ToList();
                foreach(var value in result)
                {
                    var obj = new T();
                    propertyQuantity.SetValue(obj, value.Key.Count());
                    propertyValue.SetValue(obj, value.Key.ToString());
                    ListWords.Add(obj);
                }

                return ListWords;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static List<T> CreateList<T>(params T[] elements)
        {
            return new List<T>(elements);
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
