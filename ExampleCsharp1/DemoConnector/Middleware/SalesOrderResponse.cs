using System;

namespace DemoConnector.Middleware
{
    class SalesOrderResponse
    {
        private String _customerCode;

        public String CustomerCode
        {
            get
            {
                if (_customer == null)
                {
                    return _customerCode;
                }

                return _customer.Code;
            }
            set
            {
                _customerCode = value;
                if (_customer == null)
                {
                    return;
                }

                _customer.Code = value;
            }
        }

        private CustomerResponse _customer;

        public CustomerResponse Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                if (value == null && _customer != null)
                {
                    _customerCode = _customer.Code;
                }

                _customer = value;
            }
        }
        public ExtensionValue SalesUserReference { get; set; }

        public Boolean HasCustomer
        {
            get { return _customer == null; }
        }
    }
}
