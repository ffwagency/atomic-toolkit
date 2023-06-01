//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v11.4.0+e52e987
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Seo Settings</summary>
	[PublishedModel("seoSettings")]
	public partial class SeoSettings : PublishedContentModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		public new const string ModelTypeAlias = "seoSettings";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<SeoSettings, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public SeoSettings(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Image Fallback
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("imageFallback")]
		public virtual global::System.Collections.Generic.IEnumerable<string> ImageFallback => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "imageFallback");

		///<summary>
		/// Meta Description Max Length: The default value is 150 characters.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("metaDescriptionMaxLength")]
		public virtual int MetaDescriptionMaxLength => this.Value<int>(_publishedValueFallback, "metaDescriptionMaxLength");

		///<summary>
		/// Robots Txt
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("robotsTxt")]
		public virtual string RobotsTxt => this.Value<string>(_publishedValueFallback, "robotsTxt");

		///<summary>
		/// Share Default Image: This image will be used when no other image is available.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("shareDefaultImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops ShareDefaultImage => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "shareDefaultImage");

		///<summary>
		/// Share Text Max Length: The default value is 190 characters.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("shareTextMaxLength")]
		public virtual int ShareTextMaxLength => this.Value<int>(_publishedValueFallback, "shareTextMaxLength");

		///<summary>
		/// Sitemap Cache Duration: Cache duration in hours. The default value is 1 hour.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("sitemapCacheDuration")]
		public virtual int SitemapCacheDuration => this.Value<int>(_publishedValueFallback, "sitemapCacheDuration");

		///<summary>
		/// Text Fallback
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("textFallback")]
		public virtual global::System.Collections.Generic.IEnumerable<string> TextFallback => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "textFallback");

		///<summary>
		/// Title Fallback
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("titleFallback")]
		public virtual global::System.Collections.Generic.IEnumerable<string> TitleFallback => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "titleFallback");

		///<summary>
		/// Turn Off Seo
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("turnOffSeo")]
		public virtual bool TurnOffSeo => this.Value<bool>(_publishedValueFallback, "turnOffSeo");

		///<summary>
		/// Turn Off Sitemap Cache
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("turnOffSitemapCache")]
		public virtual bool TurnOffSitemapCache => this.Value<bool>(_publishedValueFallback, "turnOffSitemapCache");
	}
}
