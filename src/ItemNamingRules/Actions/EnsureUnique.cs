//-----------------------------------------------------------------------------------
// <copyright file="EnsureUnique.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.EnsureUnique type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    using System;
    using Sitecore.Rules;

    /// <summary>
    /// Rules engine action to ensure unique item names under a parent
    /// by replacing trailing characters with a date/time stamp.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class EnsureUnique<T> : RenamingAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Gets or sets the maximum allowed length for item names.
        /// </summary>
        public int MaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.Name.Length > this.MaxLength)
            {
                this.RenameItem(
                  ruleContext.Item,
                  ruleContext.Item.Name.Substring(0, this.MaxLength));
            }

            bool unique;

            do
            {
                unique = true;

                foreach (Sitecore.Data.Items.Item child
                  in ruleContext.Item.Parent.Children)
                {
                    if (child.ID.Equals(ruleContext.Item.ID)
                      || !child.Key.Equals(ruleContext.Item.Key))
                    {
                        continue;
                    }

                    unique = false;
                    string strDateTime = Sitecore.DateUtil.ToIsoDate(
                      DateTime.Now).ToLower();
                    string newName = ruleContext.Item.Name + strDateTime;

                    if (this.MaxLength > 0 && newName.Length > this.MaxLength)
                    {
                        newName = newName.Substring(
                          0,
                          this.MaxLength - (strDateTime.Length + 1)) + strDateTime;
                    }

                    this.RenameItem(ruleContext.Item, newName);
                    break;
                }
            }
            while (!unique);
        }
    }
}
