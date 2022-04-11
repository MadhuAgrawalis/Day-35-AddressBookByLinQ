using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Day_35AddressBook
{
    public class Management
    {
        //UC-1-Create datatable 
        public static DataTable BookTable = new DataTable();
        public static void AddTable()
        {
            DataColumn column;
            DataRow Row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FirstName";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LastName";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Address";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "City";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "State";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Zip";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PhoneNumber";
            BookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "eMail";
            BookTable.Columns.Add(column);

            // Make the first name and mobile no column the primary key column
            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = BookTable.Columns["FirstName"];
            PrimaryKeyColumns[1] = BookTable.Columns["PhoneNumber"];
            BookTable.PrimaryKey = PrimaryKeyColumns;

            //Creating rows and adding data into rows - UC3
            BookTable.Rows.Add("Kim", "Kardashian", "Street 1", "Lakers", "Los Angeles", 444556, 6785674567, "lb@gmail.com");
            BookTable.Rows.Add("Kylie", "Jenner", "Street 3", "Celtics", "Boston", 345267, 2345678987, "kylie@gmail.com");
            BookTable.Rows.Add("Kris", "Jenner", "Block 4", "Warriors", "Golden State", 987654, 3456787654, "kris@gmail.com");
            BookTable.Rows.Add("Khloe", "Lamar", "Street 5", "Rockets", "Houston", 234566, 6543456789, "khloe@gmail.com");
            BookTable.Rows.Add("Kourtney", "Scott", "Block 2", "Hornets ", "Charlotte ", 444556, 3456787654, "ks@gmail.com");

            //UC4

            AddressBookManagement addressBookManagement = new AddressBookManagement();
            BookTable = addressBookManagement.UpdatedContactDetails(BookTable);

            Console.WriteLine("\n*******************DATA*****************\n");
            foreach (var data in BookTable.AsEnumerable())
            {
                Console.WriteLine("FirstName:- " + data.Field<string>("firstName"));
                Console.WriteLine("lastName:- " + data.Field<string>("lastName"));
                Console.WriteLine("Address:- " + data.Field<string>("address"));
                Console.WriteLine("City:- " + data.Field<string>("city"));
                Console.WriteLine("State:- " + data.Field<string>("state"));
                Console.WriteLine("zip:- " + Convert.ToInt32(data.Field<Double>("zip")));
                Console.WriteLine("phoneNumber:- " + Convert.ToDouble(data.Field<Double>("phoneNumber")));
                Console.WriteLine("eMail:- " + data.Field<string>("eMail"));
                Console.WriteLine("\n***************\n");
            }
            //UC5

            AddressBookManagement addressBookManagement1 = new AddressBookManagement();
            BookTable = addressBookManagement1.DeletingContactFromTable(BookTable);
            //UC - 6
            AddressBookManagement addressBookManagement2 = new AddressBookManagement();
            addressBookManagement.RetrievingContactDetailsByStateOrCity(BookTable);
            //UC-7
            addressBookManagement.GetCountByCityAndState(BookTable);
            //UC8
            addressBookManagement.GetSortedDataBasedOnPersonName(BookTable);
            //UC9
            //listing all the firstnames from addressbook
            var book = BookTable.AsEnumerable().Select(r => r.Field<string>("firstName"));
            foreach (string element in book)
            {
                Console.WriteLine(element);
            }
        }
    }
}