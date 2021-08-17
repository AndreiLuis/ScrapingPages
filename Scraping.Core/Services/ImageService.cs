using Scraping.Core.Roles;
using Scraping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scraping.Core.Services
{
    public class ImageService<T> : IService<T> where T : new()
    {
        public List<T> Get(string url)
        {
            try
            {
                var images = new WebScraping<T>(url).GetImages();
                return images;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
