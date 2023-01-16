using Microsoft.Web.Services3;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
  public class MOCICompany
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        #region Committed Code
        /*
        public class Activities
        {
            public List<Activity> activity { get; set; }
        }

        public class Activity
        {
            public string isicCode { get; set; }
            public string isicVersion { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string registrationDate { get; set; }
            public string subjectToLicensing { get; set; }
            public string licenseObtained { get; set; }
        }

        public class Address
        {
            public Town town { get; set; }
            public State state { get; set; }
            public Governorate governorate { get; set; }
            public string wayNumber { get; set; }
            public string buildingNumber { get; set; }
            public string postalCode { get; set; }
            public string poBox { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class BusinessLocation
        {
            public Town town { get; set; }
            public State state { get; set; }
            public Governorate governorate { get; set; }
            public string streetNameAr { get; set; }
            public string streetNameEn { get; set; }
            public string buildingNumber { get; set; }
            public string postalCode { get; set; }
            public string poBox { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string wayNumber { get; set; }
        }

        public class Capital
        {
            public string cashCapital { get; set; }
            public string assetCapital { get; set; }
            public string totalCapital { get; set; }
            public string shareValue { get; set; }
            public string totalShares { get; set; }
            public string capitalVerified { get; set; }
        }

        public class CompanyOverview
        {
            public string crNumber { get; set; }
            public string companyNameArabic { get; set; }
            public string companyNameWithLegalArabic { get; set; }
            public Country country { get; set; }
            public LegalStatus legalStatus { get; set; }
            public RegistrationStatus registrationStatus { get; set; }
            public string registrationDate { get; set; }
            public string establishmentDate { get; set; }
            public string subjectToForeignInvestment { get; set; }
            public string expiryDate { get; set; }
            public string isExpired { get; set; }
            public Address address { get; set; }
            public Contact contact { get; set; }
            public Capital capital { get; set; }
            public Fiscal fiscal { get; set; }
            public DeclaredActivities declaredActivities { get; set; }
            public PlacesOfActivities placesOfActivities { get; set; }
            public Investors investors { get; set; }
            public Signatories signatories { get; set; }
            public object auditors { get; set; }
            public object mortgages { get; set; }
        }

        public class Contact
        {
            public string email { get; set; }
            public string mobile { get; set; }
        }

        public class Country
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class DeclaredActivities
        {
            public List<Activity> activity { get; set; }
        }

        public class Designation
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class Fiscal
        {
            public string firstFiscalYearEnd { get; set; }
            public string fiscalYearEndDay { get; set; }
            public string fiscalYearEndMonth { get; set; }
        }

        public class Governorate
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string specialZone { get; set; }
        }

        public class Investor
        {
            public string isEstablishment { get; set; }
            public Designation designation { get; set; }
            public string numberOfShares { get; set; }
            public string registrationDate { get; set; }
            public Person person { get; set; }
        }

        public class Investors
        {
            public Investor investor { get; set; }
        }

        public class IssueCountry
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class LegalStatus
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class Nationality
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class Passport
        {
            public string number { get; set; }
            public IssueCountry issueCountry { get; set; }
            public string issueDate { get; set; }
        }

        public class Person
        {
            public string idNumber { get; set; }
            public Passport passport { get; set; }
            public string dateOfBirth { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string gender { get; set; }
            public Nationality nationality { get; set; }
        }

        public class PlaceOfActivity
        {
            public string poaCode { get; set; }
            public BusinessLocation businessLocation { get; set; }
            public Activities activities { get; set; }
        }

        public class PlacesOfActivities
        {
            public List<PlaceOfActivity> placeOfActivity { get; set; }
        }

        public class RegistrationStatus
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class Root
        {
            public WsResponseBody wsResponseBody { get; set; }
        }

        public class Signatories
        {
            public List<Signatory> signatory { get; set; }
        }

        public class Signatory
        {
            public string idNumber { get; set; }
            public Passport passport { get; set; }
            public string dateOfBirth { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string gender { get; set; }
            public Nationality nationality { get; set; }
            public Designation designation { get; set; }
            public string hasFullAuthority { get; set; }
            public string hasTechnicalAuthority { get; set; }
            public string hasFinancialAuthority { get; set; }
            public string hasAdministrativeAuthority { get; set; }
            public SignatureType signatureType { get; set; }
            public string signatoryStartDate { get; set; }
        }

        public class SignatureType
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
        }

        public class State
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string specialZone { get; set; }
        }

        public class Town
        {
            public string code { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string specialZone { get; set; }
        }

        public class WsResponseBody
        {
            public CompanyOverview companyOverview { get; set; }
        }
        */

        #endregion

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Activity
        {
            public string isicCode { get; set; }
            public string isicVersion { get; set; }
            public string nameAr { get; set; }
            public string nameEn { get; set; }
            public string registrationDate { get; set; }
        }

        public class CompanyOverview
        {
            public string crNumber { get; set; }
            public string companyNameArabic { get; set; }
            public string companyNameWithLegalArabic { get; set; }
            public string registrationDate { get; set; }
            public string establishmentDate { get; set; }
            public string subjectToForeignInvestment { get; set; }
            public string expiryDate { get; set; }
            public string isExpired { get; set; }
            public DeclaredActivities declaredActivities { get; set; }
        }

        public class DeclaredActivities
        {
            public List<Activity> activity { get; set; }
        }

        public class Root
        {
            public CompanyOverview companyOverview { get; set; }
        }


    }
}
