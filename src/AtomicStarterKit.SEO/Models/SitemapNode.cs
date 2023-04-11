using System;

namespace AtomicStarterKit.Sео.Models
{
    public class SitemapNode
    {
        public SitemapFrequency Frequency { get; set; } = SitemapFrequency.Daily;
        public DateTime LastModified { get; set; }
        public double Priority { get; set; } = 0.5;
        public string Url { get; set; }
    }
}