// <auto-generated/>
using ApiSdk.IdentityGovernance.EntitlementManagement.Catalogs.Item.Resources.Item.EnvironmentNamespace;
using ApiSdk.IdentityGovernance.EntitlementManagement.Catalogs.Item.Resources.Item.Roles;
using ApiSdk.IdentityGovernance.EntitlementManagement.Catalogs.Item.Resources.Item.Scopes;
using ApiSdk.Models.ODataErrors;
using ApiSdk.Models;
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
namespace ApiSdk.IdentityGovernance.EntitlementManagement.Catalogs.Item.Resources.Item {
    /// <summary>
    /// Provides operations to manage the resources property of the microsoft.graph.accessPackageCatalog entity.
    /// </summary>
    public class AccessPackageResourceItemRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// Delete navigation property resources for identityGovernance
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property resources for identityGovernance";
            var accessPackageCatalogIdOption = new Option<string>("--access-package-catalog-id", description: "The unique identifier of accessPackageCatalog") {
            };
            accessPackageCatalogIdOption.IsRequired = true;
            command.AddOption(accessPackageCatalogIdOption);
            var accessPackageResourceIdOption = new Option<string>("--access-package-resource-id", description: "The unique identifier of accessPackageResource") {
            };
            accessPackageResourceIdOption.IsRequired = true;
            command.AddOption(accessPackageResourceIdOption);
            var ifMatchOption = new Option<string[]>("--if-match", description: "ETag") {
                Arity = ArgumentArity.ZeroOrMore
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var accessPackageCatalogId = invocationContext.ParseResult.GetValueForOption(accessPackageCatalogIdOption);
                var accessPackageResourceId = invocationContext.ParseResult.GetValueForOption(accessPackageResourceIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToDeleteRequestInformation(q => {
                });
                if (accessPackageCatalogId is not null) requestInfo.PathParameters.Add("accessPackageCatalog%2Did", accessPackageCatalogId);
                if (accessPackageResourceId is not null) requestInfo.PathParameters.Add("accessPackageResource%2Did", accessPackageResourceId);
                if (ifMatch is not null) requestInfo.Headers.Add("If-Match", ifMatch);
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
        /// Provides operations to manage the environment property of the microsoft.graph.accessPackageResource entity.
        /// </summary>
        public Command BuildEnvironmentNavCommand() {
            var command = new Command("environment");
            command.Description = "Provides operations to manage the environment property of the microsoft.graph.accessPackageResource entity.";
            var builder = new EnvironmentRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Access package resources in this catalog.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Access package resources in this catalog.";
            var accessPackageCatalogIdOption = new Option<string>("--access-package-catalog-id", description: "The unique identifier of accessPackageCatalog") {
            };
            accessPackageCatalogIdOption.IsRequired = true;
            command.AddOption(accessPackageCatalogIdOption);
            var accessPackageResourceIdOption = new Option<string>("--access-package-resource-id", description: "The unique identifier of accessPackageResource") {
            };
            accessPackageResourceIdOption.IsRequired = true;
            command.AddOption(accessPackageResourceIdOption);
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
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            command.SetHandler(async (invocationContext) => {
                var accessPackageCatalogId = invocationContext.ParseResult.GetValueForOption(accessPackageCatalogIdOption);
                var accessPackageResourceId = invocationContext.ParseResult.GetValueForOption(accessPackageResourceIdOption);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var expand = invocationContext.ParseResult.GetValueForOption(expandOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                if (accessPackageCatalogId is not null) requestInfo.PathParameters.Add("accessPackageCatalog%2Did", accessPackageCatalogId);
                if (accessPackageResourceId is not null) requestInfo.PathParameters.Add("accessPackageResource%2Did", accessPackageResourceId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await reqAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken) ?? Stream.Null;
                response = (response != Stream.Null) ? await outputFilter.FilterOutputAsync(response, query, cancellationToken) : response;
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Update the navigation property resources in identityGovernance
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property resources in identityGovernance";
            var accessPackageCatalogIdOption = new Option<string>("--access-package-catalog-id", description: "The unique identifier of accessPackageCatalog") {
            };
            accessPackageCatalogIdOption.IsRequired = true;
            command.AddOption(accessPackageCatalogIdOption);
            var accessPackageResourceIdOption = new Option<string>("--access-package-resource-id", description: "The unique identifier of accessPackageResource") {
            };
            accessPackageResourceIdOption.IsRequired = true;
            command.AddOption(accessPackageResourceIdOption);
            var bodyOption = new Option<string>("--body", description: "The request body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            command.SetHandler(async (invocationContext) => {
                var accessPackageCatalogId = invocationContext.ParseResult.GetValueForOption(accessPackageCatalogIdOption);
                var accessPackageResourceId = invocationContext.ParseResult.GetValueForOption(accessPackageResourceIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption) ?? string.Empty;
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<AccessPackageResource>(AccessPackageResource.CreateFromDiscriminatorValue);
                if (model is null) {
                    Console.Error.WriteLine("No model data to send.");
                    return;
                }
                var requestInfo = ToPatchRequestInformation(model, q => {
                });
                if (accessPackageCatalogId is not null) requestInfo.PathParameters.Add("accessPackageCatalog%2Did", accessPackageCatalogId);
                if (accessPackageResourceId is not null) requestInfo.PathParameters.Add("accessPackageResource%2Did", accessPackageResourceId);
                requestInfo.SetContentFromParsable(reqAdapter, "application/json", model);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await reqAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken) ?? Stream.Null;
                response = (response != Stream.Null) ? await outputFilter.FilterOutputAsync(response, query, cancellationToken) : response;
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Provides operations to manage the roles property of the microsoft.graph.accessPackageResource entity.
        /// </summary>
        public Command BuildRolesNavCommand() {
            var command = new Command("roles");
            command.Description = "Provides operations to manage the roles property of the microsoft.graph.accessPackageResource entity.";
            var builder = new RolesRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            var nonExecCommands = new List<Command>();
            nonExecCommands.Add(builder.BuildCountNavCommand());
            execCommands.Add(builder.BuildCreateCommand());
            execCommands.Add(builder.BuildListCommand());
            var cmds = builder.BuildCommand();
            execCommands.AddRange(cmds.Item1);
            nonExecCommands.AddRange(cmds.Item2);
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            foreach (var cmd in nonExecCommands.OrderBy(static c => c.Name, StringComparer.Ordinal))
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the scopes property of the microsoft.graph.accessPackageResource entity.
        /// </summary>
        public Command BuildScopesNavCommand() {
            var command = new Command("scopes");
            command.Description = "Provides operations to manage the scopes property of the microsoft.graph.accessPackageResource entity.";
            var builder = new ScopesRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            var nonExecCommands = new List<Command>();
            nonExecCommands.Add(builder.BuildCountNavCommand());
            execCommands.Add(builder.BuildCreateCommand());
            execCommands.Add(builder.BuildListCommand());
            var cmds = builder.BuildCommand();
            execCommands.AddRange(cmds.Item1);
            nonExecCommands.AddRange(cmds.Item2);
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            foreach (var cmd in nonExecCommands.OrderBy(static c => c.Name, StringComparer.Ordinal))
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Instantiates a new AccessPackageResourceItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public AccessPackageResourceItemRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/identityGovernance/entitlementManagement/catalogs/{accessPackageCatalog%2Did}/resources/{accessPackageResource%2Did}{?%24select,%24expand}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new AccessPackageResourceItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public AccessPackageResourceItemRequestBuilder(string rawUrl) : base("{+baseurl}/identityGovernance/entitlementManagement/catalogs/{accessPackageCatalog%2Did}/resources/{accessPackageResource%2Did}{?%24select,%24expand}", rawUrl) {
        }
        /// <summary>
        /// Delete navigation property resources for identityGovernance
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
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
        /// <summary>
        /// Access package resources in this catalog.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<AccessPackageResourceItemRequestBuilderGetQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<AccessPackageResourceItemRequestBuilderGetQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new RequestConfiguration<AccessPackageResourceItemRequestBuilderGetQueryParameters>();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            requestInfo.Headers.TryAdd("Accept", "application/json;q=1");
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property resources in identityGovernance
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(AccessPackageResource body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(AccessPackageResource body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
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
            requestInfo.Headers.TryAdd("Accept", "application/json;q=1");
            return requestInfo;
        }
        /// <summary>
        /// Access package resources in this catalog.
        /// </summary>
        public class AccessPackageResourceItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
        }
    }
}
