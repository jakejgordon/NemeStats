﻿using System.Web.Optimization;

namespace UI
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Scripts/jquery-{version}.js")
				.Include("~/Scripts/jquery.cookie.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/jquery-ui-{version}.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/handlebars")
				.Include("~/Scripts/handlebars.js"));

			bundles.Add(new ScriptBundle("~/bundles/custom")
				.Include("~/Scripts/namespace-{version}.js")
				.Include("~/Scripts/Plugins/toEditBoxPlugin.js")
				.Include("~/Scripts/GamingGroup/gamingGroup.js")
				.Include("~/Scripts/CreatePlayedGame/createplayedgame.js")
				.Include("~/Scripts/Player/createOrUpdatePlayer.js")
				.Include("~/Scripts/Player/players.js")
				.Include("~/Scripts/GameDefinition/gameDefinitionAutoComplete.js")
				.Include("~/Scripts/GameDefinition/createGameDefinitionPartial.js")
				.Include("~/Scripts/GameDefinition/createGameDefinition.js")
				.Include("~/Scripts/GameDefinition/gameDefinitions.js")
				.Include("~/Scripts/Shared/_Layout.js")
				.Include("~/Scripts/Shared/_LoginPartial.js")
				.Include("~/Scripts/Shared/GoogleAnalytics.js"));

			bundles.Add(new StyleBundle("~/bundles/content/css").Include(
				"~/Content/bootstrap.min.css", new CssRewriteUrlTransform())
				.Include("~/Content/site.css",
					"~/Content/site-mobile.css",
					"~/Content/blog.css")
				.Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
				"~/Content/Themes/base/jquery-ui.css"));
		}
	}
}
