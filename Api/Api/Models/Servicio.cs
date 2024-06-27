namespace Api.Models
{
    public class Servicio
    {
       public string customerId { get; set; }

       public string firstName { get; set; }

       public string lastName { get; set; }
       public string email { get; set; }

     
       public string phoneHome { get; set; }
       public string phoneMobile { get; set; }

       public string birthday { get; set; }

       public List<Address> addresses { get; set; }
    }





    public class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string addressId { get; set; }
        public string city { get; set; }
        public string companyName { get; set; }
        public string countryCode { get; set; }
        public string creationDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string jobTitle { get; set; }
        public string lastModified { get; set; }
        public string phone { get; set; }
        public string postalCode { get; set; }
        public string postBox { get; set; }
        public bool preferred { get; set; }
        public string salutation { get; set; }
        public string secondName { get; set; }
        public string stateCode { get; set; }
        public string suite { get; set; }
        public string title { get; set; }
        
        /*
        public string Nombre  { get; set; }
        public string Email  { get; set; }
        public string Teléfono{ get; set; }
        public string Direcciones { get; set; }  */

    }
}
