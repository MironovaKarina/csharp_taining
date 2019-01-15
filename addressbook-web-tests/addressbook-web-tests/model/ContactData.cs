using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allContent;
        private string allEmails;

        //      public string fi = String.Join(firstname, lastname);

        public ContactData()
        {
        }
        public ContactData(string lastname, string firstname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname==other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode()+Firstname.GetHashCode();
        
        }

        public override string ToString()
        {
            return "lastname= " + Lastname + "firstname= " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Object.ReferenceEquals(other.Lastname, Lastname))
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
            
        }

        [Column(Name = "id"), PrimaryKey]
        public string id { get; set; }

        [Column(Name ="firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        public string contactID { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }

        public string AllContent
        {
            get
            {
                if (allContent != null)
                {
                    return allContent;
                }
                else
                {
                    return (Lastname +' '+  Firstname + "\r\n"  + Address + "\r\n" + "\r\n" + CleanUp(DetailedHomePhone(HomePhone)) + CleanUp(DetailedMobilePhone(MobilePhone)) + CleanUp(DetailedWorkPhone(WorkPhone)) + "\r\n" + AllEmails).Trim();
                }
            }
            set
            {
                allContent = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails !=null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email1 + "\r\n" + Email2 + "\r\n" + Email3 + "\r\n").Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string DetailedHomePhone (string homephone)
        {
            if (homephone == null || homephone == "")
            {
                return "";
            }
            return ("H: " + homephone);
        }


        public string DetailedMobilePhone(string mobilephone)
        {
            if (mobilephone == null || mobilephone == "")
            {
                return "";
            }
            return ("M: " + mobilephone);
        }


        public string DetailedWorkPhone(string workphone)
        {
            if (workphone == null || workphone == "")
            {
                return "";
            }
            return ("W: " + workphone);
        }


        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return Regex.Replace(phone, "[-()]", "") + "\r\n";
        }
    }
}
