using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyApplicationTest.Utils
{
    public class AssertStatusCode
    {
        internal static void VerifySuccessCode(IRestResponse restResponse)
        {

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        internal static void VerifyCreateCode(IRestResponse restResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
        }

        internal static void VerifyInternalServerCode(IRestResponse restResponse)
        {
            Assert.AreEqual(HttpStatusCode.InternalServerError, restResponse.StatusCode);
        }

        internal static void VerifyNotFoundCode(IRestResponse restResponse)
        {
            Assert.AreEqual(HttpStatusCode.NotFound, restResponse.StatusCode);
        }
    }
}
