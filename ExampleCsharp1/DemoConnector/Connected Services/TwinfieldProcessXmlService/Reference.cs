﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoConnector.TwinfieldProcessXmlService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.twinfield.com/", ConfigurationName="TwinfieldProcessXmlService.ProcessXmlSoap")]
    public interface ProcessXmlSoap {
        
        // CODEGEN: Generating message contract since message ProcessXmlStringRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlString", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse ProcessXmlString(DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlString", ReplyAction="*")]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse> ProcessXmlStringAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest request);
        
        // CODEGEN: Generating message contract since message ProcessXmlDocumentRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlDocument", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse ProcessXmlDocument(DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlDocument", ReplyAction="*")]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse> ProcessXmlDocumentAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest request);
        
        // CODEGEN: Generating message contract since message ProcessXmlCompressedRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlCompressed", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse ProcessXmlCompressed(DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ProcessXmlCompressed", ReplyAction="*")]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse> ProcessXmlCompressedAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public partial class Header : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sessionIDField;
        
        private string accessTokenField;
        
        private string companyCodeField;
        
        private System.Nullable<System.Guid> companyIdField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SessionID {
            get {
                return this.sessionIDField;
            }
            set {
                this.sessionIDField = value;
                this.RaisePropertyChanged("SessionID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string AccessToken {
            get {
                return this.accessTokenField;
            }
            set {
                this.accessTokenField = value;
                this.RaisePropertyChanged("AccessToken");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CompanyCode {
            get {
                return this.companyCodeField;
            }
            set {
                this.companyCodeField = value;
                this.RaisePropertyChanged("CompanyCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<System.Guid> CompanyId {
            get {
                return this.companyIdField;
            }
            set {
                this.companyIdField = value;
                this.RaisePropertyChanged("CompanyId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlString", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlStringRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public DemoConnector.TwinfieldProcessXmlService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string xmlRequest;
        
        public ProcessXmlStringRequest() {
        }
        
        public ProcessXmlStringRequest(DemoConnector.TwinfieldProcessXmlService.Header Header, string xmlRequest) {
            this.Header = Header;
            this.xmlRequest = xmlRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlStringResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlStringResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string ProcessXmlStringResult;
        
        public ProcessXmlStringResponse() {
        }
        
        public ProcessXmlStringResponse(string ProcessXmlStringResult) {
            this.ProcessXmlStringResult = ProcessXmlStringResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlDocument", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlDocumentRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public DemoConnector.TwinfieldProcessXmlService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public System.Xml.XmlNode xmlRequest;
        
        public ProcessXmlDocumentRequest() {
        }
        
        public ProcessXmlDocumentRequest(DemoConnector.TwinfieldProcessXmlService.Header Header, System.Xml.XmlNode xmlRequest) {
            this.Header = Header;
            this.xmlRequest = xmlRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlDocumentResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlDocumentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public System.Xml.XmlNode ProcessXmlDocumentResult;
        
        public ProcessXmlDocumentResponse() {
        }
        
        public ProcessXmlDocumentResponse(System.Xml.XmlNode ProcessXmlDocumentResult) {
            this.ProcessXmlDocumentResult = ProcessXmlDocumentResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlCompressed", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlCompressedRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public DemoConnector.TwinfieldProcessXmlService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] xmlRequest;
        
        public ProcessXmlCompressedRequest() {
        }
        
        public ProcessXmlCompressedRequest(DemoConnector.TwinfieldProcessXmlService.Header Header, byte[] xmlRequest) {
            this.Header = Header;
            this.xmlRequest = xmlRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessXmlCompressedResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ProcessXmlCompressedResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] ProcessXmlCompressedResult;
        
        public ProcessXmlCompressedResponse() {
        }
        
        public ProcessXmlCompressedResponse(byte[] ProcessXmlCompressedResult) {
            this.ProcessXmlCompressedResult = ProcessXmlCompressedResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ProcessXmlSoapChannel : DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProcessXmlSoapClient : System.ServiceModel.ClientBase<DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap>, DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap {
        
        public ProcessXmlSoapClient() {
        }
        
        public ProcessXmlSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProcessXmlSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProcessXmlSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProcessXmlSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlString(DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest request) {
            return base.Channel.ProcessXmlString(request);
        }
        
        public string ProcessXmlString(DemoConnector.TwinfieldProcessXmlService.Header Header, string xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse retVal = ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlString(inValue);
            return retVal.ProcessXmlStringResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse> DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlStringAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest request) {
            return base.Channel.ProcessXmlStringAsync(request);
        }
        
        public System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringResponse> ProcessXmlStringAsync(DemoConnector.TwinfieldProcessXmlService.Header Header, string xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlStringRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            return ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlStringAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlDocument(DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest request) {
            return base.Channel.ProcessXmlDocument(request);
        }
        
        public System.Xml.XmlNode ProcessXmlDocument(DemoConnector.TwinfieldProcessXmlService.Header Header, System.Xml.XmlNode xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse retVal = ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlDocument(inValue);
            return retVal.ProcessXmlDocumentResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse> DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlDocumentAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest request) {
            return base.Channel.ProcessXmlDocumentAsync(request);
        }
        
        public System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentResponse> ProcessXmlDocumentAsync(DemoConnector.TwinfieldProcessXmlService.Header Header, System.Xml.XmlNode xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlDocumentRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            return ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlDocumentAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlCompressed(DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest request) {
            return base.Channel.ProcessXmlCompressed(request);
        }
        
        public byte[] ProcessXmlCompressed(DemoConnector.TwinfieldProcessXmlService.Header Header, byte[] xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse retVal = ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlCompressed(inValue);
            return retVal.ProcessXmlCompressedResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse> DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap.ProcessXmlCompressedAsync(DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest request) {
            return base.Channel.ProcessXmlCompressedAsync(request);
        }
        
        public System.Threading.Tasks.Task<DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedResponse> ProcessXmlCompressedAsync(DemoConnector.TwinfieldProcessXmlService.Header Header, byte[] xmlRequest) {
            DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest inValue = new DemoConnector.TwinfieldProcessXmlService.ProcessXmlCompressedRequest();
            inValue.Header = Header;
            inValue.xmlRequest = xmlRequest;
            return ((DemoConnector.TwinfieldProcessXmlService.ProcessXmlSoap)(this)).ProcessXmlCompressedAsync(inValue);
        }
    }
}
