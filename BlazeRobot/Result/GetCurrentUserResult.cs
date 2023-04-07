using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public class GetCurrentUserResult : BaseResult
    {
        public CurrentUserModel CurrentUser { get; set; }

        public partial class CurrentUserModel
        {
            public long Id { get; set; }
            public string Username { get; set; }
            public Uri AvatarUrl { get; set; }
            public string Email { get; set; }
            public bool EmailConfirmed { get; set; }
            public string Language { get; set; }
            public string Locale { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTimeOffset DateOfBirth { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string KycCountry { get; set; }
            public string PostalCode { get; set; }
            public string[] Roles { get; set; }
            public bool PaymentEmails { get; set; }
            public bool MarketingEmails { get; set; }
            public bool GeneralEmails { get; set; }
            public bool SmsCommunications { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public DateTimeOffset CreatedAt { get; set; }
            public bool IsSuspended { get; set; }
            public object[] Permissions { get; set; }
            public bool InitialProfileComplete { get; set; }
            public string TaxId { get; set; }
            public string[] LockedPersonalInfoFields { get; set; }
            public bool UsernameChangeRequired { get; set; }
        }
    }
}
