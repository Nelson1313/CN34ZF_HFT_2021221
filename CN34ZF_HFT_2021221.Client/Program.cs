using CN34ZF_HFT_2021221.Data;
using CN34ZF_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CN34ZF_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);

            RestService rest = new RestService("http://localhost:56403");
            var res1 = rest.Get<Team>("/team");
        }
    }
}
