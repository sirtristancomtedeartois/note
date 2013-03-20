using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Notenet.Security
{
    /// <summary>
    /// Works only in AspNetCompatibility mode
    /// </summary>
    public class WCFPermissionAttribute : Attribute, IOperationBehavior, IParameterInspector
    {
        private static string logonURL;

        static WCFPermissionAttribute()
        {
            WCFPermissionAttribute.logonURL = ConfigurationManager.AppSettings["LogOnUrl"];
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                this.LogOn();
            }

            return null;
        }

        private void LogOn()
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Redirect;
            WebOperationContext.Current.OutgoingResponse.Location = String.Format(WCFPermissionAttribute.logonURL,
                WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri.Scheme,
                WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri.Authority,
                WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.PathAndQuery.Remove(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.Segments[0].Length, WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.Segments[1].Length));
        }
    }
}
