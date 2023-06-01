namespace Atomic.Sео.SitemapXml.Models;

public class SitemapXmlNode
{
	public SitemapXmlNode(string url, DateTime lastModified, string? changeFrequency, decimal priority)
	{
		Url = url;
		LastModified = lastModified;

		ChangeFrequency = string.IsNullOrWhiteSpace(changeFrequency)
						  ? SitemapChangeFrequency.Daily
						  : (SitemapChangeFrequency)Enum.Parse(typeof(SitemapChangeFrequency), changeFrequency);

		Priority = decimal.Equals(priority, decimal.Zero)
				   ? 0.5m
				   : priority;
	}

	public SitemapChangeFrequency ChangeFrequency { get; set; }
	public DateTime LastModified { get; set; }
	public decimal Priority { get; set; }
	public string Url { get; set; }
}