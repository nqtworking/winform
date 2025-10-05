using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace StudentManagementService
{
    public class TokenInspector : IDispatchMessageInspector, IServiceBehavior
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Check for token header
            var tokenHeader = request.Headers.GetHeader<string>("AuthToken", "http://tempuri.org");
            if (tokenHeader == null || !AuthService.ValidateToken(tokenHeader))
            {
                throw new FaultException("Authentication required or invalid token");
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState) { }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, 
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, 
            BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cDispatcher in serviceHostBase.ChannelDispatchers)
            {
                var dispatcher = cDispatcher as ChannelDispatcher;
                if (dispatcher != null)
                {
                    foreach (var endpointDispatcher in dispatcher.Endpoints)
                    {
                        if (endpointDispatcher.ContractName != "IAuthService")  // Skip auth service
                            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
}