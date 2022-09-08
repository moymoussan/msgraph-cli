using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class ItemReference : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Unique identifier of the drive instance that contains the item. Read-only.</summary>
        public string DriveId { get; set; }
        /// <summary>Identifies the type of drive. See [drive][] resource for values.</summary>
        public string DriveType { get; set; }
        /// <summary>Unique identifier of the item in the drive. Read-only.</summary>
        public string Id { get; set; }
        /// <summary>The name of the item being referenced. Read-only.</summary>
        public string Name { get; set; }
        /// <summary>The OdataType property</summary>
        public string OdataType { get; set; }
        /// <summary>Path that can be used to navigate to the item. Read-only.</summary>
        public string PathObject { get; set; }
        /// <summary>A unique identifier for a shared resource that can be accessed via the [Shares][] API.</summary>
        public string ShareId { get; set; }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public ApiSdk.Models.SharepointIds SharepointIds { get; set; }
        /// <summary>For OneDrive for Business and SharePoint, this property represents the ID of the site that contains the parent document library of the driveItem resource. The value is the same as the id property of that [site][] resource. It is an opaque string that consists of three identifiers of the site. For OneDrive, this property is not populated.</summary>
        public string SiteId { get; set; }
        /// <summary>
        /// Instantiates a new itemReference and sets the default values.
        /// </summary>
        public ItemReference() {
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.itemReference";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ItemReference CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemReference();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"driveId", n => { DriveId = n.GetStringValue(); } },
                {"driveType", n => { DriveType = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"path", n => { PathObject = n.GetStringValue(); } },
                {"shareId", n => { ShareId = n.GetStringValue(); } },
                {"sharepointIds", n => { SharepointIds = n.GetObjectValue<ApiSdk.Models.SharepointIds>(ApiSdk.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"siteId", n => { SiteId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("driveId", DriveId);
            writer.WriteStringValue("driveType", DriveType);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteStringValue("path", PathObject);
            writer.WriteStringValue("shareId", ShareId);
            writer.WriteObjectValue<ApiSdk.Models.SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteStringValue("siteId", SiteId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}