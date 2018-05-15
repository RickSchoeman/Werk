//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace DemoConnector
//{
//    public class ImplementationContract : Asterisk.AsteriskImplementation
//    {
//        public override string Name
//        {
//            get { return "Twinfield"; }
//        }
//
//        public override Resources.Localizer Localizer
//        {
//            get { throw new NotImplementedException(); }
//        
//        }
//
//        public Type GetConnectorType(string name)
//        {
//            if (name == "TwinfieldAPI")
//            {
//                return typeof(TwinfieldAPI.TwinfieldApiConnector);
//            }
//
//            var ct = typeof(TwinfieldAPI.TwinfieldApiConnector);
//            var ctors = ct.GetConstructors();
//            var ctor = ctors[0];
//            var ctorParams = ctor.GetParameters();
//            throw new NotImplementedException();
//        }
//    }
//}
