using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace System.ServiceModel.Description
{
    public class JsonQueryStringWebHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new JsonQueryStringConverter();
        }
    }
}
