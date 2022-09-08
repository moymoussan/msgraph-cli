using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class MeetingParticipants : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The attendees property</summary>
        public List<MeetingParticipantInfo> Attendees { get; set; }
        /// <summary>The OdataType property</summary>
        public string OdataType { get; set; }
        /// <summary>The organizer property</summary>
        public MeetingParticipantInfo Organizer { get; set; }
        /// <summary>
        /// Instantiates a new meetingParticipants and sets the default values.
        /// </summary>
        public MeetingParticipants() {
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.meetingParticipants";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MeetingParticipants CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MeetingParticipants();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attendees", n => { Attendees = n.GetCollectionOfObjectValues<MeetingParticipantInfo>(MeetingParticipantInfo.CreateFromDiscriminatorValue).ToList(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"organizer", n => { Organizer = n.GetObjectValue<MeetingParticipantInfo>(MeetingParticipantInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<MeetingParticipantInfo>("attendees", Attendees);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteObjectValue<MeetingParticipantInfo>("organizer", Organizer);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}