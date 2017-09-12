using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace refactor_me.Models
{
    public class CustomActionResult : IHttpActionResult
    {
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }

        public System.Net.HttpStatusCode StatusCode { get; set; }

        public CustomActionResult(HttpRequestMessage request, string message, System.Net.HttpStatusCode _HttpStatusCode)
        {
            this.Request = request;
            this.Message = message;
            StatusCode = _HttpStatusCode;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteResult());
        }

        public HttpResponseMessage ExecuteResult()
        {
            HttpResponseMessage response = new HttpResponseMessage(StatusCode);

            response.Content = new StringContent(Message);
            response.RequestMessage = Request;
            return response;
        }
    }

}