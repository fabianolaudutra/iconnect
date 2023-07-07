using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class BancoService
    {
        public static string senhaBancoOffline = "1c0nn3ct.0ffl1n3@@)!(";

        public static string getConnection(string ambiente)
        {
            if (ambiente.Equals("P"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnect;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else if (ambiente.Equals("H"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnectAngular;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else if (ambiente.Equals("D"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnect_Desenvolvimento;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else
            {
                return "Data Source=(LocalDB)\\MSSQLLocalDB;initial catalog=dbIconnect;user id=iconnect.offline;password=" + senhaBancoOffline + ";MultipleActiveResultSets=True";
                //return "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true";
            }
        }

        public static string getConnectionSincronizacao(string ambiente)
        {
            if (ambiente.Equals("P"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnect;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else if (ambiente.Equals("H"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnectAngular;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else if (ambiente.Equals("D"))
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnect_Desenvolvimento;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
            else
            {
                return "Data Source=35.199.101.9;Initial Catalog=dbIconnectAngular;User ID=iconnect;Password=FGHr$!56;Max Pool Size=500";
            }
        }

        public static string getDbName(string ambiente)
        {

            if (ambiente.Equals("P"))
            {
                return "dbIconnect";
            }
            else if (ambiente.Equals("H"))
            {
                return "dbIconnectAngular";
            }
            else if (ambiente.Equals("D"))
            {
                return "dbIconnect_Desenvolvimento";
            }
            else
            {
                return "dbIconnect";
            }
        }

        public static string getDbNameSincronizacao(string ambiente)
        {
            if (ambiente.Equals("P"))
            {
                return "dbIconnect";
            }
            else if (ambiente.Equals("H"))
            {
                return "dbIconnectAngular";
            }
            else if (ambiente.Equals("D"))
            {
                return "dbIconnect_Desenvolvimento";
            }
            else
            {
                return "dbIconnectAngular";
            }
        }
    }
}
