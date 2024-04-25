using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Namespace which contains Movie Ticket Booking Application
/// </summary
namespace MovieTicketBooking
{
    /// <summary>
    /// Interface IWallet
    /// </summary>
    public interface IWallet
    {
        /// <summary>
        /// Property WalletBalance used to get wallet balance of user as it is inherited
        /// </summary>
        /// <value></value>
        public double WalletBalance { get;  }
        /// <summary>
        /// Abstract method Wallet Recharge
        /// </summary>
        /// <param name="amount">It requires double value as a paramater while inheriting </param>   
        void WalletRecharge(double amount);
    }
}