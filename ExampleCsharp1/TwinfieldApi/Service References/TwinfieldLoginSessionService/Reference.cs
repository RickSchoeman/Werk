﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwinfieldApi.TwinfieldLoginSessionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.twinfield.com/", ConfigurationName="TwinfieldLoginSessionService.SessionSoap")]
    public interface SessionSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/Logon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TwinfieldApi.TwinfieldLoginSessionService.LogonResponse Logon(TwinfieldApi.TwinfieldLoginSessionService.LogonRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/Logon", ReplyAction="*")]
        System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.LogonResponse> LogonAsync(TwinfieldApi.TwinfieldLoginSessionService.LogonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/OAuthLogon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonResponse OAuthLogon(TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/OAuthLogon", ReplyAction="*")]
        System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonResponse> OAuthLogonAsync(TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/AccessTokenLogon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonResponse AccessTokenLogon(TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/AccessTokenLogon", ReplyAction="*")]
        System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonResponse> AccessTokenLogonAsync(TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest request);
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum LogonResult {
        
        /// <remarks/>
        Ok,
        
        /// <remarks/>
        Blocked,
        
        /// <remarks/>
        Untrusted,
        
        /// <remarks/>
        Invalid,
        
        /// <remarks/>
        Deleted,
        
        /// <remarks/>
        Disabled,
        
        /// <remarks/>
        OrganisationInactive,
        
        /// <remarks/>
        ClientInvalid,
        
        /// <remarks/>
        Failed,
        
        /// <remarks/>
        TokenInvalid,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum LogonAction {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        SMSLogon,
        
        /// <remarks/>
        ChangePassword,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Logon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class LogonRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string user;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string organisation;
        
        public LogonRequest() {
        }
        
        public LogonRequest(string user, string password, string organisation) {
            this.user = user;
            this.password = password;
            this.organisation = organisation;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LogonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class LogonResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldApi.TwinfieldLoginSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldApi.TwinfieldLoginSessionService.LogonResult LogonResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string cluster;
        
        public LogonResponse() {
        }
        
        public LogonResponse(TwinfieldApi.TwinfieldLoginSessionService.Header Header, TwinfieldApi.TwinfieldLoginSessionService.LogonResult LogonResult, TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction, string cluster) {
            this.Header = Header;
            this.LogonResult = LogonResult;
            this.nextAction = nextAction;
            this.cluster = cluster;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="OAuthLogon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class OAuthLogonRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string clientToken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string clientSecret;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string accessToken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=3)]
        public string accessSecret;
        
        public OAuthLogonRequest() {
        }
        
        public OAuthLogonRequest(string clientToken, string clientSecret, string accessToken, string accessSecret) {
            this.clientToken = clientToken;
            this.clientSecret = clientSecret;
            this.accessToken = accessToken;
            this.accessSecret = accessSecret;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="OAuthLogonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class OAuthLogonResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldApi.TwinfieldLoginSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldApi.TwinfieldLoginSessionService.LogonResult OAuthLogonResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string cluster;
        
        public OAuthLogonResponse() {
        }
        
        public OAuthLogonResponse(TwinfieldApi.TwinfieldLoginSessionService.Header Header, TwinfieldApi.TwinfieldLoginSessionService.LogonResult OAuthLogonResult, TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction, string cluster) {
            this.Header = Header;
            this.OAuthLogonResult = OAuthLogonResult;
            this.nextAction = nextAction;
            this.cluster = cluster;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AccessTokenLogon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class AccessTokenLogonRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string accessToken;
        
        public AccessTokenLogonRequest() {
        }
        
        public AccessTokenLogonRequest(string accessToken) {
            this.accessToken = accessToken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AccessTokenLogonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class AccessTokenLogonResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldApi.TwinfieldLoginSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldApi.TwinfieldLoginSessionService.LogonResult AccessTokenLogonResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string cluster;
        
        public AccessTokenLogonResponse() {
        }
        
        public AccessTokenLogonResponse(TwinfieldApi.TwinfieldLoginSessionService.Header Header, TwinfieldApi.TwinfieldLoginSessionService.LogonResult AccessTokenLogonResult, string cluster) {
            this.Header = Header;
            this.AccessTokenLogonResult = AccessTokenLogonResult;
            this.cluster = cluster;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SessionSoapChannel : TwinfieldApi.TwinfieldLoginSessionService.SessionSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SessionSoapClient : System.ServiceModel.ClientBase<TwinfieldApi.TwinfieldLoginSessionService.SessionSoap>, TwinfieldApi.TwinfieldLoginSessionService.SessionSoap {
        
        public SessionSoapClient() {
        }
        
        public SessionSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SessionSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TwinfieldApi.TwinfieldLoginSessionService.LogonResponse TwinfieldApi.TwinfieldLoginSessionService.SessionSoap.Logon(TwinfieldApi.TwinfieldLoginSessionService.LogonRequest request) {
            return base.Channel.Logon(request);
        }
        
        public TwinfieldApi.TwinfieldLoginSessionService.Header Logon(string user, string password, string organisation, out TwinfieldApi.TwinfieldLoginSessionService.LogonResult LogonResult, out TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction, out string cluster) {
            TwinfieldApi.TwinfieldLoginSessionService.LogonRequest inValue = new TwinfieldApi.TwinfieldLoginSessionService.LogonRequest();
            inValue.user = user;
            inValue.password = password;
            inValue.organisation = organisation;
            TwinfieldApi.TwinfieldLoginSessionService.LogonResponse retVal = ((TwinfieldApi.TwinfieldLoginSessionService.SessionSoap)(this)).Logon(inValue);
            LogonResult = retVal.LogonResult;
            nextAction = retVal.nextAction;
            cluster = retVal.cluster;
            return retVal.Header;
        }
        
        public System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.LogonResponse> LogonAsync(TwinfieldApi.TwinfieldLoginSessionService.LogonRequest request) {
            return base.Channel.LogonAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonResponse TwinfieldApi.TwinfieldLoginSessionService.SessionSoap.OAuthLogon(TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest request) {
            return base.Channel.OAuthLogon(request);
        }
        
        public TwinfieldApi.TwinfieldLoginSessionService.Header OAuthLogon(string clientToken, string clientSecret, string accessToken, string accessSecret, out TwinfieldApi.TwinfieldLoginSessionService.LogonResult OAuthLogonResult, out TwinfieldApi.TwinfieldLoginSessionService.LogonAction nextAction, out string cluster) {
            TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest inValue = new TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest();
            inValue.clientToken = clientToken;
            inValue.clientSecret = clientSecret;
            inValue.accessToken = accessToken;
            inValue.accessSecret = accessSecret;
            TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonResponse retVal = ((TwinfieldApi.TwinfieldLoginSessionService.SessionSoap)(this)).OAuthLogon(inValue);
            OAuthLogonResult = retVal.OAuthLogonResult;
            nextAction = retVal.nextAction;
            cluster = retVal.cluster;
            return retVal.Header;
        }
        
        public System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonResponse> OAuthLogonAsync(TwinfieldApi.TwinfieldLoginSessionService.OAuthLogonRequest request) {
            return base.Channel.OAuthLogonAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonResponse TwinfieldApi.TwinfieldLoginSessionService.SessionSoap.AccessTokenLogon(TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest request) {
            return base.Channel.AccessTokenLogon(request);
        }
        
        public TwinfieldApi.TwinfieldLoginSessionService.Header AccessTokenLogon(string accessToken, out TwinfieldApi.TwinfieldLoginSessionService.LogonResult AccessTokenLogonResult, out string cluster) {
            TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest inValue = new TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest();
            inValue.accessToken = accessToken;
            TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonResponse retVal = ((TwinfieldApi.TwinfieldLoginSessionService.SessionSoap)(this)).AccessTokenLogon(inValue);
            AccessTokenLogonResult = retVal.AccessTokenLogonResult;
            cluster = retVal.cluster;
            return retVal.Header;
        }
        
        public System.Threading.Tasks.Task<TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonResponse> AccessTokenLogonAsync(TwinfieldApi.TwinfieldLoginSessionService.AccessTokenLogonRequest request) {
            return base.Channel.AccessTokenLogonAsync(request);
        }
    }
}
