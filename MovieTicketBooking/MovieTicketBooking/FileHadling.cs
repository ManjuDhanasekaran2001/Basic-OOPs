using System;
using System.IO;

namespace MovieTicketBooking
{
    public  class FileHadling
    {
        public static void Create()
        {
            if(!Directory.Exists("MovieTicketBooking"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("MovieTicketBooking");
            }

            if(!File.Exists("MovieTicketBooking/BookingInfo.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MovieTicketBooking/BookingInfo.csv").Close();
            }

            if(!File.Exists("MovieTicketBooking/MovieInfo.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MovieTicketBooking/MovieInfo.csv").Close();
            }

            if(!File.Exists("MovieTicketBooking/ScreeningInfo.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MovieTicketBooking/ScreeningInfo.csv").Close();
            }

            if(!File.Exists("MovieTicketBooking/TheatreInfo.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MovieTicketBooking/TheatreInfo.csv").Close();
            }

            if(!File.Exists("MovieTicketBooking/PersonalInfo.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("MovieTicketBooking/PersonalInfo.csv").Close();
            }   

        }

        public static void WriteToCSV()
        {
            string [] users = new string[Program.userDetailsList.Count];
            for(int i =0; i<Program.userDetailsList.Count;i++){
                users[i]=$"{Program.userDetailsList[i].WalletBalance},{Program.userDetailsList[i].Name},{Program.userDetailsList[i].Age},{Program.userDetailsList[i].PhoneNumber}";
            }
            File.WriteAllLines("MovieTicketBooking/PersonalInfo.csv",users);


            string [] movies = new string[Program.movieDetailsList.Count];
            for(int i =0; i<Program.movieDetailsList.Count;i++){
                movies[i]=$"{Program.movieDetailsList[i].MovieID},{Program.movieDetailsList[i].MovieName},{Program.movieDetailsList[i].Language}";
            }
            File.WriteAllLines("MovieTicketBooking/MovieInfo.csv",movies);

             string [] theaters = new string[Program.theatreDetailsList.Count];
            for(int i =0; i<Program.theatreDetailsList.Count;i++){
                theaters[i]=$"{Program.theatreDetailsList[i].TheatreID},{Program.theatreDetailsList[i].TheatreName},{Program.theatreDetailsList[i].TheatreID}";
            }
            File.WriteAllLines("MovieTicketBooking/TheatreInfo.csv",theaters);

            string [] screen = new string[Program.screeningDetailsList.Count];
            for(int i =0; i<Program.screeningDetailsList.Count;i++){
                
            }
            File.WriteAllLines("MovieTicketBooking/ScreeningInfo.csv",screen);

            
        }
    }
}
