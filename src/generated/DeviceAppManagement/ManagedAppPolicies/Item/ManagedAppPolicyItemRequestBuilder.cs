using ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.ManagedAppProtection;
using ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.TargetApps;
using ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.TargetedManagedAppProtection;
using ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.WindowsInformationProtection;
using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.Binding;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item {
    /// <summary>Builds and executes requests for operations under \deviceAppManagement\managedAppPolicies\{managedAppPolicy-id}</summary>
    public class ManagedAppPolicyItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Managed app policies.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Managed app policies.";
            // Create options for all the parameters
            var managedAppPolicyIdOption = new Option<string>("--managed-app-policy-id", description: "key: id of managedAppPolicy") {
            };
            managedAppPolicyIdOption.IsRequired = true;
            command.AddOption(managedAppPolicyIdOption);
            command.SetHandler(async (object[] parameters) => {
                var managedAppPolicyId = (string) parameters[0];
                var cancellationToken = (CancellationToken) parameters[1];
                PathParameters.Clear();
                PathParameters.Add("managedAppPolicy_id", managedAppPolicyId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(managedAppPolicyIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Managed app policies.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Managed app policies.";
            // Create options for all the parameters
            var managedAppPolicyIdOption = new Option<string>("--managed-app-policy-id", description: "key: id of managedAppPolicy") {
            };
            managedAppPolicyIdOption.IsRequired = true;
            command.AddOption(managedAppPolicyIdOption);
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
            var outputFilterOption = new Option<string>("--query");
            command.AddOption(outputFilterOption);
            command.SetHandler(async (object[] parameters) => {
                var managedAppPolicyId = (string) parameters[0];
                var select = (string[]) parameters[1];
                var expand = (string[]) parameters[2];
                var output = (FormatterType) parameters[3];
                var outputFilterOption = (string) parameters[4];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[5];
                var cancellationToken = (CancellationToken) parameters[6];
                PathParameters.Clear();
                PathParameters.Add("managedAppPolicy_id", managedAppPolicyId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, new CollectionBinding(managedAppPolicyIdOption, selectOption, expandOption, outputOption, outputFilterOption, new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildManagedAppProtectionCommand() {
            var command = new Command("managed-app-protection");
            var builder = new ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.ManagedAppProtection.ManagedAppProtectionRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildTargetAppsCommand());
            return command;
        }
        /// <summary>
        /// Managed app policies.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Managed app policies.";
            // Create options for all the parameters
            var managedAppPolicyIdOption = new Option<string>("--managed-app-policy-id", description: "key: id of managedAppPolicy") {
            };
            managedAppPolicyIdOption.IsRequired = true;
            command.AddOption(managedAppPolicyIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var managedAppPolicyId = (string) parameters[0];
                var body = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("managedAppPolicy_id", managedAppPolicyId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ManagedAppPolicy>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(managedAppPolicyIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildTargetAppsCommand() {
            var command = new Command("target-apps");
            var builder = new ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.TargetApps.TargetAppsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildTargetedManagedAppProtectionCommand() {
            var command = new Command("targeted-managed-app-protection");
            var builder = new ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.TargetedManagedAppProtection.TargetedManagedAppProtectionRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildAssignCommand());
            command.AddCommand(builder.BuildTargetAppsCommand());
            return command;
        }
        public Command BuildWindowsInformationProtectionCommand() {
            var command = new Command("windows-information-protection");
            var builder = new ApiSdk.DeviceAppManagement.ManagedAppPolicies.Item.WindowsInformationProtection.WindowsInformationProtectionRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildAssignCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new ManagedAppPolicyItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ManagedAppPolicyItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceAppManagement/managedAppPolicies/{managedAppPolicy_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Managed app policies.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Managed app policies.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (q != null) {
                var qParams = new GetQueryParameters();
                q.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Managed app policies.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ManagedAppPolicy body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>Managed app policies.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}