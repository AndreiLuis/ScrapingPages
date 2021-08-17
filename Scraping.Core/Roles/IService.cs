using System;
using System.Collections.Generic;
using System.Text;

namespace Scraping.Core.Roles
{
    public interface IService<T>
    {
        List<T> Get(string url);
    }
}
