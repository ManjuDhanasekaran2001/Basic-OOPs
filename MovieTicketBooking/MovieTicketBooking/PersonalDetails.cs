using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Namespace which contains Movie Ticket Booking Application
/// </summary>
namespace MovieTicketBooking
{
    /// <summary>
    /// Class <see cref="PersonalDetails"/> contains personal details of user
    /// </summary>
    public class PersonalDetails
    {
        /// <summary>
        /// Property Name contains name of the user of <see cref="PersonalDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string Name { get; set; }

        /// <summary>
        /// Property Age contains age of the user of <see cref="PersonalDetails"/> class's object
        /// </summary>
        /// <value>It requires int value</value>
        public int Age { get; set; }

        /// <summary>
        /// Property PhoneNumber contains phone number of the user of <see cref="PersonalDetails"/> class's object
        /// </summary>
        /// <value>It requires long value</value>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Constructor of the Class <see cref="PersonalDetails"/> used to assign value to properties
        /// </summary>
        /// <param name="name">Parameter name used to assign value to its property</param>
        /// <param name="age">Parameter age used to assign value to its property</param>
        /// <param name="phoneNumber">Parameter phoneNumber used to assign value to its property</param>
        public PersonalDetails(string name,int age,long phoneNumber)
        {
            Name = name;
            Age=age;
            PhoneNumber=phoneNumber;
        }
    }
}