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
    /// Class <see cref="TheatreDetails"/> contains details of theatre
    /// </summary>
    public class TheatreDetails
    {
        /// <summary>
        /// Private static int field which is auto incremented
        /// <see cref="TheatreDetails"/> class's object
        /// For further information refer <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_theatreID = 301;
        /// <summary>
        /// private string field used to store theatre ID
        /// </summary>
        private string _theatreID;
        public string TheatreID { get{return _theatreID;} }

        /// <summary>
        /// property TheatreName which contains theatre name of <see cref="TheatreDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string TheatreName { get; set; }
        /// <summary>
        /// property TheatreLocation which contains theatre location of <see cref="TheatreDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string TheatreLocation { get; set; }

        /// <summary>
        /// Constructor of the Class <see cref="TheatreDetails"/> used to assign value to properties
        /// </summary>
        /// <param name="theatreName">Parameter theatreName used to assign value to its property</param>
        /// <param name="theatreLocation">Parameter theatreLocation used to assign value to its property</param>
        public TheatreDetails(string theatreName,string theatreLocation)
        {
            _theatreID = "TID"+s_theatreID++;
            TheatreName = theatreName;
            TheatreLocation = theatreLocation;
        }
    }
}