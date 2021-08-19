using System;
using System.Collections.Generic;
using System.Text;

namespace Scraping.Domain.Entities
{
    public class DataReturnEntity
    {
        public DataReturnEntity() { }

        public DataReturnEntity(List<ImageEntity> images, List<WordEntity> words, int totalWords)
        {
            Images = images;
            Words = words;
            TotaltWords = totalWords;
        }

        public List<ImageEntity> Images { get; set; }
        public List<WordEntity> Words { get; set; }
        public int TotaltWords { get; set; }
    }
}
