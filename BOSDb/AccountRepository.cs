using BankOfSuccess.Entities;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankOfSuccess.BOSDb
{
    public class AccountRepository:Account 
    {
        
        
        public static void SaveAccount(Account account)
        {
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BankOfSuccessDB;Integrated Security=True;Pooling=False";
            conn.Open();
            //  string Sqlinsert = $"insert into account values('{account.AccountNo}','{account.Name}','{account.PIN}','{account.Balance}','{account.Privilge}','{account.IsActive}','{account.ActivationDate}','{account.ClosedDate}','{account.Email}','{account.PhoneNo}')";
            string Sqlinsert = $"insert into account(Name,PIN,Balance,Privilge,IsActive,Email,PhoneNo,AccountNo) values('{account.Name}','{account.PIN}','{account.Balance}',1,'{account.IsActive}','{account.Email}','{account.PhoneNo}','{account.AccountNo}')";

            SqlCommand cmd=new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText= Sqlinsert;
            cmd.ExecuteNonQuery();

            conn.Close();
            
        }
       


    }
}