﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    class DBqueries
    {
        

        internal string checkUserCredentials = "SELECT DISTINCT User_Login, User_Password, userRoleID FROM s2016_user1.users WHERE User_Login = @Login";

        internal string getAllCustomers = "SELECT customer_ID AS ID, firstName AS `First Name`, lastName AS `Last Name`, address AS `Address`, phoneNumber AS `Phone Number`, city AS City, province AS Province, postalCode AS `Postal Code` FROM s2016_user1.customers";
        internal string addCustomer = "INSERT INTO s2016_user1.customers(firstName, lastName, address, phoneNumber,city,province,postalCode) VALUES(@fName,@lName,@address,@phNumber,@city,@province,@postalCode)";
        internal string getCustomerInfo = "SELECT firstName, lastName, address, phoneNumber, city, province, postalCode FROM s2016_user1.customers WHERE customer_ID=@customerID";
        internal string updateCustomerInfo = "UPDATE s2016_user1.customers SET firstName=@fName, lastName=@lName, address=@address, phoneNumber=@phNumber, city=@city,province=@province,postalCode=@postalCode WHERE customer_ID=@customerID";
        internal string deleteCustomer = "DELETE FROM s2016_user1.customers WHERE customer_ID=@customerID";

        internal string getAllUsers = "SELECT UserID AS `User ID`, User_Login AS `Login`, User_FName AS `First Name`, User_LName AS `Last Name`, roleName AS `Group` FROM s2016_user1.users AS US INNER JOIN s2016_user1.userRole AS UR ON US.userRoleID = UR.userRoleID";
        internal string addUser = "INSERT INTO s2016_user1.users(User_Login,User_FName,User_LName,User_Password,userRoleID) VALUES(@login,@fName,@lName,@pass,@roleID)";
        internal string updateUser = "UPDATE s2016_user1.users SET User_Login=@login, User_FName=@fName, User_LName=@lName, userRoleID=@roleID WHERE UserID=@userID";
        internal string updateUserPass = "UPDATE s2016_user1.users SET User_Password=@pass WHERE UserID=@userID";
        internal string getUserInfo = "SELECT User_Login, User_FName, User_LName, roleName FROM s2016_user1.users AS US INNER JOIN s2016_user1.userRole AS UR ON US.userRoleID = UR.userRoleID WHERE UserID = @userID";
        internal string getUserGroups = "SELECT roleName FROM s2016_user1.userRole";
        internal string deleteUser = "DELETE FROM s2016_user1.users WHERE UserID=@userID";

        internal string getAllAisles = "SELECT aisle_ID AS `Aisle ID`, aisle_Name AS `Aisle Name` FROM s2016_user1.aisles";
        internal string getAllShelves = "SELECT shelf_ID as selfID FROM s2016_user1.shelves";
        internal string getAllBins = "SELECT bin_ID as binID FROM s2016_user1.bins";

        internal string getShelves = "SELECT shelf_ID AS `Shelf ID` FROM s2016_user1.shelves WHERE FK_aisle=@aisleID";

        internal string addAisle = "INSERT INTO s2016_user1.aisles VALUES(DEFAULT,@aisleName); SELECT LAST_INSERT_ID();";
        internal string addShelf = "INSERT INTO s2016_user1.shelves VALUES(DEFAULT, @aisleID)";
        internal string addBin = "INSERT INTO s2016_user1.bins VALUES(DEFAULT, @shelf, @maxWeight, @maxHeight, @maxWidth, @maxLength, @maxWidth, @maxWeight)";
        //adding queries
      
        internal string getCustomer = "SELECT customer_ID, firstName , lastName FROM s2016_user1.customers";
        internal string getMeasurements = "SELECT type FROM s2016_user1.unitOfMeasurement";


        /*internal string addInvetory = "INSERT INTO s2016_user1.item(FK_Customer_ID,itemDescription,length,width,height,weight,quantity,expirationDate,FK_Customers )" +
                                    "FROM s2016_user1.customers AS C " + "INNER JOIN bins AS b ON b.bin_ID = C.FK_bin " + "INNER JOIN shelves AS s ON s.shelf_ID = C.FK_shelf " + "INNER JOIN aisles AS a ON a.aisle_ID = FK_aisle";*/

        //Honestly could have just done INSERT INTO s2016 meaning select all instead of writing them all out//oh well
        internal string addInv = "INSERT INTO s2016_user1.item(itemName,length,width,height,weight,quantity,itemDescription,expirationDate,FK_bin,FK_Customers,FK_measurerment)"+
            " VALUES(@itemName, @length, @width, @height, @weight, @quantity, @quantity, @itemDescription, @expirationDate, @binID, @custID, @unitOfMeasurement)";
      
        /*FROM s2016_user1.item AS i FK_measurerment,

        INNER JOIN bins AS b ON b.bin_ID = i.FK_bin

        INNER JOIN shelves AS s ON s.shelf_ID = b.FK_shelf

        INNER JOIN aisles AS a ON a.aisle_ID = s.FK_aisle"*/
    }
}
