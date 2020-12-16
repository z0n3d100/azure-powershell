namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Target copy settings</summary>
    [System.ComponentModel.TypeConverter(typeof(TargetCopySettingTypeConverter))]
    public partial class TargetCopySetting
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TargetCopySetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TargetCopySetting(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TargetCopySetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TargetCopySetting(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TargetCopySetting" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TargetCopySetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TargetCopySetting(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfter = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption) content.GetValueForProperty("CopyAfter",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfter, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.CopyOptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStore = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase) content.GetValueForProperty("DataStore",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStore, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DataStoreInfoBaseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfterObjectType = (string) content.GetValueForProperty("CopyAfterObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfterObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) content.GetValueForProperty("DataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreObjectType = (string) content.GetValueForProperty("DataStoreObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreObjectType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TargetCopySetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TargetCopySetting(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfter = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption) content.GetValueForProperty("CopyAfter",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfter, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.CopyOptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStore = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase) content.GetValueForProperty("DataStore",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStore, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DataStoreInfoBaseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfterObjectType = (string) content.GetValueForProperty("CopyAfterObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).CopyAfterObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) content.GetValueForProperty("DataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreObjectType = (string) content.GetValueForProperty("DataStoreObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal)this).DataStoreObjectType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Target copy settings
    [System.ComponentModel.TypeConverter(typeof(TargetCopySettingTypeConverter))]
    public partial interface ITargetCopySetting

    {

    }
}