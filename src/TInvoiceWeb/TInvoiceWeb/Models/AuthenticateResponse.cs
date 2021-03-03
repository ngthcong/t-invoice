using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Common;
using TInvoiceWeb.Data;


namespace TInvoiceWeb.Models
{
    public class AuthenticateResponse
    {

        public int Id { get; set; }
        public int Level { get; set; }
        public bool Remember { get; set; }
        public string ExpireDate { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(int id, int level,int time, bool remember, string token)
        {
            Id = id;
            Level = level;
            ExpireDate = DateTime.Now.AddSeconds(time).ToString(Constants.DATETIME_FORMAT_DMYH);
            Remember = remember;
            Token = token;
        }
    }
}
