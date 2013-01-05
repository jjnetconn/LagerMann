using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LagerMan
{
    public partial class GetFromInv : Form
    {
        public DataTable outputData = new DataTable();
        public DataTable viewData = new DataTable();
        public Object rtnElements;
        private Int64 LagermanId;

        public GetFromInv()
        {
            InitializeComponent();
           
            //Adding headers to DataTable
            //outputData.Columns.Add("Vare Gruppe", typeof(Int32));
            outputData.Columns.Add("Produkt Nr.:", typeof(Int32));
            outputData.Columns.Add("Stregkode:", typeof(String));

            viewData.Columns.Add("Vare", typeof(String));
            viewData.Columns.Add("Stregkode:", typeof(String));
            dataGridView1.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hjælpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scan varene en ad gangen. \n" +
                "De scannede vare ses i feltet til højre", "Hjælp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gotoMain()
        {
            this.Close();
        }

        private void changeGrp()
        {
         //   this.prodNo1.Text = "";
         //   this.supplierID.Text = "";
         //   this.barcodeIn.Text = "";
         //   this.supplierID.Select();
        }

        private void changeProd()
        {
         //   this.prodNo1.Text = "";
         //   this.barcodeIn.Text = "";
         //   this.prodNo1.Select();
        }

        private void changeCustomer()
        {
            this.customerOut.Text = "";
            this.customerNameValue.Text = "";
            this.customerOut.Select();
        }

        private void commitProd()
        {
            SQLQuery getInfo = new SQLQuery();
            try
            {
                //outputData.Rows.Add(Convert.ToInt32(prodGrpOut.Text), Convert.ToInt32(prodCodeOut.Text), barcodeOut.Text);
                outputData.Rows.Add(Convert.ToInt32(prodCodeOut.Text), barcodeOut.Text); DataRow row = outputData.Rows[outputData.Rows.Count - 1];
                rtnElements = getInfo.getProdNameOut(Convert.ToInt32(prodCodeOut.Text));
                viewData.Rows.Add(rtnElements, barcodeOut.Text);
            }
            catch (Exception parseError)
            {
                string tmpStr = "Fejl i indtastning:" + parseError;
                MessageBox.Show(tmpStr, "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.dataGridView1.DataSource = viewData;
            
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 180;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 125;
            
            this.dataGridView1.Invalidate();
            barcodeOut.Text = "";
            barcodeOut.Select();
        }

        private void customerOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (customerOut.Text)
                {
                    case "MAIN": gotoMain(); break;
                    default: this.outStreet.Select(); break;
                }
                customerNameValue.Text = customerOut.Text;
                this.LagermanId = genLagermanNumber();
                lagermanNr.Text = this.LagermanId.ToString();
            }
        }

        private void outStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (outStreet.Text)
                {
                    case "MAIN": gotoMain(); break;
                    default: this.outPostCode.Select(); break;
                }
            }
        }

        private void outPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (outPostCode.Text)
                {
                    case "MAIN": gotoMain(); break;
                    default: this.outCity.Select(); break;
                }
            }
        }

        private void outCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (outCity.Text)
                {
                    case "MAIN": gotoMain(); break;
                    default: this.prodCodeOut.Select(); break;
                }
            }
        }

        private void prodCodeOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                switch (prodCodeOut.Text)
                {
                    case "MAIN": gotoMain(); break;
                    case "CHANGE+CUST": changeCustomer(); break;
                    case "CHANGE+GRP": changeCustomer(); break;
                    default: this.barcodeOut.Select(); break;
                }
            }
        }

        private void barcodeOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab )
            {
                switch (barcodeOut.Text)
                {
                    case "MAIN": gotoMain(); break;
                    case "CHANGE+CUST": changeCustomer(); break;
                    case "CHANGE+GRP": changeGrp(); break;
                    case "CHANGE+PROD": changeProd(); break;
                    default: commitProd(); break;
                }
            }
        }

        private void commitToSQL_Click(object sender, EventArgs e)
        {
            string customerName = customerOut.Text;
            string customerStreetAddress = outStreet.Text;
            string customerCity = outCity.Text;
            int customerPostalCode = 0;
            string prodBlob = "";

            ArrayList productsOut = new ArrayList();

            if (outPostCode.Text.Equals(""))
            {
                MessageBox.Show(GetFromInv.ActiveForm, "Postnummer mangler!", "FEJL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                outPostCode.Select();
            }
            else
            {
                customerPostalCode = Convert.ToInt32(outPostCode.Text);
            }

            //build string with prods.
            foreach (DataRow currentRow in outputData.Rows)
            {
                if (prodBlob.Length > 0)
                {
                    prodBlob = prodBlob + currentRow.ItemArray.GetValue(0).ToString() + "," + currentRow.ItemArray.GetValue(1).ToString() + ";";
                    productsOut.Add(currentRow.ItemArray.GetValue(1));
                }
                else
                {
                    prodBlob = currentRow.ItemArray.GetValue(0).ToString() + "," + currentRow.ItemArray.GetValue(1).ToString() + ";";
                    productsOut.Add(currentRow.ItemArray.GetValue(1));
                }
            }

            //MessageBox.Show(prodBlob);

            SQLQuery commitData = new SQLQuery();
            commitData.commitShipment(customerName, customerStreetAddress, customerCity, customerPostalCode, this.LagermanId, prodBlob);

            foreach (String serial in productsOut)
            {
                commitData.removeFromStock(serial);
            }

            CreatePDF(viewData);
            resetScreen();
        }

        private void CreatePDF(DataTable inData)
        {
            PDFform pdfForm = new PDFform(inData, Properties.Settings.Default.Logo);

            // Create a MigraDoc document
            Document document = pdfForm.CreateDocument(this.LagermanId, this.customerOut.Text, this.outStreet.Text, this.outPostCode.Text, this.outCity.Text);
            document.UseCmykColor = true;

            // Create a renderer for PDF that uses Unicode font encoding
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;


            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            string filename = Properties.Settings.Default.pdfSavePath + "Foelgesedel_" + this.customerOut.Text + ".pdf";

            pdfRenderer.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        private void resetScreen()
        {
            //Dispose of old items
            outputData.Dispose();
            viewData.Dispose();
            
            //create fresh once
            outputData = new DataTable();
            viewData = new DataTable();
            
            //Clear dataGridView
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataBindings.Clear();
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Invalidate();

            customerOut.Text = "";
            customerOut.Select();
            customerNameValue.Text = "";
            prodCodeOut.Text = "";
            barcodeOut.Text = "";
            outStreet.Text = "";
            outCity.Text = "";
            outPostCode.Text = "";
        }

        private Int64 genLagermanNumber()
        {
            SQLQuery getData = new SQLQuery();
            
            int shipmentsInWarehouse = Convert.ToInt32(getData.countShipments());
            DateTime moment = DateTime.Now;

            string lagermanNr = moment.Year.ToString() + moment.DayOfYear.ToString() + "00" + shipmentsInWarehouse;
            //int lagermanInt = Convert.ToInt32(lagermanNr);

            return Convert.ToInt64(lagermanNr);
        }
    }
}