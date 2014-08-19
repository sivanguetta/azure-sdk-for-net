// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.Sql
{
    /// <summary>
    /// Represents all the operations for operating on Azure SQL Database
    /// security policy.  Contains operations to: Retrieve and Update security
    /// policy
    /// </summary>
    internal partial class SecurityOperations : IServiceOperations<SqlManagementClient>, ISecurityOperations
    {
        /// <summary>
        /// Initializes a new instance of the SecurityOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal SecurityOperations(SqlManagementClient client)
        {
            this._client = client;
        }
        
        private SqlManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Sql.SqlManagementClient.
        /// </summary>
        public SqlManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Gets Azure SQL Database security policy object according to a given
        /// Azure SQL Database Server and Database.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the Resource Group to which the Azure SQL
        /// Database Server belongs.
        /// </param>
        /// <param name='serverName'>
        /// Required. The name of the Azure SQL Database Server on which the
        /// Azure SQL Database hosted.
        /// </param>
        /// <param name='databaseName'>
        /// Required. The name of the Azure SQL Database for which the security
        /// policy is being retreived.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Represents the response to a get Azure SQL Database security policy
        /// request
        /// </returns>
        public async Task<DatabaseSecurityPolicyGetResponse> GetAsync(string resourceGroupName, string serverName, string databaseName, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (serverName == null)
            {
                throw new ArgumentNullException("serverName");
            }
            if (databaseName == null)
            {
                throw new ArgumentNullException("databaseName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("serverName", serverName);
                tracingParameters.Add("databaseName", databaseName);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/resourceGroups/" + resourceGroupName.Trim() + "/providers/Microsoft.Sql/servers/" + serverName.Trim() + "/databaseSecurityPolicies/" + databaseName.Trim() + "?";
            url = url + "api-version=2014-04-01";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DatabaseSecurityPolicyGetResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DatabaseSecurityPolicyGetResponse();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        DatabaseSecurityPolicy databaseSecurityPolicyInstance = new DatabaseSecurityPolicy();
                        result.DatabaseSecurityPolicy = databaseSecurityPolicyInstance;
                        
                        JToken nameValue = responseDoc["name"];
                        if (nameValue != null && nameValue.Type != JTokenType.Null)
                        {
                            string nameInstance = ((string)nameValue);
                            databaseSecurityPolicyInstance.Name = nameInstance;
                        }
                        
                        JToken propertiesValue = responseDoc["properties"];
                        if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                        {
                            DatabaseSecurityPolicyProperties propertiesInstance = new DatabaseSecurityPolicyProperties();
                            databaseSecurityPolicyInstance.Properties = propertiesInstance;
                            
                            JToken isAuditingEnabledValue = propertiesValue["isAuditingEnabled"];
                            if (isAuditingEnabledValue != null && isAuditingEnabledValue.Type != JTokenType.Null)
                            {
                                bool isAuditingEnabledInstance = ((bool)isAuditingEnabledValue);
                                propertiesInstance.IsAuditingEnabled = isAuditingEnabledInstance;
                            }
                            
                            JToken retentionDaysValue = propertiesValue["retentionDays"];
                            if (retentionDaysValue != null && retentionDaysValue.Type != JTokenType.Null)
                            {
                                int retentionDaysInstance = ((int)retentionDaysValue);
                                propertiesInstance.RetentionDays = retentionDaysInstance;
                            }
                            
                            JToken isEventTypeDataAccessEnabledValue = propertiesValue["isEventTypeDataAccessEnabled"];
                            if (isEventTypeDataAccessEnabledValue != null && isEventTypeDataAccessEnabledValue.Type != JTokenType.Null)
                            {
                                bool isEventTypeDataAccessEnabledInstance = ((bool)isEventTypeDataAccessEnabledValue);
                                propertiesInstance.IsEventTypeDataAccessEnabled = isEventTypeDataAccessEnabledInstance;
                            }
                            
                            JToken isEventTypeSchemaChangeEnabledValue = propertiesValue["isEventTypeSchemaChangeEnabled"];
                            if (isEventTypeSchemaChangeEnabledValue != null && isEventTypeSchemaChangeEnabledValue.Type != JTokenType.Null)
                            {
                                bool isEventTypeSchemaChangeEnabledInstance = ((bool)isEventTypeSchemaChangeEnabledValue);
                                propertiesInstance.IsEventTypeSchemaChangeEnabled = isEventTypeSchemaChangeEnabledInstance;
                            }
                            
                            JToken isEventTypeDataChangesEnabledValue = propertiesValue["isEventTypeDataChangesEnabled"];
                            if (isEventTypeDataChangesEnabledValue != null && isEventTypeDataChangesEnabledValue.Type != JTokenType.Null)
                            {
                                bool isEventTypeDataChangesEnabledInstance = ((bool)isEventTypeDataChangesEnabledValue);
                                propertiesInstance.IsEventTypeDataChangesEnabled = isEventTypeDataChangesEnabledInstance;
                            }
                            
                            JToken isEventTypeSecurityExceptionsEnabledValue = propertiesValue["isEventTypeSecurityExceptionsEnabled"];
                            if (isEventTypeSecurityExceptionsEnabledValue != null && isEventTypeSecurityExceptionsEnabledValue.Type != JTokenType.Null)
                            {
                                bool isEventTypeSecurityExceptionsEnabledInstance = ((bool)isEventTypeSecurityExceptionsEnabledValue);
                                propertiesInstance.IsEventTypeSecurityExceptionsEnabled = isEventTypeSecurityExceptionsEnabledInstance;
                            }
                            
                            JToken isEventTypeGrantRevokePermissionsEnabledValue = propertiesValue["isEventTypeGrantRevokePermissionsEnabled"];
                            if (isEventTypeGrantRevokePermissionsEnabledValue != null && isEventTypeGrantRevokePermissionsEnabledValue.Type != JTokenType.Null)
                            {
                                bool isEventTypeGrantRevokePermissionsEnabledInstance = ((bool)isEventTypeGrantRevokePermissionsEnabledValue);
                                propertiesInstance.IsEventTypeGrantRevokePermissionsEnabled = isEventTypeGrantRevokePermissionsEnabledInstance;
                            }
                            
                            JToken storageAccountNameValue = propertiesValue["storageAccountName"];
                            if (storageAccountNameValue != null && storageAccountNameValue.Type != JTokenType.Null)
                            {
                                string storageAccountNameInstance = ((string)storageAccountNameValue);
                                propertiesInstance.StorageAccountName = storageAccountNameInstance;
                            }
                            
                            JToken storageAccountKeyValue = propertiesValue["storageAccountKey"];
                            if (storageAccountKeyValue != null && storageAccountKeyValue.Type != JTokenType.Null)
                            {
                                string storageAccountKeyInstance = ((string)storageAccountKeyValue);
                                propertiesInstance.StorageAccountKey = storageAccountKeyInstance;
                            }
                            
                            JToken storageTableEndpointValue = propertiesValue["storageTableEndpoint"];
                            if (storageTableEndpointValue != null && storageTableEndpointValue.Type != JTokenType.Null)
                            {
                                string storageTableEndpointInstance = ((string)storageTableEndpointValue);
                                propertiesInstance.StorageTableEndpoint = storageTableEndpointInstance;
                            }
                            
                            JToken storageAccountResourceGroupNameValue = propertiesValue["storageAccountResourceGroupName"];
                            if (storageAccountResourceGroupNameValue != null && storageAccountResourceGroupNameValue.Type != JTokenType.Null)
                            {
                                string storageAccountResourceGroupNameInstance = ((string)storageAccountResourceGroupNameValue);
                                propertiesInstance.StorageAccountResourceGroupName = storageAccountResourceGroupNameInstance;
                            }
                            
                            JToken storageAccountSubscriptionIdValue = propertiesValue["storageAccountSubscriptionId"];
                            if (storageAccountSubscriptionIdValue != null && storageAccountSubscriptionIdValue.Type != JTokenType.Null)
                            {
                                string storageAccountSubscriptionIdInstance = ((string)storageAccountSubscriptionIdValue);
                                propertiesInstance.StorageAccountSubscriptionId = storageAccountSubscriptionIdInstance;
                            }
                            
                            JToken adoNetConnectionStringValue = propertiesValue["adoNetConnectionString"];
                            if (adoNetConnectionStringValue != null && adoNetConnectionStringValue.Type != JTokenType.Null)
                            {
                                string adoNetConnectionStringInstance = ((string)adoNetConnectionStringValue);
                                propertiesInstance.AdoNetConnectionString = adoNetConnectionStringInstance;
                            }
                            
                            JToken odbcConnectionStringValue = propertiesValue["odbcConnectionString"];
                            if (odbcConnectionStringValue != null && odbcConnectionStringValue.Type != JTokenType.Null)
                            {
                                string odbcConnectionStringInstance = ((string)odbcConnectionStringValue);
                                propertiesInstance.OdbcConnectionString = odbcConnectionStringInstance;
                            }
                            
                            JToken phpConnectionStringValue = propertiesValue["phpConnectionString"];
                            if (phpConnectionStringValue != null && phpConnectionStringValue.Type != JTokenType.Null)
                            {
                                string phpConnectionStringInstance = ((string)phpConnectionStringValue);
                                propertiesInstance.PhpConnectionString = phpConnectionStringInstance;
                            }
                            
                            JToken jdbcConnectionStringValue = propertiesValue["jdbcConnectionString"];
                            if (jdbcConnectionStringValue != null && jdbcConnectionStringValue.Type != JTokenType.Null)
                            {
                                string jdbcConnectionStringInstance = ((string)jdbcConnectionStringValue);
                                propertiesInstance.JdbcConnectionString = jdbcConnectionStringInstance;
                            }
                            
                            JToken proxyDnsNameValue = propertiesValue["proxyDnsName"];
                            if (proxyDnsNameValue != null && proxyDnsNameValue.Type != JTokenType.Null)
                            {
                                string proxyDnsNameInstance = ((string)proxyDnsNameValue);
                                propertiesInstance.ProxyDnsName = proxyDnsNameInstance;
                            }
                            
                            JToken useServerDefaultValue = propertiesValue["useServerDefault"];
                            if (useServerDefaultValue != null && useServerDefaultValue.Type != JTokenType.Null)
                            {
                                bool useServerDefaultInstance = ((bool)useServerDefaultValue);
                                propertiesInstance.UseServerDefault = useServerDefaultInstance;
                            }
                        }
                        
                        JToken idValue = responseDoc["id"];
                        if (idValue != null && idValue.Type != JTokenType.Null)
                        {
                            string idInstance = ((string)idValue);
                            databaseSecurityPolicyInstance.Id = idInstance;
                        }
                        
                        JToken typeValue = responseDoc["type"];
                        if (typeValue != null && typeValue.Type != JTokenType.Null)
                        {
                            string typeInstance = ((string)typeValue);
                            databaseSecurityPolicyInstance.Type = typeInstance;
                        }
                        
                        JToken locationValue = responseDoc["location"];
                        if (locationValue != null && locationValue.Type != JTokenType.Null)
                        {
                            string locationInstance = ((string)locationValue);
                            databaseSecurityPolicyInstance.Location = locationInstance;
                        }
                        
                        JToken tagsSequenceElement = ((JToken)responseDoc["tags"]);
                        if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                        {
                            foreach (JProperty property in tagsSequenceElement)
                            {
                                string tagsKey = ((string)property.Name);
                                string tagsValue = ((string)property.Value);
                                databaseSecurityPolicyInstance.Tags.Add(tagsKey, tagsValue);
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Updates an Azure SQL Database security policy object.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the Resource Group to which the Azure SQL
        /// Database Server belongs.
        /// </param>
        /// <param name='serverName'>
        /// Required. The name of the Azure SQL Database Server to which the
        /// Azure SQL Database belongs.
        /// </param>
        /// <param name='databaseName'>
        /// Required. The name of the Azure SQL Database to which the security
        /// policy is applied.
        /// </param>
        /// <param name='parameters'>
        /// Required. The required parameters for updating a security policy.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<OperationResponse> UpdateAsync(string resourceGroupName, string serverName, string databaseName, DatabaseSecurityPolicyUpdateParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (serverName == null)
            {
                throw new ArgumentNullException("serverName");
            }
            if (databaseName == null)
            {
                throw new ArgumentNullException("databaseName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Properties == null)
            {
                throw new ArgumentNullException("parameters.Properties");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("serverName", serverName);
                tracingParameters.Add("databaseName", databaseName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "UpdateAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/resourceGroups/" + resourceGroupName.Trim() + "/providers/Microsoft.Sql/servers/" + serverName.Trim() + "/databaseSecurityPolicies/" + databaseName.Trim() + "?";
            url = url + "api-version=2014-04-01";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                JToken requestDoc = null;
                
                JObject databaseSecurityPolicyUpdateParametersValue = new JObject();
                requestDoc = databaseSecurityPolicyUpdateParametersValue;
                
                JObject propertiesValue = new JObject();
                databaseSecurityPolicyUpdateParametersValue["properties"] = propertiesValue;
                
                propertiesValue["isAuditingEnabled"] = parameters.Properties.IsAuditingEnabled;
                
                propertiesValue["retentionDays"] = parameters.Properties.RetentionDays;
                
                propertiesValue["isEventTypeDataAccessEnabled"] = parameters.Properties.IsEventTypeDataAccessEnabled;
                
                propertiesValue["isEventTypeSchemaChangeEnabled"] = parameters.Properties.IsEventTypeSchemaChangeEnabled;
                
                propertiesValue["isEventTypeDataChangesEnabled"] = parameters.Properties.IsEventTypeDataChangesEnabled;
                
                propertiesValue["isEventTypeSecurityExceptionsEnabled"] = parameters.Properties.IsEventTypeSecurityExceptionsEnabled;
                
                propertiesValue["isEventTypeGrantRevokePermissionsEnabled"] = parameters.Properties.IsEventTypeGrantRevokePermissionsEnabled;
                
                if (parameters.Properties.StorageAccountName != null)
                {
                    propertiesValue["storageAccountName"] = parameters.Properties.StorageAccountName;
                }
                
                if (parameters.Properties.StorageAccountKey != null)
                {
                    propertiesValue["storageAccountKey"] = parameters.Properties.StorageAccountKey;
                }
                
                if (parameters.Properties.StorageTableEndpoint != null)
                {
                    propertiesValue["storageTableEndpoint"] = parameters.Properties.StorageTableEndpoint;
                }
                
                if (parameters.Properties.StorageAccountResourceGroupName != null)
                {
                    propertiesValue["storageAccountResourceGroupName"] = parameters.Properties.StorageAccountResourceGroupName;
                }
                
                if (parameters.Properties.StorageAccountSubscriptionId != null)
                {
                    propertiesValue["storageAccountSubscriptionId"] = parameters.Properties.StorageAccountSubscriptionId;
                }
                
                if (parameters.Properties.AdoNetConnectionString != null)
                {
                    propertiesValue["adoNetConnectionString"] = parameters.Properties.AdoNetConnectionString;
                }
                
                if (parameters.Properties.OdbcConnectionString != null)
                {
                    propertiesValue["odbcConnectionString"] = parameters.Properties.OdbcConnectionString;
                }
                
                if (parameters.Properties.PhpConnectionString != null)
                {
                    propertiesValue["phpConnectionString"] = parameters.Properties.PhpConnectionString;
                }
                
                if (parameters.Properties.JdbcConnectionString != null)
                {
                    propertiesValue["jdbcConnectionString"] = parameters.Properties.JdbcConnectionString;
                }
                
                if (parameters.Properties.ProxyDnsName != null)
                {
                    propertiesValue["proxyDnsName"] = parameters.Properties.ProxyDnsName;
                }
                
                propertiesValue["useServerDefault"] = parameters.Properties.UseServerDefault;
                
                requestContent = requestDoc.ToString(Formatting.Indented);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationResponse result = null;
                    result = new OperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
