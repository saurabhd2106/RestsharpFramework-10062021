using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibs.Client
{
    public class CustomRestClient
    {
        public IRestClient RestClient { get; }

        public CustomRestClient()
        {
            RestClient = new RestClient();
        }

        public IRestResponse<T> SendGetRequest<T>(string endpointUrl)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<T> restResponse = RestClient.Get<T>(restRequest);

            return restResponse;

        }

        public IRestResponse<T> SendGetRequest<T>(string endpointUrl, Dictionary<string, object> queryParam)
        {

            RestRequest restRequest = new RestRequest(endpointUrl);

            addQueryParams(restRequest, queryParam);

            IRestResponse<T> restResponse = RestClient.Get<T>(restRequest);

            return restResponse;

        }

        public IRestResponse<T> SendGetRequest<T>(string endpointUrl, Dictionary<string,object> queryParam, Dictionary<string, object> headers)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);

            addQueryParams(restRequest, queryParam);


            addHeaders(restRequest, headers);

            IRestResponse<T> restResponse = RestClient.Get<T>(restRequest);

            return restResponse;

        }

        public IRestResponse<T> SendPostRequest<T>(string endpointUrl, Object requestPayload)
        {

            RestRequest restRequest = new RestRequest(endpointUrl);

            
            restRequest.AddJsonBody(requestPayload);

            IRestResponse<T> restResponse = RestClient.Post<T>(restRequest);

            return restResponse;

        }

        public IRestResponse<T> SendPostRequest<T>(string endpointUrl, Object requestPayload, Dictionary<string, object> headers)
        {

            RestRequest restRequest = new RestRequest(endpointUrl);

            addHeaders(restRequest, headers);

            restRequest.AddJsonBody(requestPayload);

            IRestResponse<T> restResponse = RestClient.Post<T>(restRequest);

            return restResponse;

        }

        public IRestResponse<T> SendPutRequest<T>(string endpointUrl, Object requestPayload)
        {

            RestRequest restRequest = new RestRequest(endpointUrl);

            restRequest.AddJsonBody(requestPayload);


          

            IRestResponse<T> restResponse = RestClient.Put<T>(restRequest);

            return restResponse;

        }


        public IRestResponse SendPatchRequest(RestRequest request, Object requestPayload, Dictionary<string, object> headers)
        {
            request.AddJsonBody(requestPayload);


            addHeaders(request, headers);

            IRestResponse restResponse = RestClient.Patch(request);

            return restResponse;

        }


        public IRestResponse SendDeleteRequest(RestRequest request, Dictionary<string, object> headers)
        {
            addHeaders(request, headers);


            IRestResponse restResponse = RestClient.Delete(request);

            return restResponse;
        }

        private void addHeaders(RestRequest restRequest, Dictionary<string, object> headers)
        {

            foreach (var header in headers)
            {
                restRequest.AddParameter(header.Key, header.Value);
            }

        }

        private void addQueryParams(RestRequest restRequest, Dictionary<string, object> queryParam)
        {

            foreach (var param in queryParam)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }
        }


    }
}
