using ApiSdk.External.Connections.Item.Groups.Item.Members;
using ApiSdk.Models.ExternalConnectors;
using ApiSdk.Models.ODataErrors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.External.Connections.Item.Groups.Item {
    /// <summary>Provides operations to manage the groups property of the microsoft.graph.externalConnectors.externalConnection entity.</summary>
    public class ExternalGroupItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete navigation property groups for external
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property groups for external";
            // Create options for all the parameters
            var externalConnectionIdOption = new Option<string>("--external-connection-id", description: "key: id of externalConnection") {
            };
            externalConnectionIdOption.IsRequired = true;
            command.AddOption(externalConnectionIdOption);
            var externalGroupIdOption = new Option<string>("--external-group-id", description: "key: id of externalGroup") {
            };
            externalGroupIdOption.IsRequired = true;
            command.AddOption(externalGroupIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var externalConnectionId = invocationContext.ParseResult.GetValueForOption(externalConnectionIdOption);
                var externalGroupId = invocationContext.ParseResult.GetValueForOption(externalGroupIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("externalConnection%2Did", externalConnectionId);
                requestInfo.PathParameters.Add("externalGroup%2Did", externalGroupId);
                requestInfo.Headers["If-Match"] = ifMatch;
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Get groups from external
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Get groups from external";
            // Create options for all the parameters
            var externalConnectionIdOption = new Option<string>("--external-connection-id", description: "key: id of externalConnection") {
            };
            externalConnectionIdOption.IsRequired = true;
            command.AddOption(externalConnectionIdOption);
            var externalGroupIdOption = new Option<string>("--external-group-id", description: "key: id of externalGroup") {
            };
            externalGroupIdOption.IsRequired = true;
            command.AddOption(externalGroupIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var expandOption = new Option<string[]>("--expand", description: "Expand related entities") {
                Arity = ArgumentArity.ZeroOrMore
            };
            expandOption.IsRequired = false;
            command.AddOption(expandOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var jsonNoIndentOption = new Option<bool>("--json-no-indent", r => {
                if (bool.TryParse(r.Tokens.Select(t => t.Value).LastOrDefault(), out var value)) {
                    return value;
                }
                return true;
            }, description: "Disable indentation for the JSON output formatter.");
            command.AddOption(jsonNoIndentOption);
            command.SetHandler(async (invocationContext) => {
                var externalConnectionId = invocationContext.ParseResult.GetValueForOption(externalConnectionIdOption);
                var externalGroupId = invocationContext.ParseResult.GetValueForOption(externalGroupIdOption);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var expand = invocationContext.ParseResult.GetValueForOption(expandOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                var jsonNoIndent = invocationContext.ParseResult.GetValueForOption(jsonNoIndentOption);
                var outputFilter = invocationContext.BindingContext.GetRequiredService<IOutputFilter>();
                var outputFormatterFactory = invocationContext.BindingContext.GetRequiredService<IOutputFormatterFactory>();
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                requestInfo.PathParameters.Add("externalConnection%2Did", externalConnectionId);
                requestInfo.PathParameters.Add("externalGroup%2Did", externalGroupId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            });
            return command;
        }
        public Command BuildMembersCommand() {
            var command = new Command("members");
            var builder = new MembersRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Update the navigation property groups in external
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property groups in external";
            // Create options for all the parameters
            var externalConnectionIdOption = new Option<string>("--external-connection-id", description: "key: id of externalConnection") {
            };
            externalConnectionIdOption.IsRequired = true;
            command.AddOption(externalConnectionIdOption);
            var externalGroupIdOption = new Option<string>("--external-group-id", description: "key: id of externalGroup") {
            };
            externalGroupIdOption.IsRequired = true;
            command.AddOption(externalGroupIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var externalConnectionId = invocationContext.ParseResult.GetValueForOption(externalConnectionIdOption);
                var externalGroupId = invocationContext.ParseResult.GetValueForOption(externalGroupIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ExternalGroup>(ExternalGroup.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("externalConnection%2Did", externalConnectionId);
                requestInfo.PathParameters.Add("externalGroup%2Did", externalGroupId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new ExternalGroupItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ExternalGroupItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/external/connections/{externalConnection%2Did}/groups/{externalGroup%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property groups for external
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<ExternalGroupItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new ExternalGroupItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get groups from external
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<ExternalGroupItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new ExternalGroupItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property groups in external
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ExternalGroup body, Action<ExternalGroupItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new ExternalGroupItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class ExternalGroupItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new ExternalGroupItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public ExternalGroupItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Get groups from external</summary>
        public class ExternalGroupItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class ExternalGroupItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public ExternalGroupItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new ExternalGroupItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new ExternalGroupItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public ExternalGroupItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class ExternalGroupItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new ExternalGroupItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public ExternalGroupItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}