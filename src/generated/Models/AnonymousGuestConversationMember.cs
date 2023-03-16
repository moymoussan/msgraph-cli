using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class AnonymousGuestConversationMember : ConversationMember, IParsable {
        /// <summary>Unique ID that represents the user. Note: This ID can change if the user leaves and rejoins the meeting, or joins from a different device.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AnonymousGuestId { get; set; }
#nullable restore
#else
        public string AnonymousGuestId { get; set; }
#endif
        /// <summary>
        /// Instantiates a new AnonymousGuestConversationMember and sets the default values.
        /// </summary>
        public AnonymousGuestConversationMember() : base() {
            OdataType = "#microsoft.graph.anonymousGuestConversationMember";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AnonymousGuestConversationMember CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AnonymousGuestConversationMember();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"anonymousGuestId", n => { AnonymousGuestId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("anonymousGuestId", AnonymousGuestId);
        }
    }
}
