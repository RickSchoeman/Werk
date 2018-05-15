using System;
using System.Collections.Generic;

namespace DemoConnector.Middleware
{
    public class PostalAddresses
    {
        public PostalAddresses()
        {
            General = new PostalAddress();
            Correspondence = new PostalAddress();
        }

        public PostalAddress General { get; set; }
        public PostalAddress Correspondence { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class PostalAddress
    {
        private Country _country;
        public PostalAddress()
        {
            _country = new Country();
        }

        public string ContactPerson { get; set; }

        //TASK: Roel:        voor voegsel en dergelijke regelen.





        public string StreetWithHouseNumber { get; set; }



        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        /// <summary>
        /// Land
        /// </summary>
        public Country Country { get { return _country; } }
        public string HouseNumber { get; set; }



        public bool IsEmpty
        {
            get
            {
                //todo: uitbreiden

                if (!string.IsNullOrWhiteSpace(ContactPerson))
                    return false;

                if (!string.IsNullOrWhiteSpace(Address1))
                    return false;

                if (!string.IsNullOrWhiteSpace(ZipCode))
                    return false;

                if (!string.IsNullOrWhiteSpace(City))
                    return false;

                if (!string.IsNullOrWhiteSpace(HouseNumber))
                    return false;

                if (!string.IsNullOrWhiteSpace(Country.Code))
                    return false;

                return true;
            }
        }
    }
}
