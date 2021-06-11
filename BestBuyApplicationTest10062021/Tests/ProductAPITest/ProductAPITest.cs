using AventStack.ExtentReports;
using BestBuyApplication.Model.Product;
using BestBuyApplicationTest.Request.Product;
using BestBuyApplicationTest.Utils;
using CommonLibs.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyApplicationTest.Tests.ProductAPITest
{
    [TestClass]
    public class ProductAPITest : BaseTest
    {

        

        [TestMethod]
        public void VerifyGetProductApi()
        {

            Reporter.CreateATestCase("Verify Get Product API", "This Test verifies the Get product API");

            IRestResponse<ProductDto> restResponse = productRequestFactory.GetAllProduct<ProductDto>();

            Console.WriteLine(restResponse.Content);

            AssertStatusCode.VerifySuccessCode(restResponse);

            Reporter.AddLogs(Status.Info, restResponse.Content);

            Assert.AreEqual(10, restResponse.Data.limit);

        }

        [TestMethod]
        public void VerifyGetProductApiWithQueryParam()
        {

            Reporter.CreateATestCase("Verify Get Product API with Query Param", "This Test verifies the Get product API");

            int limit = 5;

            IRestResponse<ProductDto> restResponse = productRequestFactory.GetAllProduct<ProductDto>(limit, 0);

            Console.WriteLine(restResponse.Content);

            AssertStatusCode.VerifySuccessCode(restResponse);

            Assert.AreEqual(limit, restResponse.Data.limit);

            Reporter.AddLogs(Status.Info, restResponse.Content);

        }

        [TestMethod]
        public void VerifyPostProduct()
        {

            Reporter.CreateATestCase("Verify Post Product API", "This Test verifies the Post product API");


            string requestPayload = "{\r\n    \"name\": \"IPhone\",\r\n    \"type\": \"Mobile\",\r\n    \"price\": 1000,\r\n    \"shipping\": 10,\r\n    \"upc\": \"dsfhj3424\",\r\n    \"description\": \"Best Mobile in the town\",\r\n    \"manufacturer\": \"Apple\",\r\n    \"model\": \"IPhone 12\",\r\n    \"url\": \"string\",\r\n    \"image\": \"string\"\r\n}";


            IRestResponse<DataDto> restResponse =   productRequestFactory.AddProduct<DataDto>(requestPayload);



            AssertStatusCode.VerifyCreateCode(restResponse);

            Assert.AreEqual("IPhone", restResponse.Data.name);

            Console.WriteLine(restResponse.Data.id);

            Reporter.AddLogs(Status.Info, restResponse.Content);

        }

        [TestMethod]
        public void VerifyPostProductRequestWithInsufficientData()
        {
            Reporter.CreateATestCase("Verify Post Product API", "This Test verifies the Get product API");



            Dictionary<string, object> requestpayload = new Dictionary<string, object>();

            requestpayload.Add("name", "Samsung Mobile");

            requestpayload.Add("type", "Mobile");

           IRestResponse<ProductErrorDto> restResponse = productRequestFactory.AddProduct<ProductErrorDto>(requestpayload);

            Assert.AreEqual(HttpStatusCode.InternalServerError, restResponse.StatusCode);

            Assert.AreEqual("GeneralError", restResponse.Data.name);


        }


        [TestMethod]
        public void VerifyPostProductWithRequestPayloadAsDTO()
        {



            Reporter.CreateATestCase("Verify Post Product API with Request Payload", "This Test verifies the Post product API");


            ProductRequestDto requestPayload = new ProductRequestDto();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";
   
            IRestResponse<DataDto> restResponse = productRequestFactory.AddProduct<DataDto>(requestPayload);

            AssertStatusCode.VerifyCreateCode(restResponse);

            Console.WriteLine(restResponse.Data.id);

        }


        [TestMethod]
        public void VerifyEditProduct()
        {


            ProductRequestDto requestPayload = new ProductRequestDto();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";

            IRestResponse<DataDto> restResponse = productRequestFactory.AddProduct<DataDto>(requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

            int productId = restResponse.Data.id;

            ProductRequestDto updatedRequestPayload = new ProductRequestDto();
          
            updatedRequestPayload.name = "Iphone Mobile";
            updatedRequestPayload.type = "Mobile";
            updatedRequestPayload.price = 1000;
            updatedRequestPayload.shipping = 10;
            updatedRequestPayload.upc = "asd@udfg";
            updatedRequestPayload.description = "Best Mobile";
            updatedRequestPayload.manufacturer = "Samsung";
            updatedRequestPayload.model = "M21";
            updatedRequestPayload.url = "asfhgsdjh";
            updatedRequestPayload.image = "asfskd";



            IRestResponse<DataDto> updatedResponse = productRequestFactory.EditProduct<DataDto>(productId, updatedRequestPayload);

            Assert.AreEqual(HttpStatusCode.OK, updatedResponse.StatusCode);

            Assert.AreEqual(updatedRequestPayload.name, updatedResponse.Data.name);

        }

    }
}
