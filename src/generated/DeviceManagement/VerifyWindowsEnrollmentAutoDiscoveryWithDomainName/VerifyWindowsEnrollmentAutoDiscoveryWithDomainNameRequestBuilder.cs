using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.DeviceManagement.VerifyWindowsEnrollmentAutoDiscoveryWithDomainName {
    /// <summary>Builds and executes requests for operations under \deviceManagement\microsoft.graph.verifyWindowsEnrollmentAutoDiscovery(domainName='{domainName}')</summary>
    public class VerifyWindowsEnrollmentAutoDiscoveryWithDomainNameRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke function verifyWindowsEnrollmentAutoDiscovery
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Invoke function verifyWindowsEnrollmentAutoDiscovery";
            // Create options for all the parameters
            var domainNameOption = new Option<string>("--domainname", description: "Usage: domainName={domainName}") {
            };
            domainNameOption.IsRequired = true;
            command.AddOption(domainNameOption);
            command.SetHandler(async (string domainName) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var result = await RequestAdapter.SendPrimitiveAsync<bool?>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteBoolValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, domainNameOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new VerifyWindowsEnrollmentAutoDiscoveryWithDomainNameRequestBuilder and sets the default values.
        /// <param name="domainName">Usage: domainName={domainName}</param>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public VerifyWindowsEnrollmentAutoDiscoveryWithDomainNameRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter, string domainName = default) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement/microsoft.graph.verifyWindowsEnrollmentAutoDiscovery(domainName='{domainName}')";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            urlTplParams.Add("domainName", domainName);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke function verifyWindowsEnrollmentAutoDiscovery
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Invoke function verifyWindowsEnrollmentAutoDiscovery
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<bool?> GetAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(h, o);
            return await RequestAdapter.SendPrimitiveAsync<bool?>(requestInfo, responseHandler, cancellationToken);
        }
    }
}
