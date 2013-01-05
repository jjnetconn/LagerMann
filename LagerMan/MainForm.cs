using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LagerMan
{
    public partial class MainForm : Form
    {
        private static string _userName;
        private static int _userGroup;
        private static string _loginTime;
        private ArrayList supplierInfo;
        private DataSet excelin;

        public static void setLoggedIn(string userName, int userGroup, string loginTime)
        {
            _userName = userName;
            _loginTime = loginTime;
            _userGroup = userGroup;
        }

        public MainForm()
        {

            InitializeComponent();
            object ex = "Application starting @ " + DateTime.Now;
            EventlogAppender.logEvent_Start(ex);

            if (Properties.Settings.Default.isDemo != true)
            {
                //Get login form if not in demo mode
                LoginForm login = new LoginForm();

                //Hide MainForm and show login as ModalDialog, on return activate mainfom and set active
                this.Hide();
                login.ShowDialog();
                this.Show();
                this.Activate();
                this.Focus();
            }

            this.dataGridView1.DataSource = FillDataGrid();
            this.dataGridView1.Invalidate();
            this.quickMenu.Select();

            fillComboBox();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.Invalidate();
        }

        private DataTable FillDataGrid()
        {
            DataTable inventoryView = new DataTable();
            SQLQuery getData = new SQLQuery();
            ArrayList tmpList1 = new ArrayList(getData.listInventory());
            ArrayList tmpList2 = new ArrayList();

            int i = 0;

            inventoryView.Columns.Add("Produkt:", typeof(string));
            inventoryView.Columns.Add("Antal på lager:", typeof(int));

            foreach (int obj in tmpList1)
            {
                tmpList2.Add(getData.countInventory(obj));
            }

            foreach (int obj in tmpList1)
            {
                inventoryView.Rows.Add(getData.cnameInventory(obj).ToString(), tmpList2[i]);
                i++;
            }


            return inventoryView;
        }

        private void afslutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object ex = "Application exiting @ " + DateTime.Now;
            EventlogAppender.logEvent_Exit(ex);
            Application.Exit();
        }

        private void getFromInv_Click(object sender, EventArgs e)
        {
            clickGetFromInv();
        }

        private void addToInv_Click(object sender, EventArgs e)
        {
            clickAddToInv();
        }

        private void ExcelImportFlashDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int[] result = new int[2]; 
           int[] mresult = new int[3];

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            AlgatecImport import = new AlgatecImport();
            
            Stream xlsStream = null;

            openFileDialog1.InitialDirectory = "Desktop";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx| Excel 97-2003 files (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.SupportMultiDottedExtensions = true;

            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((xlsStream = openFileDialog1.OpenFile()) != null)
                    {

                        //Check if multiple files are selected
                        if (openFileDialog1.SafeFileNames.Length > 1)
                        {

                           //mresult = import.importMultipleFlashXls(openFileDialog1.FileNames);
                        }
                        else
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            toolStripStatusLabel2.Text = "Indlæser data...";
                            toolStripStatusLabel2.Invalidate();

                            result = import.importSingleFlashXls(openFileDialog1.FileName);
                            
                            Cursor.Current = Cursors.Default;
                            toolStripStatusLabel2.Text = "Klar";
                            toolStripStatusLabel2.Invalidate();
                        }
                    }
                    xlsStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message + ex.StackTrace);
                    EventlogAppender.logEvent_error_SQL(ex.Message + ex.StackTrace);
                }
            }
            if (result[0] > 0 && result[1] == 0)
            {
                string tmpStr = "Succes! \n" + result[0] + " paneler importeret";
                MessageBox.Show(tmpStr, "Data import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result[1] > 0 && result[0] == 0)
            {
                string tmpStr = "Fejl!\n Alle " + result[1] + " paneler findes i databasen"; 
                MessageBox.Show(tmpStr, "Import resultat", MessageBoxButtons.OK);
            }
            else if (result[0] > 0 && result[1] > 0)
            {
                string tmpStr = "Problemer med Import, " + result[1] + " paneler findes i databasen \n" + result[0] + " importeret";
                MessageBox.Show(tmpStr, "Import resultat", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Import af Flash Data mislykkedes. \nSe eventlog for fejlbeskrivelse", "Import resultat", MessageBoxButtons.OK);
            }
            this.dataGridView1.DataSource = FillDataGrid();
            this.dataGridView1.Invalidate();
            this.quickMenu.Select();
           }

        private void quickMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (quickMenu.Text)
                {
                    case "REG+IN": clickAddToInv(); break;
                    case "REG+OUT": clickGetFromInv(); break;
                    default: break;
                }
            }
        }
        
        private void clickAddToInv()
        {
            quickMenu.Text = "";
            AddToInv addinv = new AddToInv();
            this.Hide();
            addinv.ShowDialog();
            this.Show();
            this.Activate();
            this.Focus();
        }

        private void clickGetFromInv()
        {
            quickMenu.Text = "";
            GetFromInv getinv = new GetFromInv();
            this.Hide();
            getinv.ShowDialog();
            this.Show();
            this.Activate();
            this.Focus();
        }
        private void fillComboBox()
        {
            SQLQuery getData = new SQLQuery();
            this.supplierInfo = getData.getSuppliers();
            foreach (object[] obj in this.supplierInfo)
            {
                this.comboBox1.Items.Add(obj[0].ToString());
            }
        }

        private void getBySupplier_Click(object sender, EventArgs e)
        {
            stockBySupplier();
            
        }
        private void stockBySupplier()
        {
            object[] selectedObj = new object[3];
            selectedObj = (object[])this.supplierInfo[this.comboBox1.SelectedIndex];
            selectedObj[0].ToString();
        }

        private void flashDataSunpowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] result = new int[2];
            int[] mresult = new int[3];

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            Stream xlsStream = null;

            openFileDialog1.InitialDirectory = "Desktop";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx| Excel 97-2003 files (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.SupportMultiDottedExtensions = true;

            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((xlsStream = openFileDialog1.OpenFile()) != null)
                    {

                        //Check if multiple files are selected
                        if (openFileDialog1.SafeFileNames.Length > 1)
                        {

                            //mresult = import.importMultipleFlashXls(openFileDialog1.FileNames);
                        }
                        else
                        {
                            //SunpowerImport import = new SunpowerImport(openFileDialog1.FileName);
                            testExcelImport import = new testExcelImport(openFileDialog1.FileName);
                            Cursor.Current = Cursors.WaitCursor;
                            toolStripStatusLabel2.Text = "Indlæser data...";
                            toolStripStatusLabel2.Invalidate();

                            //excelin = import.importwIntOp(openFileDialog1.FileName);
                            //result = import.importWorkbook(openFileDialog1.FileName);

                            Cursor.Current = Cursors.Default;
                            toolStripStatusLabel2.Text = "Klar";
                            toolStripStatusLabel2.Invalidate();
                        }
                    }
                    xlsStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message + ex.StackTrace);
                    EventlogAppender.logEvent_error_SQL(ex.Message + ex.StackTrace);
                }
            }
            if (result[0] > 0 && result[1] == 0)
            {
                string tmpStr = "Succes! \n" + result[0] + " paneler importeret";
                MessageBox.Show(tmpStr, "Data import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result[1] > 0 && result[0] == 0)
            {
                string tmpStr = "Fejl!\n Alle " + result[1] + " paneler findes i databasen";
                MessageBox.Show(tmpStr, "Import resultat", MessageBoxButtons.OK);
            }
            else if (result[0] > 0 && result[1] > 0)
            {
                string tmpStr = "Problemer med Import, " + result[1] + " paneler findes i databasen \n" + result[0] + " importeret";
                MessageBox.Show(tmpStr, "Import resultat", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Import af Flash Data mislykkedes. \nSe eventlog for fejlbeskrivelse", "Import resultat", MessageBoxButtons.OK);
            }
            this.dataGridView1.DataSource = FillDataGrid();
            this.dataGridView1.Invalidate();
            this.quickMenu.Select();
        }
      }
}
