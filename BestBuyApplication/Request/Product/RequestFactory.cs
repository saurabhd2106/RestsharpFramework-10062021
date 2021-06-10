using BestBuyApplication.Model.Product;
using CommonLibs.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApplicationTest.Request.Product
{
    public class RequestFactory
    {

        private CustomRestClient restClient;

        private string endpointUrl;

        public RequestFactory(string endpointUrl)
        {
            this.endpointUrl = endpointUrl;
            restClient = new CustomRestClient();
        }

        public IRestResponse<T> GetAllProduct<T>()
        {


            IRestResponse<T> response = restClient.SendGetRequest<T>(endpointUrl);

            return response;

        }

        public IRestResponse<T> GetProduct<T>(int productId)
        {


            IRestResponse<T> response = restClient.SendGetRequest<T>($"{ endpointUrl}/{productId}");

            return response;

        }

        public IRestResponse<T> GetAllProduct<T>(int limit, int skip)
        {
            Dictionary<string, object> queryParam = new Dictionary<string, object>();

            queryParam.Add("$limit", limit);

            queryParam.Add("$skip", skip);

            IRestResponse<T> response = restClient.SendGetRequest<T>(endpointUrl, queryParam);

            return response;

        }

        public IRestResponse<T> AddProduct<T>(object requestPayload)
        {
            IRestResponse<T> response = restClient.SendPostRequest<T>(endpointUrl, requestPayload);

            return response;
        }

        public IRestResponse<T> EditProduct<T>(int productId,object requestPayload)
        {
            IRestResponse<T> response = restClient.SendPutRequest<T>($"{endpointUrl}/{productId}", requestPayload);

            return response;
        }
    }
}
