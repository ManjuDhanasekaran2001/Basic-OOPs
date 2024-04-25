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
    /// Class <see cref="ScreeningDetails"/> contains details of screening
    /// </summary>
    public class ScreeningDetails
    {
        /// <summary>
        /// property Movie ID which contains Id of the movie <see cref="ScreeningDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string MovieID { get; set; }

        /// <summary>
        /// property Theatre ID which contains Id of the theatre <see cref="ScreeningDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string TheatreID { get; set; }

        /// <summary>
        /// property NoOfSeats which contains number of seats available of <see cref="ScreeningDetails"/> class's object
        /// </summary>
        /// <value>It requires int value</value>
        public int NoOfSeats { get; set; }

        /// <summary>
        /// property TicketPrice which contains price of ticket of <see cref="ScreeningDetails"/> class's object
        /// </summary>
        /// <value>It requires double value</value>
        public double TicketPrice { get; set; }

        /// <summary>
        /// Constructor of the Class <see cref="ScreeningDetails"/> used to assign value to properties
        /// </summary>
        /// <param name="movieID">Parameter movieID is used to assign value to its property</param>
        /// <param name="theatreID">Parameter theatreID is used to assign value to its property</param>
        /// <param name="ticketPrice">Parameter ticketPrice is used to assign value to its property</param>
        /// <param name="noOfSeats">Parameter noOfSeats is used to assign value to its property</param>
        public ScreeningDetails(string movieID,string theatreID,double ticketPrice,int noOfSeats)
        {
            MovieID = movieID;
            TheatreID = theatreID;
            NoOfSeats = noOfSeats;
            TicketPrice = ticketPrice;
        }
    }
}