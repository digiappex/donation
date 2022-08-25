using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace donationProjectDLL.Domains
{
    public class city
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityId { get; set; }
        public string cityName { get; set; }
        public virtual ICollection<cityArea> CityAreas { get; set; }
    }
    public class cityArea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int areaId { get; set; }
        public city City { get; set; }
        public string areaName { get; set; }
        public virtual ICollection<userRecord> UserRecords { get; set; }
        public virtual ICollection<organizationData> OrganizationData { get; set; }
    }
    public class userType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string typeName { get; set; }
        public virtual ICollection<userRecord> UserRecords { get; set; }

    }
    public class userRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userRecordId { get; set; }
        public Guid userGuid { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userCNIC { get; set; }
        public string familyNumber { get; set; }
        public string userAddress { get; set; }
        public string userAddressPerCNIC { get; set; }
        public string emailAddress { get; set; }
        public int cityId { get; set; }
        public cityArea areaId { get; set; }
        public bool isActive { get; set; }
        public userType UserType { get; set; }
        public screenNameRecord ScreenNameRecord { get; set; }
        public familyMembersRecord FamilyMembersRecord { get; set; }
        public cnicPicRecord CnicPicRecord { get; set; }
    }
    public class screenNameRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int screenNameRecordId { get; set; }
        public Guid userGuid { get; set; }
        public string username { get; set; }
        public string userPassword { get; set; }
        public int userRecordId { get; set; }
        public bool isActive { get; set; }
        public userRecord UserRecord { get; set; }
    }
    public class familyMembersRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int familyMembersRecordId { get; set; }
        public int userRecordId { get; set; }
        public string numberOfFamilyMembers { get; set; }
        public userRecord UserRecord { get; set; }
    }
    public class cnicPicRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cnicPicRecordId { get; set; }
        public int userRecordId { get; set; }
        public Guid userGuid { get; set; }
        public string cnicFrontPicPath { get; set; }
        public string cnicBackPicPath { get; set; }
        public userRecord UserRecord { get; set; }
    }

    public class organizationData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int organizationId { get; set; }
        public string licenseNumber { get; set; }
        public Guid userGuid { get; set; }
        public string organizationName { get; set; }
        public string aboutOrganization { get; set; }
        public string organizationAddress { get; set; }
        public bool isActive { get; set; }
        public cityArea areaId { get; set; }
        public int cityId { get; set; }
    }
    public class itemCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemCategoryId { get; set; }
        public string itemCategoryName { get; set; }
        public virtual ICollection<itemDetails> ItemDetails { get; set; }
    }
    public class itemDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemDetailId { get; set; }
        public itemCategory itemCategory { get; set; }
        public int ownerId { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string ammount { get; set; }
    }
    public class moneyDonation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int moneyDonationId { get; set; }
        public DateTime donationDate { get; set; }
        public int donationId { get; set; }
        public int receiverId { get; set; }
        public string ammount { get; set; }
    }

    public class itemDonation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemDonationId { get; set; }
        public DateTime donationDate { get; set; }
        public int donationId { get; set; }
        public int receiverId { get; set; }
        public int itemId { get; set; }
        public string ammount { get; set; }


    }

}