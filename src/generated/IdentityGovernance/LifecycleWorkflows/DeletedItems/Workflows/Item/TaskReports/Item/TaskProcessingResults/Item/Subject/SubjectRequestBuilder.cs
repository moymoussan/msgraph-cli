// <auto-generated/>
using ApiSdk.IdentityGovernance.LifecycleWorkflows.DeletedItems.Workflows.Item.TaskReports.Item.TaskProcessingResults.Item.Subject.MailboxSettings;
using ApiSdk.IdentityGovernance.LifecycleWorkflows.DeletedItems.Workflows.Item.TaskReports.Item.TaskProcessingResults.Item.Subject.ServiceProvisioningErrors;
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
namespace ApiSdk.IdentityGovernance.LifecycleWorkflows.DeletedItems.Workflows.Item.TaskReports.Item.TaskProcessingResults.Item.Subject {
    /// <summary>
    /// Provides operations to manage the subject property of the microsoft.graph.identityGovernance.taskProcessingResult entity.
    /// </summary>
    public class SubjectRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// The unique identifier of the Microsoft Entra user targeted for the task execution.Supports $filter(eq, ne) and $expand.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The unique identifier of the Microsoft Entra user targeted for the task execution.Supports $filter(eq, ne) and $expand.";
            var workflowIdOption = new Option<string>("--workflow-id", description: "The unique identifier of workflow") {
            };
            workflowIdOption.IsRequired = true;
            command.AddOption(workflowIdOption);
            var taskReportIdOption = new Option<string>("--task-report-id", description: "The unique identifier of taskReport") {
            };
            taskReportIdOption.IsRequired = true;
            command.AddOption(taskReportIdOption);
            var taskProcessingResultIdOption = new Option<string>("--task-processing-result-id", description: "The unique identifier of taskProcessingResult") {
            };
            taskProcessingResultIdOption.IsRequired = true;
            command.AddOption(taskProcessingResultIdOption);
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
                var workflowId = invocationContext.ParseResult.GetValueForOption(workflowIdOption);
                var taskReportId = invocationContext.ParseResult.GetValueForOption(taskReportIdOption);
                var taskProcessingResultId = invocationContext.ParseResult.GetValueForOption(taskProcessingResultIdOption);
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
                if (workflowId is not null) requestInfo.PathParameters.Add("workflow%2Did", workflowId);
                if (taskReportId is not null) requestInfo.PathParameters.Add("taskReport%2Did", taskReportId);
                if (taskProcessingResultId is not null) requestInfo.PathParameters.Add("taskProcessingResult%2Did", taskProcessingResultId);
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
        /// The mailboxSettings property
        /// </summary>
        public Command BuildMailboxSettingsNavCommand() {
            var command = new Command("mailbox-settings");
            command.Description = "The mailboxSettings property";
            var builder = new MailboxSettingsRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// The serviceProvisioningErrors property
        /// </summary>
        public Command BuildServiceProvisioningErrorsNavCommand() {
            var command = new Command("service-provisioning-errors");
            command.Description = "The serviceProvisioningErrors property";
            var builder = new ServiceProvisioningErrorsRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            var nonExecCommands = new List<Command>();
            nonExecCommands.Add(builder.BuildCountNavCommand());
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            foreach (var cmd in nonExecCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Instantiates a new SubjectRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public SubjectRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/identityGovernance/lifecycleWorkflows/deletedItems/workflows/{workflow%2Did}/taskReports/{taskReport%2Did}/taskProcessingResults/{taskProcessingResult%2Did}/subject{?%24select,%24expand}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new SubjectRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public SubjectRequestBuilder(string rawUrl) : base("{+baseurl}/identityGovernance/lifecycleWorkflows/deletedItems/workflows/{workflow%2Did}/taskReports/{taskReport%2Did}/taskProcessingResults/{taskProcessingResult%2Did}/subject{?%24select,%24expand}", rawUrl) {
        }
        /// <summary>
        /// The unique identifier of the Microsoft Entra user targeted for the task execution.Supports $filter(eq, ne) and $expand.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<SubjectRequestBuilderGetQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<SubjectRequestBuilderGetQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new RequestConfiguration<SubjectRequestBuilderGetQueryParameters>();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            requestInfo.Headers.TryAdd("Accept", "application/json;q=1");
            return requestInfo;
        }
        /// <summary>
        /// The unique identifier of the Microsoft Entra user targeted for the task execution.Supports $filter(eq, ne) and $expand.
        /// </summary>
        public class SubjectRequestBuilderGetQueryParameters {
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
