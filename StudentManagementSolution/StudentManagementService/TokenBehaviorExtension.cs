using System;
using System.ServiceModel.Configuration;

namespace StudentManagementService
{
    public class TokenBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(TokenInspector); }
        }

        protected override object CreateBehavior()
        {
            return new TokenInspector();
        }
    }
}