// <auto-generated/>
using ApiSdk.Models.ODataErrors;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.Extensions;
using Microsoft.Kiota.Cli.Commons.IO;
using Microsoft.Kiota.Cli.Commons;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Communications.Presences.Item.ClearUserPreferredPresence {
    /// <summary>
    /// Provides operations to call the clearUserPreferredPresence method.
    /// </summary>
    public class ClearUserPreferredPresenceRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// Clear the preferred availability and activity status for a user. This API is available in the following national cloud deployments.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0" />
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Clear the preferred availability and activity status for a user. This API is available in the following national cloud deployments.\n\nFind more info here:\n  https://learn.microsoft.com/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0";
            var presenceIdOption = new Option<string>("--presence-id", description: "The unique identifier of presence") {
            };
            presenceIdOption.IsRequired = true;
            command.AddOption(presenceIdOption);
            command.SetHandler(async (invocationContext) => {
                var presenceId = invocationContext.ParseResult.GetValueForOption(presenceIdOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToPostRequestInformation(q => {
                });
                if (presenceId is not null) requestInfo.PathParameters.Add("presence%2Did", presenceId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await reqAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new ClearUserPreferredPresenceRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public ClearUserPreferredPresenceRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/communications/presences/{presence%2Did}/clearUserPreferredPresence", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new ClearUserPreferredPresenceRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public ClearUserPreferredPresenceRequestBuilder(string rawUrl) : base("{+baseurl}/communications/presences/{presence%2Did}/clearUserPreferredPresence", rawUrl) {
        }
        /// <summary>
        /// Clear the preferred availability and activity status for a user. This API is available in the following national cloud deployments.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new RequestConfiguration<DefaultQueryParameters>();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            requestInfo.Headers.TryAdd("Accept", "application/json, application/json");
            return requestInfo;
        }
    }
}
