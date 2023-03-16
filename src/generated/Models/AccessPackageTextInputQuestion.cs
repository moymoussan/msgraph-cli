using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class AccessPackageTextInputQuestion : AccessPackageQuestion, IParsable {
        /// <summary>Indicates whether the answer will be in single or multiple line format.</summary>
        public bool? IsSingleLineQuestion { get; set; }
        /// <summary>The regular expression pattern which any answer to this question must match.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RegexPattern { get; set; }
#nullable restore
#else
        public string RegexPattern { get; set; }
#endif
        /// <summary>
        /// Instantiates a new AccessPackageTextInputQuestion and sets the default values.
        /// </summary>
        public AccessPackageTextInputQuestion() : base() {
            OdataType = "#microsoft.graph.accessPackageTextInputQuestion";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AccessPackageTextInputQuestion CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageTextInputQuestion();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isSingleLineQuestion", n => { IsSingleLineQuestion = n.GetBoolValue(); } },
                {"regexPattern", n => { RegexPattern = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("isSingleLineQuestion", IsSingleLineQuestion);
            writer.WriteStringValue("regexPattern", RegexPattern);
        }
    }
}
