using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class AutomaticRepliesSetting : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The set of audience external to the signed-in user&apos;s organization who will receive the ExternalReplyMessage, if Status is AlwaysEnabled or Scheduled. The possible values are: none, contactsOnly, all.</summary>
        public ExternalAudienceScope? ExternalAudience { get; set; }
        /// <summary>The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.</summary>
        public string ExternalReplyMessage { get; set; }
        /// <summary>The automatic reply to send to the audience internal to the signed-in user&apos;s organization, if Status is AlwaysEnabled or Scheduled.</summary>
        public string InternalReplyMessage { get; set; }
        /// <summary>The OdataType property</summary>
        public string OdataType { get; set; }
        /// <summary>The date and time that automatic replies are set to end, if Status is set to Scheduled.</summary>
        public DateTimeTimeZone ScheduledEndDateTime { get; set; }
        /// <summary>The date and time that automatic replies are set to begin, if Status is set to Scheduled.</summary>
        public DateTimeTimeZone ScheduledStartDateTime { get; set; }
        /// <summary>Configurations status for automatic replies. The possible values are: disabled, alwaysEnabled, scheduled.</summary>
        public AutomaticRepliesStatus? Status { get; set; }
        /// <summary>
        /// Instantiates a new automaticRepliesSetting and sets the default values.
        /// </summary>
        public AutomaticRepliesSetting() {
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.automaticRepliesSetting";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AutomaticRepliesSetting CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AutomaticRepliesSetting();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"externalAudience", n => { ExternalAudience = n.GetEnumValue<ExternalAudienceScope>(); } },
                {"externalReplyMessage", n => { ExternalReplyMessage = n.GetStringValue(); } },
                {"internalReplyMessage", n => { InternalReplyMessage = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"scheduledEndDateTime", n => { ScheduledEndDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"scheduledStartDateTime", n => { ScheduledStartDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<AutomaticRepliesStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<ExternalAudienceScope>("externalAudience", ExternalAudience);
            writer.WriteStringValue("externalReplyMessage", ExternalReplyMessage);
            writer.WriteStringValue("internalReplyMessage", InternalReplyMessage);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledEndDateTime", ScheduledEndDateTime);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledStartDateTime", ScheduledStartDateTime);
            writer.WriteEnumValue<AutomaticRepliesStatus>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}