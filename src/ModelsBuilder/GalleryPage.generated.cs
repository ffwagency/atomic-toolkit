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
	/// <summary>Gallery Page</summary>
	[PublishedModel("galleryPage")]
	public partial class GalleryPage : PublishedContentModel, IBasePage, ISeoBasePage
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		public new const string ModelTypeAlias = "galleryPage";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<GalleryPage, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public GalleryPage(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Dynamic Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("dynamicContent")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel DynamicContent => this.Value<global::Umbraco.Cms.Core.Models.Blocks.BlockListModel>(_publishedValueFallback, "dynamicContent");

		///<summary>
		/// Page Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("pageHeader")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel PageHeader => global::Umbraco.Cms.Web.Common.PublishedModels.BasePage.GetPageHeader(this, _publishedValueFallback);

		///<summary>
		/// Browser Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("browserTitle")]
		public virtual string BrowserTitle => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetBrowserTitle(this, _publishedValueFallback);

		///<summary>
		/// Canonical Url: Absolute Url
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("canonicalUrl")]
		public virtual string CanonicalUrl => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetCanonicalUrl(this, _publishedValueFallback);

		///<summary>
		/// Change Frequency: Default value is Daily.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("changeFrequency")]
		public virtual string ChangeFrequency => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetChangeFrequency(this, _publishedValueFallback);

		///<summary>
		/// Meta Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaDescription")]
		public virtual string MetaDescription => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetMetaDescription(this, _publishedValueFallback);

		///<summary>
		/// Meta Keywords
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaKeywords")]
		public virtual global::System.Collections.Generic.IEnumerable<string> MetaKeywords => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetMetaKeywords(this, _publishedValueFallback);

		///<summary>
		/// No Follow
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("noFollow")]
		public virtual bool NoFollow => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetNoFollow(this, _publishedValueFallback);

		///<summary>
		/// No Index
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("noIndex")]
		public virtual bool NoIndex => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetNoIndex(this, _publishedValueFallback);

		///<summary>
		/// Priority: Default value is 0.5
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[ImplementPropertyType("priority")]
		public virtual decimal Priority => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetPriority(this, _publishedValueFallback);

		///<summary>
		/// Share Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("shareImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops ShareImage => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetShareImage(this, _publishedValueFallback);

		///<summary>
		/// Share Text
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("shareText")]
		public virtual string ShareText => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetShareText(this, _publishedValueFallback);

		///<summary>
		/// Share Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.4.0+e52e987")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("shareTitle")]
		public virtual string ShareTitle => global::Umbraco.Cms.Web.Common.PublishedModels.SeoBasePage.GetShareTitle(this, _publishedValueFallback);
	}
}
