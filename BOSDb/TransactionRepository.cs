using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankOfSuccess.Entities;

namespace BankOfSuccess.BOSDb
{
    internal class TransactionRepository : Transaction
    {

        public static void SaveTransaction(Transaction transaction)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BankOfSuccessDB;Integrated Security=True;Pooling=False";
            conn.Open();
           
            string Sqlinsert = $"insert into transaction(TransactionType,SenderAccount,ReceiverAccount,Amount,Mode) values('{transaction.TransactionType}','{transaction.SenderAccount}','{transaction.ReceiverAccount}','{transaction.Amount}',{transaction.Mode})";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sqlinsert;
            cmd.ExecuteNonQuery();

            conn.Close();

        }



    }
}
