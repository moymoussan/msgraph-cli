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
namespace ApiSdk.Contacts.Item.RetryServiceProvisioning {
    /// <summary>
    /// Provides operations to call the retryServiceProvisioning method.
    /// </summary>
    public class RetryServiceProvisioningRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// Invoke action retryServiceProvisioning
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Invoke action retryServiceProvisioning";
            var orgContactIdOption = new Option<string>("--org-contact-id", description: "The unique identifier of orgContact") {
            };
            orgContactIdOption.IsRequired = true;
            command.AddOption(orgContactIdOption);
            command.SetHandler(async (invocationContext) => {
                var orgContactId = invocationContext.ParseResult.GetValueForOption(orgContactIdOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToPostRequestInformation(q => {
                });
                if (orgContactId is not null) requestInfo.PathParameters.Add("orgContact%2Did", orgContactId);
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
        /// Instantiates a new RetryServiceProvisioningRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public RetryServiceProvisioningRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/contacts/{orgContact%2Did}/retryServiceProvisioning", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new RetryServiceProvisioningRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public RetryServiceProvisioningRequestBuilder(string rawUrl) : base("{+baseurl}/contacts/{orgContact%2Did}/retryServiceProvisioning", rawUrl) {
        }
        /// <summary>
        /// Invoke action retryServiceProvisioning
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
