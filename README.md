# Sitecore-ItemNamingRules

## Getting Started

The ItemNamingRules project provides conditions and actions for the rules engine to automate item name conventions. You can use the ItemNamingRules project to apply different item naming rules in different branches of the content tree. For more information about the rules engine, see the [Rules Engine Cookbook].

With the provided conditions, you can:

* Invoke actions if an item has layout details for the default device.
* Invoke actions if an item has layout details for any device.

With the provided actions, you can:

* Replace any character that does not match a regular expression with an alternate string.
* Merge sequences of invalid characters into a single instance of the alternate string.
* Remove leading and trailing instances of the alternate string.
* Restrict the maximum length of item names.
* Ensure unique item keys (names).
* Lowercase item names.

For example, you can configure an item naming rule such that if an item descends from the `/sitecore/content` item, and that item has layout details, then the name of the item must contain only lowercase letters, numbers, and underscores, cannot contain two sequential underscores, cannot begin or end with an underscore, cannot exceed 35 characters, and must not have any siblings with a common key. The ItemNamingRules project automatically renames the item, appending a datestamp if required to ensure unique keys.

You can use additional techniques to meet specific objectives when controlling item names. You can configure the `InvalidItemNameChars`, `ItemNameValidation`, and `MaxItemNameLength` settings in web.config, but these settings apply to all items rather than to items matching specific criteria. You can use pipelines to interact with CMS users when they invoke operations that affect item names, prompting the user to correct errors instead of correcting them automatically. You can also use validation including validation actions to flag and correct naming issues.

Note: The ItemNamingRules project will not rename standard values items, or the home item of any of the managed Web sites.

## Installation
The provided package `$(SolutionDir)\release\ItemNamingRules.Sitecore.Master.update` was created using [Team Development for Sitecore] and is supported with Sitecore 6.1-7. Navigate to http://yoursite/sitecore/admin/updateinstallationwizard.aspx and install the package.

## Configuration

Two rule conditions have been provided. For instructions to use either of these conditions in a rule, see the [Rules Engine Cookbook].

* `/sitecore/system/Settings/Rules/Common/Conditions/Presentation/Has Layout Details For Any Device`
* `/sitecore/system/Settings/Rules/Common/Conditions/Presentation/Has Layout Details For Default Device`

Four rule actions have been provided. For instructions to use these actions in a rule, see the [Rules Engine Cookbook].

* `/sitecore/system/Settings/Rules/Common/Actions/Ensure Item Name is Unique`
* `/sitecore/system/Settings/Rules/Common/Actions/Ensure Minimum Length of Item Name`
* `/sitecore/system/Settings/Rules/Common/Actions/Lowercase Item Name`
* `/sitecore/system/Settings/Rules/Common/Actions/Replace Invalid Characters in Item Name`

To manage item naming rules, in the Content Editor, select the `/sitecore/system/Settings/Rules/Item Saved/Rules` item. Insert rule definition items using the `System/Rules/Rule` data template. In the Rule field, click Edit Field, then select conditions, then add actions (in the order listed), and then enter parameters for the conditions and actions:

* `MatchPattern` - Regular expression for validating each character. For example, ^[A-Z|a-z|0-9|_]$.
* `ReplaceText` - Character or string for replacing invalid characters. For example, _.
* `DefaultName` - Characters to use to replace invalid characters in item name. Also defines minimum item name length. For example, given DefaultName 12345, the action will rename the item named A to A2345.
* `MaxLength` - Maximum item name length. For example, 25.
* `Device` - the device for which the rule applies. 

## Credits
This code was provided by [John West] via 

- https://sitecorejohn.wordpress.com/2009/09/15/use-the-sitecore-6-1-rules-engine-to-control-item-names/
- http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx
- http://www.sitecore.net/Community/Technical-Blogs/John-West-Sitecore-Blog/Posts/2010/11/Use-the-Sitecore-Rules-Engine-to-Control-Item-Names.aspx

The starting point for this code was taken from the [Marketplace](http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx) with no functional modifications. This includes any changes that were outlined in the comments [here](http://www.sitecore.net/Community/Technical-Blogs/John-West-Sitecore-Blog/Posts/2010/11/Use-the-Sitecore-Rules-Engine-to-Control-Item-Names.aspx). The provided code was turned into a proper Visual Studio solution and installation package by [Sean Kearney]. 


[Rules Engine Cookbook]: http://sdn.sitecore.net/reference/sitecore%206/rules%20engine%20cookbook.aspx
[Team Development for Sitecore]: http://TeamDevelopmentForSitecore.com
[John West]: https://twitter.com/sitecorejohn
[Sean Kearney]: https://twitter.com/seankearney