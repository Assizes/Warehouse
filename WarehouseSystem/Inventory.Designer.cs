﻿namespace WarehouseSystem
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnAddInventory = new System.Windows.Forms.Button();
            this.btnEditInventory = new System.Windows.Forms.Button();
            this.btnDeleteInventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 14);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(533, 305);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddInventory.Location = new System.Drawing.Point(574, 113);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(104, 23);
            this.btnAddInventory.TabIndex = 2;
            this.btnAddInventory.Text = "Add Inventory";
            this.btnAddInventory.UseVisualStyleBackColor = true;
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditInventory.Location = new System.Drawing.Point(574, 157);
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(104, 23);
            this.btnEditInventory.TabIndex = 3;
            this.btnEditInventory.Text = "Edit Inventory";
            this.btnEditInventory.UseVisualStyleBackColor = true;
            this.btnEditInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // btnDeleteInventory
            // 
            this.btnDeleteInventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeleteInventory.Location = new System.Drawing.Point(574, 205);
            this.btnDeleteInventory.Name = "btnDeleteInventory";
            this.btnDeleteInventory.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteInventory.TabIndex = 4;
            this.btnDeleteInventory.Text = "Delete Inventory";
            this.btnDeleteInventory.UseVisualStyleBackColor = true;
            this.btnDeleteInventory.Click += new System.EventHandler(this.btnDeleteInventory_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 329);
            this.Controls.Add(this.btnDeleteInventory);
            this.Controls.Add(this.btnEditInventory);
            this.Controls.Add(this.btnAddInventory);
            this.Controls.Add(this.dgvInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(723, 363);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Activated += new System.EventHandler(this.Inventory_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.Button btnEditInventory;
        private System.Windows.Forms.Button btnDeleteInventory;
    }
}