﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Net.Security;

namespace DemoTokenClient.DemoService {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/ServiceplatformFault/1/")]
    public partial class ServiceplatformFaultType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private ErrorType[] errorListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Error", IsNullable=false)]
        public ErrorType[] ErrorList {
            get {
                return this.errorListField;
            }
            set {
                this.errorListField = value;
                this.RaisePropertyChanged("ErrorList");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/ServiceplatformFault/1/")]
    public partial class ErrorType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string errorCodeField;
        
        private string errorTextField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ErrorText {
            get {
                return this.errorTextField;
            }
            set {
                this.errorTextField = value;
                this.RaisePropertyChanged("ErrorText");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/")]
    public partial class CallDemoServiceResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string responseStringField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string responseString {
            get {
                return this.responseStringField;
            }
            set {
                this.responseStringField = value;
                this.RaisePropertyChanged("responseString");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/InvocationContext/1/")]
    public partial class InvocationContextType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string serviceAgreementUUIDField;
        
        private string userSystemUUIDField;
        
        private string userUUIDField;
        
        private string onBehalfOfUserField;
        
        private string serviceUUIDField;
        
        private string callersServiceCallIdentifierField;
        
        private string accountingInfoField;
        
        /// <remarks/>
        public string ServiceAgreementUUID {
            get {
                return this.serviceAgreementUUIDField;
            }
            set {
                this.serviceAgreementUUIDField = value;
                this.RaisePropertyChanged("ServiceAgreementUUID");
            }
        }
        
        /// <remarks/>
        public string UserSystemUUID {
            get {
                return this.userSystemUUIDField;
            }
            set {
                this.userSystemUUIDField = value;
                this.RaisePropertyChanged("UserSystemUUID");
            }
        }
        
        /// <remarks/>
        public string UserUUID {
            get {
                return this.userUUIDField;
            }
            set {
                this.userUUIDField = value;
                this.RaisePropertyChanged("UserUUID");
            }
        }
        
        /// <remarks/>
        public string OnBehalfOfUser {
            get {
                return this.onBehalfOfUserField;
            }
            set {
                this.onBehalfOfUserField = value;
                this.RaisePropertyChanged("OnBehalfOfUser");
            }
        }
        
        /// <remarks/>
        public string ServiceUUID {
            get {
                return this.serviceUUIDField;
            }
            set {
                this.serviceUUIDField = value;
                this.RaisePropertyChanged("ServiceUUID");
            }
        }
        
        /// <remarks/>
        public string CallersServiceCallIdentifier {
            get {
                return this.callersServiceCallIdentifierField;
            }
            set {
                this.callersServiceCallIdentifierField = value;
                this.RaisePropertyChanged("CallersServiceCallIdentifier");
            }
        }
        
        /// <remarks/>
        public string AccountingInfo {
            get {
                return this.accountingInfoField;
            }
            set {
                this.accountingInfoField = value;
                this.RaisePropertyChanged("AccountingInfo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/AuthorityContext/1/")]
    public partial class AuthorityContextType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string municipalityCVRField;
        
        /// <remarks/>
        public string MunicipalityCVR {
            get {
                return this.municipalityCVRField;
            }
            set {
                this.municipalityCVRField = value;
                this.RaisePropertyChanged("MunicipalityCVR");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/CallContext/1/")]
    public partial class CallContextType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string onBehalfOfUserField;
        
        private string callersServiceCallIdentifierField;
        
        private string accountingInfoField;
        
        /// <remarks/>
        public string OnBehalfOfUser {
            get {
                return this.onBehalfOfUserField;
            }
            set {
                this.onBehalfOfUserField = value;
                this.RaisePropertyChanged("OnBehalfOfUser");
            }
        }
        
        /// <remarks/>
        public string CallersServiceCallIdentifier {
            get {
                return this.callersServiceCallIdentifierField;
            }
            set {
                this.callersServiceCallIdentifierField = value;
                this.RaisePropertyChanged("CallersServiceCallIdentifier");
            }
        }
        
        /// <remarks/>
        public string AccountingInfo {
            get {
                return this.accountingInfoField;
            }
            set {
                this.accountingInfoField = value;
                this.RaisePropertyChanged("AccountingInfo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/")]
    public partial class CallDemoServiceRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private CallContextType callContextField;
        
        private AuthorityContextType authorityContextField;
        
        private InvocationContextType invocationContextField;
        
        private string messageStringField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/CallContext/1/", Order=0)]
        public CallContextType CallContext {
            get {
                return this.callContextField;
            }
            set {
                this.callContextField = value;
                this.RaisePropertyChanged("CallContext");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/AuthorityContext/1/", Order=1)]
        public AuthorityContextType AuthorityContext {
            get {
                return this.authorityContextField;
            }
            set {
                this.authorityContextField = value;
                this.RaisePropertyChanged("AuthorityContext");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://serviceplatformen.dk/xml/schemas/InvocationContext/1/", Order=2)]
        public InvocationContextType InvocationContext {
            get {
                return this.invocationContextField;
            }
            set {
                this.invocationContextField = value;
                this.RaisePropertyChanged("InvocationContext");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string messageString {
            get {
                return this.messageStringField;
            }
            set {
                this.messageStringField = value;
                this.RaisePropertyChanged("messageString");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/", ConfigurationName="DemoService.DemoPortType")]
    public interface DemoPortType {
        
        // CODEGEN: Generating message contract since the operation callDemoService is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/callDemoService", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(DemoTokenClient.DemoService.ServiceplatformFaultType), Action="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/callDemoService", Name="ServiceplatformFault", Namespace="http://serviceplatformen.dk/xml/schemas/ServiceplatformFault/1/")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DemoTokenClient.DemoService.callDemoServiceResponse callDemoService(DemoTokenClient.DemoService.callDemoServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/callDemoService", ReplyAction="*")]
        System.Threading.Tasks.Task<DemoTokenClient.DemoService.callDemoServiceResponse> callDemoServiceAsync(DemoTokenClient.DemoService.callDemoServiceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class callDemoServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CallDemoServiceRequest", Namespace="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/", Order=0)]
        public DemoTokenClient.DemoService.CallDemoServiceRequestType CallDemoServiceRequest1;
        
        public callDemoServiceRequest() {
        }
        
        public callDemoServiceRequest(DemoTokenClient.DemoService.CallDemoServiceRequestType CallDemoServiceRequest1) {
            this.CallDemoServiceRequest1 = CallDemoServiceRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class callDemoServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CallDemoServiceResponse", Namespace="http://serviceplatformen.dk/xml/wsdl/soap11/SP/Demo/1/", Order=0)]
        public DemoTokenClient.DemoService.CallDemoServiceResponseType CallDemoServiceResponse1;
        
        public callDemoServiceResponse() {
        }
        
        public callDemoServiceResponse(DemoTokenClient.DemoService.CallDemoServiceResponseType CallDemoServiceResponse1) {
            this.CallDemoServiceResponse1 = CallDemoServiceResponse1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DemoPortTypeChannel : DemoTokenClient.DemoService.DemoPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DemoPortTypeClient : System.ServiceModel.ClientBase<DemoTokenClient.DemoService.DemoPortType>, DemoTokenClient.DemoService.DemoPortType {
        
        public DemoPortTypeClient() {
        }
        
        public DemoPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DemoPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DemoPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DemoPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DemoTokenClient.DemoService.callDemoServiceResponse DemoTokenClient.DemoService.DemoPortType.callDemoService(DemoTokenClient.DemoService.callDemoServiceRequest request) {
            return base.Channel.callDemoService(request);
        }
        
        public DemoTokenClient.DemoService.CallDemoServiceResponseType callDemoService(DemoTokenClient.DemoService.CallDemoServiceRequestType CallDemoServiceRequest1) {
            DemoTokenClient.DemoService.callDemoServiceRequest inValue = new DemoTokenClient.DemoService.callDemoServiceRequest();
            inValue.CallDemoServiceRequest1 = CallDemoServiceRequest1;
            DemoTokenClient.DemoService.callDemoServiceResponse retVal = ((DemoTokenClient.DemoService.DemoPortType)(this)).callDemoService(inValue);
            return retVal.CallDemoServiceResponse1;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DemoTokenClient.DemoService.callDemoServiceResponse> DemoTokenClient.DemoService.DemoPortType.callDemoServiceAsync(DemoTokenClient.DemoService.callDemoServiceRequest request) {
            return base.Channel.callDemoServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<DemoTokenClient.DemoService.callDemoServiceResponse> callDemoServiceAsync(DemoTokenClient.DemoService.CallDemoServiceRequestType CallDemoServiceRequest1) {
            DemoTokenClient.DemoService.callDemoServiceRequest inValue = new DemoTokenClient.DemoService.callDemoServiceRequest();
            inValue.CallDemoServiceRequest1 = CallDemoServiceRequest1;
            return ((DemoTokenClient.DemoService.DemoPortType)(this)).callDemoServiceAsync(inValue);
        }
    }
}
