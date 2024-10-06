using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.UserProfile
{
    public class BasicInfo
    {
        private BasicInfo()
        { 
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public string PhoneNumber { get; private set; }
        public BasicInfo Basic_Info { get; private set; }    
      
        public static BasicInfo CreateBasicInfo(string firstName, string lastName, string userName, DateTime dateOfBirth, string email,
                                                string phoneNumber)
        {
            var basicInfo = new BasicInfo
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                DateOfBirth = dateOfBirth,
                Email = email,
                IsEmailVerified = false,
                PhoneNumber = phoneNumber,

            };

            return basicInfo;
        
        }


        public void UpdateBasicInfo(BasicInfo newInfo)
        {
            Basic_Info = newInfo;
        }

    }
}
