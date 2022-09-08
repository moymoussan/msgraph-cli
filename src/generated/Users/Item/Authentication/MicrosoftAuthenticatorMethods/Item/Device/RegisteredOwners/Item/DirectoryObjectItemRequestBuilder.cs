using ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item.AppRoleAssignment;
using ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item.Endpoint;
using ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item.Ref;
using ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item.ServicePrincipal;
using ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiSdk.Users.Item.Authentication.MicrosoftAuthenticatorMethods.Item.Device.RegisteredOwners.Item {
    /// <summary>Builds and executes requests for operations under \users\{user-id}\authentication\microsoftAuthenticatorMethods\{microsoftAuthenticatorAuthenticationMethod-id}\device\registeredOwners\{directoryObject-id}</summary>
    public class DirectoryObjectItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAppRoleAssignmentCommand() {
            var command = new Command("app-role-assignment");
            var builder = new AppRoleAssignmentRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildEndpointCommand() {
            var command = new Command("endpoint");
            var builder = new EndpointRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildRefCommand() {
            var command = new Command("ref");
            var builder = new RefRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        public Command BuildServicePrincipalCommand() {
            var command = new Command("service-principal");
            var builder = new ServicePrincipalRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildUserCommand() {
            var command = new Command("user");
            var builder = new UserRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new DirectoryObjectItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DirectoryObjectItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/authentication/microsoftAuthenticatorMethods/{microsoftAuthenticatorAuthenticationMethod%2Did}/device/registeredOwners/{directoryObject%2Did}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
    }
}