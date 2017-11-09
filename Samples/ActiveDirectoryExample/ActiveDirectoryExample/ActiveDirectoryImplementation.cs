using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.DirectoryServices;

namespace ActiveDirectoryExample
{
    public class ActiveDirectoryImplementation : IHRSystem
    {
        //TODO: Inset you own Path
        private const string LDAP_SEARCH_PATH = "LDAP://OU=Users,OU=Howdy,DC=wlb,DC=local";
        public async Task<JArray> GetAllHowdyUsersAsync()
        {
            DirectoryEntry ldapConnection = CreateLdapConnection();

            DirectorySearcher search = new DirectorySearcher(ldapConnection);
            search.Filter = "(objectclass=person)";


            var allEmployees = search.FindAll();

            if (allEmployees != null && allEmployees.Count > 0)
            {
                var howdyPayload = ExtractHowdyData(allEmployees);

                return await Task.FromResult(howdyPayload);
            }
            else
            {
                return null;
            }


        }


        DirectoryEntry CreateLdapConnection()
        {
            var ldapConnection = new DirectoryEntry();
            ldapConnection.Path = LDAP_SEARCH_PATH;
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapConnection;
        }


        private JArray ExtractHowdyData(SearchResultCollection allEmployees)
        {
            return new JArray(from SearchResult employee in allEmployees
                              select new JObject(
                                  //INFO: Use a unique ID that never changes. This is used to uniquely identify an employee. userPrincipalName could alo be used
                                  new JProperty("EmployeeID", GetPropertyValue(employee, "objectGUID")),
                                  new JProperty("Firstname", GetPropertyValue(employee, "givenName")),
                                  new JProperty("Lastname", GetPropertyValue(employee, "sn")),
                                  new JProperty("Email", GetPropertyValue(employee, "mail")),
                                  new JProperty("Phonenumber", GetPropertyValue(employee, "telephoneNumber")),
                                  new JProperty("JobTitle", GetPropertyValue(employee, "title")),
                                  new JProperty("Department", GetPropertyValue(employee, "department"))
                                  //INFO: Add more properties here
                                  //new JProperty("", GetPropertyValue(employee, ""))


                                  ));


        }

        private object GetPropertyValue(SearchResult employee, string property)
        {
            if (employee.Properties.Contains(property) && employee.Properties[property].Count > 0)
            {
                var rawData = employee.Properties[property][0];
                if (rawData == null) return null;

                if (rawData is byte[])
                {
                    return new Guid((byte[])rawData).ToString("N");
                }
                else
                {
                    return rawData;
                }
            }
            return null;
        }
    }
}
