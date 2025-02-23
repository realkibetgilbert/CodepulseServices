﻿namespace Codepulse.API.DTOs.BlogPost
{
    public class BlogPostToUpdate
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }

        public List<int> Categories { get; set; }= new List<int>();
    }
}
