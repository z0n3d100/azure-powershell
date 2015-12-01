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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Internal.Subscriptions
{
    /// <summary>
    /// Operations for managing subscriptions.
    /// </summary>
    internal partial class SubscriptionOperations : IServiceOperations<SubscriptionClient>, ISubscriptionOperations
    {
        /// <summary>
        /// Initializes a new instance of the SubscriptionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal SubscriptionOperations(SubscriptionClient client)
        {
            this._client = client;
        }
        
        private SubscriptionClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Internal.Subscriptions.SubscriptionClient.
        /// </summary>
        public SubscriptionClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Gets details about particular subscription.
        /// </summary>
        /// <param name='subscriptionId'>
        /// Required. Id of the subscription.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Subscription detailed information.
        /// </returns>
        public async Task<GetSubscriptionResult> GetAsync(string subscriptionId, CancellationToken cancellationToken)
        {
            // Validate
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("subscriptionId", subscriptionId);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-04-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
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
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    GetSubscriptionResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new GetSubscriptionResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            Subscription subscriptionInstance = new Subscription();
                            result.Subscription = subscriptionInstance;
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                subscriptionInstance.Id = idInstance;
                            }
                            
                            JToken subscriptionIdValue = responseDoc["subscriptionId"];
                            if (subscriptionIdValue != null && subscriptionIdValue.Type != JTokenType.Null)
                            {
                                string subscriptionIdInstance = ((string)subscriptionIdValue);
                                subscriptionInstance.SubscriptionId = subscriptionIdInstance;
                            }
                            
                            JToken displayNameValue = responseDoc["displayName"];
                            if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                            {
                                string displayNameInstance = ((string)displayNameValue);
                                subscriptionInstance.DisplayName = displayNameInstance;
                            }
                            
                            JToken stateValue = responseDoc["state"];
                            if (stateValue != null && stateValue.Type != JTokenType.Null)
                            {
                                string stateInstance = ((string)stateValue);
                                subscriptionInstance.State = stateInstance;
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
                        TracingAdapter.Exit(invocationId, result);
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
        /// Gets a list of the subscriptionIds.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Subscription list operation response.
        /// </returns>
        public async Task<SubscriptionListResult> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-04-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
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
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    SubscriptionListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new SubscriptionListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    Subscription subscriptionInstance = new Subscription();
                                    result.Subscriptions.Add(subscriptionInstance);
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        subscriptionInstance.Id = idInstance;
                                    }
                                    
                                    JToken subscriptionIdValue = valueValue["subscriptionId"];
                                    if (subscriptionIdValue != null && subscriptionIdValue.Type != JTokenType.Null)
                                    {
                                        string subscriptionIdInstance = ((string)subscriptionIdValue);
                                        subscriptionInstance.SubscriptionId = subscriptionIdInstance;
                                    }
                                    
                                    JToken displayNameValue = valueValue["displayName"];
                                    if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                    {
                                        string displayNameInstance = ((string)displayNameValue);
                                        subscriptionInstance.DisplayName = displayNameInstance;
                                    }
                                    
                                    JToken stateValue = valueValue["state"];
                                    if (stateValue != null && stateValue.Type != JTokenType.Null)
                                    {
                                        string stateInstance = ((string)stateValue);
                                        subscriptionInstance.State = stateInstance;
                                    }
                                }
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
                        TracingAdapter.Exit(invocationId, result);
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
        /// Gets a list of the subscription locations.
        /// </summary>
        /// <param name='subscriptionId'>
        /// Required. Id of the subscription
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Location list operation response.
        /// </returns>
        public async Task<LocationListResult> ListLocationsAsync(string subscriptionId, CancellationToken cancellationToken)
        {
            // Validate
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("subscriptionId", subscriptionId);
                TracingAdapter.Enter(invocationId, this, "ListLocationsAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/locations";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-04-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
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
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    LocationListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new LocationListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    Location locationInstance = new Location();
                                    result.Locations.Add(locationInstance);
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        locationInstance.Id = idInstance;
                                    }
                                    
                                    JToken subscriptionIdValue = valueValue["subscriptionId"];
                                    if (subscriptionIdValue != null && subscriptionIdValue.Type != JTokenType.Null)
                                    {
                                        string subscriptionIdInstance = ((string)subscriptionIdValue);
                                        locationInstance.SubscriptionId = subscriptionIdInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        locationInstance.Name = nameInstance;
                                    }
                                    
                                    JToken displayNameValue = valueValue["displayName"];
                                    if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                    {
                                        string displayNameInstance = ((string)displayNameValue);
                                        locationInstance.DisplayName = displayNameInstance;
                                    }
                                    
                                    JToken latitudeValue = valueValue["latitude"];
                                    if (latitudeValue != null && latitudeValue.Type != JTokenType.Null)
                                    {
                                        string latitudeInstance = ((string)latitudeValue);
                                        locationInstance.Latitude = latitudeInstance;
                                    }
                                    
                                    JToken longitudeValue = valueValue["longitude"];
                                    if (longitudeValue != null && longitudeValue.Type != JTokenType.Null)
                                    {
                                        string longitudeInstance = ((string)longitudeValue);
                                        locationInstance.Longitude = longitudeInstance;
                                    }
                                }
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
                        TracingAdapter.Exit(invocationId, result);
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
