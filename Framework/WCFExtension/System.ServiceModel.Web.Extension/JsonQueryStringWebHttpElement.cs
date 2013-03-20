using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace System.ServiceModel.Configuration
{
    public class JsonQueryStringWebHttpElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(JsonQueryStringWebHttpBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new JsonQueryStringWebHttpBehavior();
        }
    }
}
