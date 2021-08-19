using System;
using System.Collections.Generic;
using System.Text;

namespace Scraping.Domain.Entities
{
    public class PageEntity
    {
        public PageEntity(){}
        public PageEntity(string link)
        {
            Link = link;
        }

        public string Link { get; set; }
    }
}
