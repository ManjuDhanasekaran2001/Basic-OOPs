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
    /// Enum Booking Status which contains booking status of <see cref="BookingDetails"/> class's object
    /// </summary>
    public enum BookingStatus{Booked,Cancelled}

    /// <summary>
    /// Class <see cref="BookingDetails"/> contains details of booking by user
    /// </summary>
    public class BookingDetails
    {
        /// <summary>
        /// Private static int field which is auto incremented
        /// <see cref="BookingDetails"/> class's object
        /// For further information refer <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_bookingID = 7001;

        /// <summary>
        /// private string field used to store booking ID
        /// </summary>
        private string _bookingID;
        public string BookingID { get{return _bookingID;} }

        /// <summary>
        /// property UserID which contains Id of the user <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string UserID { get; set; }

        /// <summary>
        /// property MovieID which contains Id of the movie <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string MovieID { get; set; }

        /// <summary>
        /// property TheatreID which contains Id of the theatre <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string TheatreID { get; set; }

        /// <summary>
        /// property SeatCount which contains count of seats booked of <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires int value</value>
        public int SeatCount { get; set; }

        /// <summary>
        /// property TotalAmount which contains price of seats booked of <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires double value</value>
        public double TotalAmount { get; set; }

        /// <summary>
        /// property BookingStatus which contains status of booking of <see cref="BookingDetails"/> class's object
        /// </summary>
        /// <value>It requires enum value</value>
        public BookingStatus BookingStatus { get; set; }

        /// <summary>
        /// Constructor of the Class <see cref="BookingDetails"/> used to assign value to properties
        /// </summary>
        /// <param name="userID">Parameter userID used to assign value to its property</param>
        /// <param name="movieID">Parameter movieID used to assign value to its property</param>
        /// <param name="theatreID">Parameter theatreID used to assign value to its property</param>
        /// <param name="seatCount">Parameter seatCount used to assign value to its property</param>
        /// <param name="totalAmount">Parameter totalAmount used to assign value to its property</param>
        /// <param name="bookingStatus">Parameter bookingStatus used to assign value to its property</param>
        public BookingDetails(string userID,string movieID,string theatreID,int seatCount,double totalAmount,BookingStatus bookingStatus)
        {
            _bookingID = "BID"+s_bookingID++;
            UserID = userID;
            MovieID = movieID;
            TheatreID = theatreID;
            SeatCount = seatCount;
            TotalAmount = totalAmount;
            BookingStatus = bookingStatus;
        }

    }
}