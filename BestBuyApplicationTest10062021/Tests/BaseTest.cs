using BestBuyApplicationTest.Request.Product;
using BestBuyApplicationTest.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApplicationTest.Tests
{
    [TestClass]
    public class BaseTest
    {

        private string baseUrl = "http://ec2-18-223-213-189.us-east-2.compute.amazonaws.com";

        private int portNumber = 3030;

       

        private string endpointUrl;

        internal RequestFactory productRequestFactory;

        [TestInitialize]
        public void Setup()
        {
            endpointUrl = $"{baseUrl}:{portNumber}{Routes.PRODUCT}";

            productRequestFactory = new RequestFactory(endpointUrl);


        }
    }
}
