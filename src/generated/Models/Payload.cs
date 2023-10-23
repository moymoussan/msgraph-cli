// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models {
    public class Payload : Entity, IParsable {
        /// <summary>The brand property</summary>
        public PayloadBrand? Brand { get; set; }
        /// <summary>The complexity property</summary>
        public PayloadComplexity? Complexity { get; set; }
        /// <summary>The createdBy property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EmailIdentity? CreatedBy { get; set; }
#nullable restore
#else
        public EmailIdentity CreatedBy { get; set; }
#endif
        /// <summary>The createdDateTime property</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>The detail property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PayloadDetail? Detail { get; set; }
#nullable restore
#else
        public PayloadDetail Detail { get; set; }
#endif
        /// <summary>The displayName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName { get; set; }
#nullable restore
#else
        public string DisplayName { get; set; }
#endif
        /// <summary>The industry property</summary>
        public PayloadIndustry? Industry { get; set; }
        /// <summary>The isAutomated property</summary>
        public bool? IsAutomated { get; set; }
        /// <summary>The isControversial property</summary>
        public bool? IsControversial { get; set; }
        /// <summary>The isCurrentEvent property</summary>
        public bool? IsCurrentEvent { get; set; }
        /// <summary>The language property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Language { get; set; }
#nullable restore
#else
        public string Language { get; set; }
#endif
        /// <summary>The lastModifiedBy property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EmailIdentity? LastModifiedBy { get; set; }
#nullable restore
#else
        public EmailIdentity LastModifiedBy { get; set; }
#endif
        /// <summary>The lastModifiedDateTime property</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>The payloadTags property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? PayloadTags { get; set; }
#nullable restore
#else
        public List<string> PayloadTags { get; set; }
#endif
        /// <summary>The platform property</summary>
        public PayloadDeliveryPlatform? Platform { get; set; }
        /// <summary>The predictedCompromiseRate property</summary>
        public double? PredictedCompromiseRate { get; set; }
        /// <summary>The simulationAttackType property</summary>
        public ApiSdk.Models.SimulationAttackType? SimulationAttackType { get; set; }
        /// <summary>The source property</summary>
        public SimulationContentSource? Source { get; set; }
        /// <summary>The status property</summary>
        public SimulationContentStatus? Status { get; set; }
        /// <summary>The technique property</summary>
        public SimulationAttackTechnique? Technique { get; set; }
        /// <summary>The theme property</summary>
        public PayloadTheme? Theme { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Payload CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Payload();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"brand", n => { Brand = n.GetEnumValue<PayloadBrand>(); } },
                {"complexity", n => { Complexity = n.GetEnumValue<PayloadComplexity>(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<EmailIdentity>(EmailIdentity.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"detail", n => { Detail = n.GetObjectValue<PayloadDetail>(PayloadDetail.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"industry", n => { Industry = n.GetEnumValue<PayloadIndustry>(); } },
                {"isAutomated", n => { IsAutomated = n.GetBoolValue(); } },
                {"isControversial", n => { IsControversial = n.GetBoolValue(); } },
                {"isCurrentEvent", n => { IsCurrentEvent = n.GetBoolValue(); } },
                {"language", n => { Language = n.GetStringValue(); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<EmailIdentity>(EmailIdentity.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"payloadTags", n => { PayloadTags = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"platform", n => { Platform = n.GetEnumValue<PayloadDeliveryPlatform>(); } },
                {"predictedCompromiseRate", n => { PredictedCompromiseRate = n.GetDoubleValue(); } },
                {"simulationAttackType", n => { SimulationAttackType = n.GetEnumValue<SimulationAttackType>(); } },
                {"source", n => { Source = n.GetEnumValue<SimulationContentSource>(); } },
                {"status", n => { Status = n.GetEnumValue<SimulationContentStatus>(); } },
                {"technique", n => { Technique = n.GetEnumValue<SimulationAttackTechnique>(); } },
                {"theme", n => { Theme = n.GetEnumValue<PayloadTheme>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<PayloadBrand>("brand", Brand);
            writer.WriteEnumValue<PayloadComplexity>("complexity", Complexity);
            writer.WriteObjectValue<EmailIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteObjectValue<PayloadDetail>("detail", Detail);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteEnumValue<PayloadIndustry>("industry", Industry);
            writer.WriteBoolValue("isAutomated", IsAutomated);
            writer.WriteBoolValue("isControversial", IsControversial);
            writer.WriteBoolValue("isCurrentEvent", IsCurrentEvent);
            writer.WriteStringValue("language", Language);
            writer.WriteObjectValue<EmailIdentity>("lastModifiedBy", LastModifiedBy);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("payloadTags", PayloadTags);
            writer.WriteEnumValue<PayloadDeliveryPlatform>("platform", Platform);
            writer.WriteDoubleValue("predictedCompromiseRate", PredictedCompromiseRate);
            writer.WriteEnumValue<SimulationAttackType>("simulationAttackType", SimulationAttackType);
            writer.WriteEnumValue<SimulationContentSource>("source", Source);
            writer.WriteEnumValue<SimulationContentStatus>("status", Status);
            writer.WriteEnumValue<SimulationAttackTechnique>("technique", Technique);
            writer.WriteEnumValue<PayloadTheme>("theme", Theme);
        }
    }
}
