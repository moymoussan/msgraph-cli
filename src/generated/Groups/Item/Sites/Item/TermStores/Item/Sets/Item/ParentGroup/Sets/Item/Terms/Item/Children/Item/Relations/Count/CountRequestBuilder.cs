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
namespace ApiSdk.Groups.Item.Sites.Item.TermStores.Item.Sets.Item.ParentGroup.Sets.Item.Terms.Item.Children.Item.Relations.Count {
    /// <summary>
    /// Provides operations to count the resources in the collection.
    /// </summary>
    public class CountRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Get the number of the resource
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Get the number of the resource";
            // Create options for all the parameters
            var groupIdOption = new Option<string>("--group-id", description: "key: id of group") {
            };
            groupIdOption.IsRequired = true;
            command.AddOption(groupIdOption);
            var siteIdOption = new Option<string>("--site-id", description: "key: id of site") {
            };
            siteIdOption.IsRequired = true;
            command.AddOption(siteIdOption);
            var storeIdOption = new Option<string>("--store-id", description: "key: id of store") {
            };
            storeIdOption.IsRequired = true;
            command.AddOption(storeIdOption);
            var setIdOption = new Option<string>("--set-id", description: "key: id of set") {
            };
            setIdOption.IsRequired = true;
            command.AddOption(setIdOption);
            var setId1Option = new Option<string>("--set-id1", description: "key: id of set") {
            };
            setId1Option.IsRequired = true;
            command.AddOption(setId1Option);
            var termIdOption = new Option<string>("--term-id", description: "key: id of term") {
            };
            termIdOption.IsRequired = true;
            command.AddOption(termIdOption);
            var termId1Option = new Option<string>("--term-id1", description: "key: id of term") {
            };
            termId1Option.IsRequired = true;
            command.AddOption(termId1Option);
            var searchOption = new Option<string>("--search", description: "Search items by search phrases") {
            };
            searchOption.IsRequired = false;
            command.AddOption(searchOption);
            var filterOption = new Option<string>("--filter", description: "Filter items by property values") {
            };
            filterOption.IsRequired = false;
            command.AddOption(filterOption);
            command.SetHandler(async (invocationContext) => {
                var groupId = invocationContext.ParseResult.GetValueForOption(groupIdOption);
                var siteId = invocationContext.ParseResult.GetValueForOption(siteIdOption);
                var storeId = invocationContext.ParseResult.GetValueForOption(storeIdOption);
                var setId = invocationContext.ParseResult.GetValueForOption(setIdOption);
                var setId1 = invocationContext.ParseResult.GetValueForOption(setId1Option);
                var termId = invocationContext.ParseResult.GetValueForOption(termIdOption);
                var termId1 = invocationContext.ParseResult.GetValueForOption(termId1Option);
                var search = invocationContext.ParseResult.GetValueForOption(searchOption);
                var filter = invocationContext.ParseResult.GetValueForOption(filterOption);
                var outputFormatterFactory = invocationContext.BindingContext.GetRequiredService<IOutputFormatterFactory>();
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = ToGetRequestInformation(q => {
                    if (!string.IsNullOrEmpty(search)) q.QueryParameters.Search = search;
                    if (!string.IsNullOrEmpty(filter)) q.QueryParameters.Filter = filter;
                });
                requestInfo.PathParameters.Add("group%2Did", groupId);
                requestInfo.PathParameters.Add("site%2Did", siteId);
                requestInfo.PathParameters.Add("store%2Did", storeId);
                requestInfo.PathParameters.Add("set%2Did", setId);
                requestInfo.PathParameters.Add("set%2Did1", setId1);
                requestInfo.PathParameters.Add("term%2Did", termId);
                requestInfo.PathParameters.Add("term%2Did1", termId1);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(FormatterType.TEXT);
                await formatter.WriteOutputAsync(response, null, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new CountRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CountRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group%2Did}/sites/{site%2Did}/termStores/{store%2Did}/sets/{set%2Did}/parentGroup/sets/{set%2Did1}/terms/{term%2Did}/children/{term%2Did1}/relations/$count{?%24search,%24filter}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Get the number of the resource
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<CountRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<CountRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "text/plain");
            if (requestConfiguration != null) {
                var requestConfig = new CountRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get the number of the resource
        /// </summary>
        public class CountRequestBuilderGetQueryParameters {
            /// <summary>Filter items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24filter")]
            public string? Filter { get; set; }
#nullable restore
#else
            [QueryParameter("%24filter")]
            public string Filter { get; set; }
#endif
            /// <summary>Search items by search phrases</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24search")]
            public string? Search { get; set; }
#nullable restore
#else
            [QueryParameter("%24search")]
            public string Search { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class CountRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public CountRequestBuilderGetQueryParameters QueryParameters { get; set; } = new CountRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new CountRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public CountRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
