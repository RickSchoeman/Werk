using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Middleware
{
    class PostalAddresses
    {

    }

    public class Country
    {
        public String Name { get; set; }
        public String Code { get; set; }

    }

    public class PostalAddress
    {
        private Country _country;
        public PostalAddress()
        {
            _country = Country;
        }
        public String Contactpersoon { get; set; }
        public String StreetWithHouseNumber { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Address3 { get; set; }
        public String ZipCode { get; set; }
        public String City { get; set; }
        public Country Country
        {
            get { return _country; }
        }
        public String HouseNumber { get; set; }

        public Boolean IsEmpty
        {
            get {
                if (!String.IsNullOrWhiteSpace(Contactpersoon))
                {
                    return false;
                }

                if (!String.IsNullOrWhiteSpace(Address1))
                {
                    return false;
                }

                if (!String.IsNullOrWhiteSpace(ZipCode))
                {
                    return false;
                }

                if (!String.IsNullOrWhiteSpace(City))
                {
                    return false;
                }

                if (!String.IsNullOrWhiteSpace(HouseNumber))
                {
                    return false;
                }

                if (!String.IsNullOrWhiteSpace(Country.Code))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
