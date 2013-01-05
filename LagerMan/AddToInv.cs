using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LagerMan
{
    public partial class AddToInv : Form
    {
        public DataTable outputData = new DataTable();
        public DataTable viewData = new DataTable();
        public ArrayList rtnElements = new ArrayList();
            
        public AddToInv()
        {
            InitializeComponent();
            
            //Adding headers to DataTable
            outputData.Columns.Add("Leverandør", typeof(int));
            outputData.Columns.Add("Produkt Nr.:", typeof(int));
            outputData.Columns.Add("Stregkode:", typeof(Int64));
            
            viewData.Columns.Add("Leverandør", typeof(string));
            viewData.Columns.Add("Produkt:", typeof(string));
            viewData.Columns.Add("Stregkode:", typeof(Int64));

            this.supplierID.Select();
        }

        #region menubar

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hjælpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scan varene en ad gangen. \n" +
               "De scannede vare ses i feltet til højre", "Hjælp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region inputfields

        private void supplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (supplierID.Text)
                {
                    case "MAIN": gotoMain(); break;
                    default: this.prodNo1.Select(); break;
                }
            }
        }

        private void prodGrp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (prodNo1.Text)
                {
                    case "MAIN": gotoMain(); break;
                    case "CHANGE+SUPP": ChangeSuplier(); break;
                }
                this.barcodeIn.Select();
            }
        }

        private void barcodeIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (barcodeIn.Text)
                {
                    case "COMMIT": CommitToSQL(); break;
                    case "CHANGEPROD": changeprod(); break;
                    case "MAIN": gotoMain(); break;
                    case "CHANGE+SUPP": ChangeSuplier(); break;
                    default: _defaultAction();      break;
                }
            }
        }

        #endregion

        #region inputhandling

        private void gotoMain()
        {
            this.Close();
        }
        private void ChangeSuplier()
        {
            this.prodNo1.Text = "";
            this.supplierID.Text = "";
            this.barcodeIn.Text = "";
            this.supplierID.Select();
        }
        private void changeprod()
        {
            this.prodNo1.Text = "";
            this.barcodeIn.Text = "";
            this.prodNo1.Select();
        }
        private void _defaultAction()
        {
            SQLQuery getInfo = new SQLQuery();
            try
            {
                outputData.Rows.Add(Convert.ToInt32(supplierID.Text), Convert.ToInt32(prodNo1.Text), Convert.ToInt64(barcodeIn.Text));
                DataRow row = outputData.Rows[outputData.Rows.Count - 1];
                rtnElements = getInfo.getProdInfo(row);
                viewData.Rows.Add(rtnElements[0], rtnElements[1], Convert.ToInt64(barcodeIn.Text));
            }
            catch (Exception parseError)
            {
                string tmpStr = "Fejl i indtastning:" + parseError;
                MessageBox.Show(tmpStr, "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.dGV_scanned.DataSource = viewData;
            DataGridViewColumn column0 = this.dGV_scanned.Columns[0];
            column0.Width = 125;
            DataGridViewColumn column1 = this.dGV_scanned.Columns[1];
            column1.Width = 125;
            DataGridViewColumn column2 = this.dGV_scanned.Columns[2];
            column2.Width = 290;
            this.dGV_scanned.Invalidate();
            this.barcodeIn.Text = "";
            this.barcodeIn.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommitToSQL();
        }

        private void CommitToSQL()
        {
            SQLQuery addData = new SQLQuery();   
            addData.insertBaseStock(outputData);

            outputData.Clear();
            viewData.Clear();
            ChangeSuplier();
            this.dGV_scanned.Invalidate();

        }

        #endregion
    }
}