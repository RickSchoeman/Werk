﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoConnector.TwinfieldMatchingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.twinfield.com/", ConfigurationName="TwinfieldMatchingService.MatchingSoap")]
    public interface MatchingSoap {
        
        // CODEGEN: Generating message contract since message UndoMatchRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/UndoMatch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DemoConnector.TwinfieldMatchingService.UndoMatchResponse UndoMatch(DemoConnector.TwinfieldMatchingService.UndoMatchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/UndoMatch", ReplyAction="*")]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldMatchingService.UndoMatchResponse> UndoMatchAsync(DemoConnector.TwinfieldMatchingService.UndoMatchRequest request);
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public partial class MessageOfUndoSetByTypeResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MessageType typeField;
        
        private string textField;
        
        private UndoSetByTypeResult codeField;
        
        private string[] parametersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MessageType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
                this.RaisePropertyChanged("Text");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public UndoSetByTypeResult Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public string[] Parameters {
            get {
                return this.parametersField;
            }
            set {
                this.parametersField = value;
                this.RaisePropertyChanged("Parameters");
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
    public enum MessageType {
        
        /// <remarks/>
        Error,
        
        /// <remarks/>
        Warning,
        
        /// <remarks/>
        Informational,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum UndoSetByTypeResult {
        
        /// <remarks/>
        DimensionNotFoundByType,
        
        /// <remarks/>
        DimensionDeleted,
        
        /// <remarks/>
        DimensionNotFoundByLevel,
        
        /// <remarks/>
        MatchNotFound,
        
        /// <remarks/>
        MatchingTransactionsCouldNotBeDeleted,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UndoMatch", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class UndoMatchRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public DemoConnector.TwinfieldMatchingService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string office;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string dimensionType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string dimension;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=3)]
        public int matchNumber;
        
        public UndoMatchRequest() {
        }
        
        public UndoMatchRequest(DemoConnector.TwinfieldMatchingService.Header Header, string office, string dimensionType, string dimension, int matchNumber) {
            this.Header = Header;
            this.office = office;
            this.dimensionType = dimensionType;
            this.dimension = dimension;
            this.matchNumber = matchNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UndoMatchResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class UndoMatchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public DemoConnector.TwinfieldMatchingService.MessageOfUndoSetByTypeResult[] UndoMatchResult;
        
        public UndoMatchResponse() {
        }
        
        public UndoMatchResponse(DemoConnector.TwinfieldMatchingService.MessageOfUndoSetByTypeResult[] UndoMatchResult) {
            this.UndoMatchResult = UndoMatchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MatchingSoapChannel : DemoConnector.TwinfieldMatchingService.MatchingSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MatchingSoapClient : System.ServiceModel.ClientBase<DemoConnector.TwinfieldMatchingService.MatchingSoap>, DemoConnector.TwinfieldMatchingService.MatchingSoap {
        
        public MatchingSoapClient() {
        }
        
        public MatchingSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MatchingSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MatchingSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MatchingSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DemoConnector.TwinfieldMatchingService.UndoMatchResponse DemoConnector.TwinfieldMatchingService.MatchingSoap.UndoMatch(DemoConnector.TwinfieldMatchingService.UndoMatchRequest request) {
            return base.Channel.UndoMatch(request);
        }
        
        public DemoConnector.TwinfieldMatchingService.MessageOfUndoSetByTypeResult[] UndoMatch(DemoConnector.TwinfieldMatchingService.Header Header, string office, string dimensionType, string dimension, int matchNumber) {
            DemoConnector.TwinfieldMatchingService.UndoMatchRequest inValue = new DemoConnector.TwinfieldMatchingService.UndoMatchRequest();
            inValue.Header = Header;
            inValue.office = office;
            inValue.dimensionType = dimensionType;
            inValue.dimension = dimension;
            inValue.matchNumber = matchNumber;
            DemoConnector.TwinfieldMatchingService.UndoMatchResponse retVal = ((DemoConnector.TwinfieldMatchingService.MatchingSoap)(this)).UndoMatch(inValue);
            return retVal.UndoMatchResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DemoConnector.TwinfieldMatchingService.UndoMatchResponse> DemoConnector.TwinfieldMatchingService.MatchingSoap.UndoMatchAsync(DemoConnector.TwinfieldMatchingService.UndoMatchRequest request) {
            return base.Channel.UndoMatchAsync(request);
        }
        
        public System.Threading.Tasks.Task<DemoConnector.TwinfieldMatchingService.UndoMatchResponse> UndoMatchAsync(DemoConnector.TwinfieldMatchingService.Header Header, string office, string dimensionType, string dimension, int matchNumber) {
            DemoConnector.TwinfieldMatchingService.UndoMatchRequest inValue = new DemoConnector.TwinfieldMatchingService.UndoMatchRequest();
            inValue.Header = Header;
            inValue.office = office;
            inValue.dimensionType = dimensionType;
            inValue.dimension = dimension;
            inValue.matchNumber = matchNumber;
            return ((DemoConnector.TwinfieldMatchingService.MatchingSoap)(this)).UndoMatchAsync(inValue);
        }
    }
}