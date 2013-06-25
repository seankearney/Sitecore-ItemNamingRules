//-----------------------------------------------------------------------------------
// <copyright file="RenamingAction.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.RenamingAction type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    using System;
    using Sitecore.Data.Items;
    using Sitecore.Rules;
    using Sitecore.Rules.Actions;

    /// <summary>
    /// Base class for rules engine actions that rename items.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public abstract class RenamingAction<T> : RuleAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Rename the item, unless it is a standard values item 
        /// or the start item for any of the managed Web sites.
        /// </summary>
        /// <param name="item">The item to rename.</param>
        /// <param name="newName">The new name for the item.</param>
        protected void RenameItem(Item item, string newName)
        {
            if (item.Template.StandardValues != null && item.ID == item.Template.StandardValues.ID)
            {
                return;
            }

            foreach (Sitecore.Web.SiteInfo site in Sitecore.Configuration.Factory.GetSiteInfoList())
            {
                if (String.Compare(site.RootPath + site.StartItem, item.Paths.FullPath, true) == 0)
                {
                    return;
                }
            }

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (new Sitecore.Data.Items.EditContext(item))
                {
                    using (new Sitecore.Data.Events.EventDisabler())
                    {
                        item.Name = newName;
                    }
                }
            }
        }
    }
}
