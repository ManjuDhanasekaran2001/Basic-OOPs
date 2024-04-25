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
    /// Class <see cref="MovieDetails"/> contains details of movies
    /// </summary>
    public class MovieDetails
    {
        /// <summary>
        /// Private static int field which is auto incremented
        /// <see cref="MovieDetails"/> class's object
        /// For further information refer <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_movieID = 501;
        /// <summary>
        /// private string field used to store movie ID
        /// </summary>
        private string _movieID;
        public string MovieID { get{return _movieID;} }
        /// <summary>
        /// property MovieName which contains movie name of <see cref="MovieDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string MovieName { get; set; }
        /// <summary>
        /// property Language which contains language of movie of <see cref="MovieDetails"/> class's object
        /// </summary>
        /// <value>It requires string value</value>
        public string Language { get; set; }

        /// <summary>
        /// Constructor of the Class <see cref="MovieDetails"/> used to assign value to properties
        /// </summary>
        /// <param name="movieName">Parameter movieName used to assign value to its property</param>
        /// <param name="language">Parameter language used to assign value to its property</param>
        public MovieDetails(string movieName,string language)
        {
            _movieID = "MID"+s_movieID++;
            MovieName = movieName;
            Language = language;
        }
    }
}