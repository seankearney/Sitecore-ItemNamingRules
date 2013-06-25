//-----------------------------------------------------------------------------------
// <copyright file="Lowercase.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.Lowercase type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    using Sitecore.Rules;

    /// <summary>
    /// Rules engine action to lowercase item names.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class Lowercase<T> : RenamingAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            string newName = ruleContext.Item.Name.ToLower();

            if (ruleContext.Item.Name != newName)
            {
                this.RenameItem(ruleContext.Item, newName);
            }
        }
    }
}
