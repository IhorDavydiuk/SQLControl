using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDB
{
    public class DatabaseOperation
    {
        SqlConnection sqlCon = null;
        public DatabaseOperation(string connectionStr)
        {
            sqlCon = new SqlConnection(connectionStr);
        }
        public void CreateTable(string nameTable, string nameColumn, string nameType)
        {
            sqlCon.Open();
            string strCommand = String.Format($"CREATE TABLE {nameTable} (ID INT IDENTITY PRIMARY KEY,{nameColumn} {nameType})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void CreateTable(string nameTable, string nameColumn, string nameType, string nameColumn1, string nameType1)
        {
            sqlCon.Open();
            string strCommand = String.Format($"CREATE TABLE {nameTable} (ID INT IDENTITY PRIMARY KEY,{nameColumn} {nameType},{nameColumn1} {nameType1})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void CreateTable(string nameTable, string nameColumn, string nameType, string nameColumn1, string nameType1, string nameColumn2, string nameType2)
        {
            sqlCon.Open();
            string strCommand = String.Format($"CREATE TABLE {nameTable} (ID INT IDENTITY PRIMARY KEY,{nameColumn} {nameType},{nameColumn1} {nameType1},{nameColumn2} {nameType2})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void CreateTable(string nameTable, string nameColumn, string nameType, string nameColumn1, string nameType1, string nameColumn2, string nameType2, string nameColumn3, string nameType3)
        {
            sqlCon.Open();
            string strCommand = String.Format($"CREATE TABLE {nameTable} (ID INT IDENTITY PRIMARY KEY,{nameColumn} {nameType},{nameColumn1} {nameType1},{nameColumn2} {nameType2},{nameColumn3} {nameType3})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void CreateTable(string nameTable, string nameColumn, string nameType, string nameColumn1, string nameType1, string nameColumn2, string nameType2, string nameColumn3, string nameType3, string nameColumn4, string nameType4)
        {
            sqlCon.Open();
            string strCommand = String.Format($"CREATE TABLE {nameTable} (ID INT IDENTITY PRIMARY KEY,{nameColumn} {nameType},{nameColumn1} {nameType1},{nameColumn2} {nameType2},{nameColumn3} {nameType3},{nameColumn4} {nameType4})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Insert(string nameTable, object nameStr0)
        {
            sqlCon.Open();
            string strCommand = String.Format($"INSERT INTO {nameTable} VALUES ('{nameStr0.ToString()}')");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Insert(string nameTable, object nameStr0, object nameStr1)
        {
            sqlCon.Open();
            string strCommand = String.Format($"INSERT INTO {nameTable} VALUES ({nameStr0},{nameStr1})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Insert(string nameTable, object nameStr0, object nameStr1, object nameStr2)
        {
            sqlCon.Open();
            string strCommand = String.Format($"INSERT INTO {nameTable} VALUES ({nameStr0},{nameStr1},{nameStr2})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Insert(string nameTable, object nameStr0, object nameStr1, object nameStr2, object nameStr3)
        {
            sqlCon.Open();
            string strCommand = String.Format($"INSERT INTO {nameTable} VALUES ({nameStr0},{nameStr1},{nameStr2},{nameStr3})");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Insert(string nameTable, object nameStr0, object nameStr1, object nameStr2, object nameStr3, object nameStr4, object nameStr5)
        {
            sqlCon.Open();
            string strCommand = String.Format($"INSERT INTO {nameTable} VALUES ({nameStr0},{nameStr1},{nameStr2},{nameStr3},{nameStr4},{nameStr5}),");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Delete(string nameTable, string whereColum, string whereID)
        {
            sqlCon.Open();
            string strCommand = String.Format($"DELETE FROM {nameTable} WHERE {whereColum} = {whereID}");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void Update(string nameTable, string setColum, object setItem, string whereColum, object whereID)
        {

            sqlCon.Open();
            string strCommand = String.Format($"UPDATE {nameTable} SET {setColum} = {setItem} WHERE {whereColum} = {whereID}");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            dbCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void SelectColumn(string nameTable, string nameColumn)
        {
            sqlCon.Open();
            string strCommand = String.Format($"SELECT {nameColumn} FROM {nameTable} WHERE IsReturn = '0';");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            using (var reder = dbCommand.ExecuteReader())
            {
                if (reder.HasRows)
                {
                    while (reder.Read())
                    {
                        Console.WriteLine($"{reder.GetName(0)} -> {reder.GetValue(0)}");
                    }
                }
            }
            sqlCon.Close();
        }
        public void SelectStrange(string nameTable, string nameColum, string nameItem)
        {
            sqlCon.Open();
            string strCommand = String.Format($"SELECT * FROM {nameTable} WHERE {nameColum} = {nameItem};");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            using (var reder = dbCommand.ExecuteReader())
            {
                if (reder.HasRows)
                {
                    while (reder.Read())
                    {
                        for (int i = 0; i < reder.FieldCount; i++)
                        {
                            Console.WriteLine($"{reder.GetName(i)} = {reder.GetValue(i)}");
                        }
                       
                    }
                }
            }
            sqlCon.Close();
        }
        public List<string> SaveTableToList(string nameTable)
        {
            List<string> LBooks = new List<string>();
            sqlCon.Open();
            string strCommand = String.Format($"SELECT * FROM {nameTable}");
            var dbCommand = new SqlCommand(strCommand, this.sqlCon);
            using (var reder = dbCommand.ExecuteReader())
            {

                for (int i = 0; i < reder.FieldCount; i++)
                {
                    LBooks.Add(reder.GetName(i).ToString() + ",");
                }
                LBooks.Add(";");
                if (reder.HasRows)
                {
                    while (reder.Read())
                    {
                        for (int i = 0; i < reder.FieldCount; i++)
                        {
                            LBooks.Add(reder.GetValue(i).ToString() + ",");
                        }
                        LBooks.Add(";");
                    }
                }

            }
            sqlCon.Close();
            return LBooks;
        }
    }
}
