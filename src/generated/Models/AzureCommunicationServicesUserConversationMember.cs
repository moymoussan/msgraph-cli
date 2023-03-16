using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class AzureCommunicationServicesUserConversationMember : ConversationMember, IParsable {
        /// <summary>Azure Communication Services ID of the user.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AzureCommunicationServicesId { get; set; }
#nullable restore
#else
        public string AzureCommunicationServicesId { get; set; }
#endif
        /// <summary>
        /// Instantiates a new AzureCommunicationServicesUserConversationMember and sets the default values.
        /// </summary>
        public AzureCommunicationServicesUserConversationMember() : base() {
            OdataType = "#microsoft.graph.azureCommunicationServicesUserConversationMember";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AzureCommunicationServicesUserConversationMember CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AzureCommunicationServicesUserConversationMember();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"azureCommunicationServicesId", n => { AzureCommunicationServicesId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("azureCommunicationServicesId", AzureCommunicationServicesId);
        }
    }
}
