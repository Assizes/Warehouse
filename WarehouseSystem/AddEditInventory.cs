﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSystem
{
    public partial class AddEditInventory : Form
    {
        private WarehouseSystem warehouse = (WarehouseSystem)Application.OpenForms["WarehouseSystem"];
        private Inventory inventory = (Inventory)Application.OpenForms["Inventory"];
        MySqlConnection connection;
        MySqlCommand cmd = new MySqlCommand();
        DBqueries queries = new DBqueries();
        string fType = "Add";
        string query;
        //addedstuff
        MySqlDataReader dr;
        List<String> customerIDList = new List<String>();
        List<String> unitIDList = new List<String>();
        private int _id;

        public string itemIdData;

        public AddEditInventory()
        {
            InitializeComponent();

            

            //hide this
            /* datetimeItemExpiration.Hide();
               lblExpirationDate.Hide();*/
            //Gray out instrad
            lblExpirationDate.Enabled = false;
            datetimeItemExpiration.Enabled = false;
            // labelItemID.Hide();



            //====

            cmd.Parameters.Add("@itemName", MySqlDbType.String);
            cmd.Parameters.Add("@weight", MySqlDbType.String);
            cmd.Parameters.Add("@height", MySqlDbType.String);
            cmd.Parameters.Add("@width", MySqlDbType.String);
            cmd.Parameters.Add("@length", MySqlDbType.String);
            cmd.Parameters.Add("@quantity", MySqlDbType.String);
            cmd.Parameters.Add("@itemDescription", MySqlDbType.String);
            cmd.Parameters.Add("@expirationDate", MySqlDbType.String);
            cmd.Parameters.Add("@unitOfMeasurement", MySqlDbType.String);
            cmd.Parameters.Add("@custID", MySqlDbType.String);
            //========two seperate inserts will happen//One for^^ ours other for FK
            cmd.Parameters.Add("@aisleID", MySqlDbType.String);
            cmd.Parameters.Add("@binID", MySqlDbType.String);
            cmd.Parameters.Add("@selfID", MySqlDbType.String);

            cmd.Parameters.Add("@itemID", MySqlDbType.String);

            //added stuff
            connection = warehouse.Connection;
          

            //retrive data to put in dropmenu

            //retrieve customers
            cmd.CommandText = queries.getCustomer;


            cmd.Connection = connection;

            //retrieve aisle,shelf,bin? - generate button does a where?
            dr = cmd.ExecuteReader();
            

            //DataSet ds = new DataSet();

            while (dr.Read())
            {
              //  tempList.Add(dr[0].ToString());
                cmbItemCustomer.Items.Add("ID:"+dr[0].ToString()+"Name:"+ dr[1].ToString() +" "+dr[2].ToString());
                customerIDList.Add(dr[0].ToString());
                
            }

            dr.Close();

            cmd.CommandText = queries.getMeasurements;
            doQueries(cmbUnitofMeasurement);

            //For specefic customer
            //cmd.CommandText = queries.getBinsForThisCustomer;
            //doQueries(cmbItemBin);


            //FOR TESTING
            /*txtItemName.Text = "a";
            txtItemDescription.Text = "a";
            txtItemLength.Text = "1";
            txtItemWidth.Text = "1";
            txtItemHeight.Text = "1";
            txtItemWeight.Text = "1";
            txtItemQuantity.Text = "1";
            cmbItemCustomer.SelectedIndex = 0;
            cmbUnitofMeasurement.SelectedIndex = 0;
            cmbItemAisle.SelectedIndex = 0;
            cmbItemShelf.SelectedIndex = 0;
            cmbItemBin.SelectedIndex = 0;*/

        }

        public void setID(int id)
        {
            _id = id;
            if (_id != -1)
            {
                cmd.Parameters["@customerID"].Value = _id;
                try
                {
                    if (connection != null)
                    {
                        cmd.CommandText = queries.getCustomerInfo;
                        cmd.Connection = connection;
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            //txtItemName.Text = dr[0].ToString();
                            txtItemName.Text = dr[1].ToString();
                            txtItemWeight.Text = dr[2].ToString();
                            txtItemHeight.Text = dr[3].ToString();
                            txtItemWidth.Text = dr[4].ToString();
                            txtItemLength.Text = dr[5].ToString();
                            txtItemQuantity.Text = dr[6].ToString();
                            txtItemDescription.Text = dr[7].ToString();

                        }
                        dr.Close();

                    }
                    else
                    {
                        MessageBox.Show("Connection Lost");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void doQueries(ComboBox c)
        {
            //String q = query  +"."+ querieName;
            //cmd.CommandText = q;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                c.Items.Add(dr[0].ToString());
            }
           // c.Items.Add("------");

            if (c == cmbUnitofMeasurement)
            {
                unitIDList.Add(dr[1].ToString());
            }

            dr.Close();
        }

        private void btnItemReset_Click(object sender, EventArgs e)
        {
            if (fType == "Add")
            {
                txtItemName.Text = "";
                txtItemDescription.Text = "";
                txtItemLength.Text = "";
                txtItemWidth.Text = "";
                txtItemHeight.Text = "";
                txtItemWeight.Text = "";
                txtItemQuantity.Text = "";
                datetimeItemExpiration.Text = "";

                //by the way//if we don't add data to combo box this will crash when run since index 0 doesnt exsist

                //if (cmbItemCustomer.Items.Count > 0)

                cmbItemCustomer.SelectedIndex = 0;
                cmbUnitofMeasurement.SelectedIndex = 0;
                cmbItemAisle.SelectedIndex = 0;
                cmbItemShelf.SelectedIndex = 0;
                cmbItemBin.SelectedIndex = 0;
                

                rdoExpirationYes.Checked = false;
                rdoExpirationNo.Checked = true;

                datetimeItemExpiration.Value = DateTime.Today;
            }
            else
            {
                Close();
            }
        }

        public void setType(string type)
        {
            if (type == "Edit")
            {
                btnItemAddSave.Text = "Save";
                btnItemResetCancel.Text = "Cancel";
                fType = type;
                lblFind.Show();
                buttonFind.Show();
            }
            else if (type=="Add")
            {
                btnItemAddSave.Text = "Add Item";
                btnItemResetCancel.Text = "Reset";
                fType = type;
                lblFind.Hide();
                buttonFind.Hide();
            }
            else
            {
                btnItemAddSave.Text = "Delete";
                btnItemResetCancel.Text = "Cancel";
                fType = type;
                lblFind.Show();
                buttonFind.Show();
            }
        }

        private void btnItemAddSave_Click(object sender, EventArgs e)
        {

            connection = warehouse.Connection;

            if (fType == "Delete")
            {


                if (cmbItemCustomer.SelectedIndex != -1)
                {
                    cmd.Parameters["@itemID"].Value = itemIdData;

                    query = queries.deleteInv;
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    //Insert/delete command
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Delete Succesful");
                    //closes form
                    Close();
                }
                else
                {
                    MessageBox.Show("Please choose a customer");
                }
            }   
            else if 
                (txtItemName.Text != "" && txtItemDescription.Text != "" && txtItemLength.Text != "" &&
                txtItemWidth.Text != "" && txtItemHeight.Text != "" && txtItemWeight.Text != ""
                 && txtItemQuantity.Text != "" && cmbItemCustomer.SelectedIndex != -1
                  && cmbUnitofMeasurement.SelectedIndex != -1 && cmbItemAisle.SelectedIndex != -1 && cmbItemShelf.SelectedIndex != -1
                   && cmbItemBin.SelectedIndex != -1)
            {
                //takes all text values and assigns them to parameters
                cmd.Parameters["@itemName"].Value = txtItemName.Text;
                cmd.Parameters["@weight"].Value = txtItemWeight.Text;
                cmd.Parameters["@height"].Value = txtItemHeight.Text;
                cmd.Parameters["@width"].Value = txtItemWidth.Text;
                cmd.Parameters["@length"].Value = txtItemLength.Text;
                cmd.Parameters["@quantity"].Value = txtItemQuantity.Text;
                cmd.Parameters["@itemDescription"].Value = txtItemDescription.Text;

                int idPlace = cmbUnitofMeasurement.SelectedIndex;
                cmd.Parameters["@unitOfMeasurement"].Value = customerIDList[idPlace];
               // MessageBox.Show(idPlace.ToString());
                int place = cmbItemCustomer.SelectedIndex;
                cmd.Parameters["@custID"].Value = customerIDList[place];
               // MessageBox.Show(place.ToString());
                //============FK
                cmd.Parameters["@aisleID"].Value= cmbItemAisle.Text;
                cmd.Parameters["@binID"].Value = cmbItemBin.Text;
                cmd.Parameters["@selfID"].Value = cmbItemShelf.Text;
                cmd.Parameters["@itemID"].Value = itemIdData;


                //If radio 'expired' is true
                if (rdoExpirationYes.Checked == true)
                {
                    // datetimeItemExpiration.Format = DateTimePickerFormat.Custom;
                    //datetimeItemExpiration.CustomFormat = "yyyy MM dd";
                    String thisDate = Convert.ToDateTime(datetimeItemExpiration.Text).ToString("yyyy-MM-dd");
                    cmd.Parameters["@expirationDate"].Value = thisDate;

                    //MessageBox.Show(thisDate);
                }
                else
                {
                    cmd.Parameters["@expirationDate"].Value = 0000-00-00;
                }

            }
            else
            {
                MessageBox.Show("Please, fill up required fields!");
                return;
            }
//finsih this //Meaning they are going to add
            if (fType == "Add")
            {
                try
                {   
                    //in our case we are maintaing connection from the first time we connected
                    if (connection != null)
                    {
                        
                        //MessageBox.Show("@binID");
                        
                        //calling query //we intialized in field already
                        query = queries.addInv;
                        cmd.CommandText = query;
                        cmd.Connection = connection;
                        //Insert/delete command
                        cmd.ExecuteNonQuery();

                        //closes form
                        Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Connection Lost");
                        this.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if(fType == "Edit")//its going to be edit
            {
                
                //MessageBox.Show(itemIdData);
                query = queries.editInv;
                cmd.CommandText = query;
                cmd.Connection = connection;
                //Insert/delete command
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");
                //closes form
                Close();
            } 
        }

        private void rdoExpirationNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoExpirationNo.Checked)
            {
                //lblExpirationDate.Hide();
                //datetimeItemExpiration.Hide();

                lblExpirationDate.Enabled = false;
                datetimeItemExpiration.Enabled = false;
            }
            else
            {
               // lblExpirationDate.Show();
                //datetimeItemExpiration.Show();

                lblExpirationDate.Enabled = true;
                datetimeItemExpiration.Enabled = true;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            AddEditInventory addEditInv = new AddEditInventory();
            addEditInv = this;

            CustomerItem c = new CustomerItem(ref addEditInv);

           

            int place = cmbItemCustomer.SelectedIndex;
            cmd.Parameters["@custID"].Value = customerIDList[place];
            String data = customerIDList[place];


           /* MessageBox.Show(place.ToString());
            MessageBox.Show(customerIDList[place]);
            MessageBox.Show(cmd.Parameters["@custID"].Value.ToString());*/
            c.ourData = customerIDList[place];

            //query = queries.getItemID;
            //cmd.CommandText = query;
           // MessageBox.Show(query);

           // passMqSqlArgue(query, data, dataGridView1, "s2016_user1.item");

            

            c.Show();

        }

        public void passMqSqlArgue(string query,String a, DataGridView dgv, String tableName)
        {
            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT itemName FROM s2016_user1.item WHERE FK_customers = "+a, connection);//Query statement + connection
            adapter.Fill(dataset, tableName); //meaning what TABLE name im getting it from FROM EMPLOYESS
            dgv.DataSource = dataset.Tables[tableName]; //I actually forgot to add this part....
            //Put in method so I don't have to spam this in every line
            //adapter.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void updateLabel()
        {
            //labelItemID.Text = itemIdData;
   
        }

        private void btnItemLocation_Click(object sender, EventArgs e)
        {
            if (cmbItemCustomer.SelectedIndex != -1)
            {
                int place = cmbItemCustomer.SelectedIndex;

                //For specefic customer
                cmd.CommandText = queries.getBinsForThisCustomer;
                doQueries(cmbItemBin);

                //FINISHED LATER//EDIT QUERIES LATER//they should only show ones that are not occupied
                cmd.CommandText = queries.getAllAisles;
                doQueries(cmbItemAisle);

                cmd.CommandText = queries.getAllShelves;
                doQueries(cmbItemShelf);

                // cmd.CommandText = queries.getAllBins;
                //Show data not tkaen
                cmd.CommandText = queries.getBinsNotTaken;
                doQueries(cmbItemBin);

                cmd.Parameters["@custID"].Value = customerIDList[place];

                MessageBox.Show("Data Has Been Loaded");

            }
            else
            {
                MessageBox.Show("Please Select a customer");
            }
        }

        public void getDeleteData(String data)
        {
            fType = data;

        }

        public void checkType()
        {
            if (fType == "Delete")
            {
                txtItemName.Enabled = false;
                txtItemDescription.Enabled = false;
                txtItemLength.Enabled = false;
                txtItemWidth.Enabled = false;
                txtItemHeight.Enabled = false;
                txtItemWeight.Enabled = false;
                txtItemQuantity.Enabled = false;
                cmbUnitofMeasurement.Enabled = false;
                cmbItemAisle.Enabled = false;
                cmbItemShelf.Enabled = false;
                cmbItemBin.Enabled = false;
                btnItemLocation.Enabled = false;
                rdoExpirationNo.Enabled = false;
                rdoExpirationYes.Enabled = false;

            }
            
        }

        private void AddEditInventory_Shown(object sender, EventArgs e)
        {
            checkType();
        }
    }
}
