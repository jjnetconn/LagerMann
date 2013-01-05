using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
//using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LagerMan
{
    class SQLQuery
    {
        private MySqlConnection mysqlConn;
        
        public SQLQuery()
        {
            mySqlInit();
        }
        private void mySqlInit()
        {
            try {
                this.mysqlConn = new MySqlConnection(Properties.Settings.Default.mysqlConn);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString(), "MySQL Connection error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
        }
        private MySqlConnection getConn()
        {
            if (this.mysqlConn.State == ConnectionState.Closed)
            {
            try{
               this.mysqlConn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString(), "MySQL Connection error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            return this.mysqlConn;
        }
            else{
            return this.mysqlConn;
            }
        }

        
        public ArrayList CheckUsr(string uName)
        {
            ArrayList sql_queryRtn = new ArrayList();

            //Create and Execute SQL statement
            try
            {
                MySqlDataReader sql_getUsr = null;
                MySqlCommand sql_userQuery = new MySqlCommand("select uPass, uLvl, uCreateDate, uModDate from lagerman.users where uName = '" + uName + "'", getConn());
                sql_getUsr = sql_userQuery.ExecuteReader();
                while (sql_getUsr.Read())
                {
                    sql_queryRtn.Add(sql_getUsr["uPass"]);
                    sql_queryRtn.Add(sql_getUsr["uLvl"]);
                    sql_queryRtn.Add(sql_getUsr["uCreateDate"]);
                    sql_queryRtn.Add(sql_getUsr["uModDate"]);
                }
                mysqlConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            return sql_queryRtn;
        }

        public bool loadFlashData(object[] data, int supplier_id, int prod_id)
        {
            bool sqlResult = false;

            MySqlConnection localConn = getConn();

            MySqlCommand cmd = localConn.CreateCommand();
            MySqlTransaction loadTransAct;

            // Start a local transaction and add parameters
            loadTransAct = localConn.BeginTransaction();
            cmd.Connection = getConn();
            cmd.Transaction = loadTransAct;

            cmd.Parameters.Add(new MySqlParameter("?inOrder_no", MySqlDbType.VarChar));
            cmd.Parameters["?inOrder_no"].Value = data[0];
            cmd.Parameters["?inOrder_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("order_no", SqlDbType.VarChar).Value = data[0];

            cmd.Parameters.Add(new MySqlParameter("?inArticle_no", MySqlDbType.Int32));
            cmd.Parameters["?inArticle_no"].Value = data[1];
            cmd.Parameters["?inArticle_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("article_no", SqlDbType.Float).Value = data[1];

            cmd.Parameters.Add(new MySqlParameter("?inArticle_name", MySqlDbType.VarChar));
            cmd.Parameters["?inArticle_name"].Value = data[2];
            cmd.Parameters["?inArticle_name"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("article_name", SqlDbType.VarChar).Value = data[2];

            cmd.Parameters.Add(new MySqlParameter("?inPallet_no", MySqlDbType.Int32));
            cmd.Parameters["?inPallet_no"].Value = data[3];
            cmd.Parameters["?inPallet_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("pallet_no", SqlDbType.Int).Value = data[3];

            cmd.Parameters.Add(new MySqlParameter("?inSerial_no", MySqlDbType.VarChar));
            cmd.Parameters["?inSerial_no"].Value = data[4];
            cmd.Parameters["?inSerial_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("serial_no", SqlDbType.Int).Value = data[4];

            cmd.Parameters.Add(new MySqlParameter("?inProd_date", MySqlDbType.DateTime));
            cmd.Parameters["?inProd_date"].Value = data[5];
            cmd.Parameters["?inProd_date"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("prod_date", SqlDbType.Date).Value = data[5];

            cmd.Parameters.Add(new MySqlParameter("?inCellclass", MySqlDbType.Float));
            cmd.Parameters["?inCellclass"].Value = data[6];
            cmd.Parameters["?inCellclass"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("cellclass", SqlDbType.Float).Value = data[6];

            cmd.Parameters.Add(new MySqlParameter("?inVoc", MySqlDbType.Float));
            cmd.Parameters["?inVoc"].Value = data[7];
            cmd.Parameters["?inVoc"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("voc", SqlDbType.Float).Value = data[7];

            cmd.Parameters.Add(new MySqlParameter("?inisc", MySqlDbType.Float));
            cmd.Parameters["?inIsc"].Value = data[8];
            cmd.Parameters["?inIsc"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("isc", SqlDbType.Float).Value = data[8];
              
            cmd.Parameters.Add(new MySqlParameter("?inPmpp", MySqlDbType.Float));
            cmd.Parameters["?inPmpp"].Value = data[9];
            cmd.Parameters["?inPmpp"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("pmpp", SqlDbType.Float).Value = data[9];
               
            cmd.Parameters.Add(new MySqlParameter("?inEff", MySqlDbType.Float));
            cmd.Parameters["?inEff"].Value = data[10];
            cmd.Parameters["?inEff"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("eff", SqlDbType.Float).Value = data[10];
                
            cmd.Parameters.Add(new MySqlParameter("?inFf", MySqlDbType.Float));
            cmd.Parameters["?inFf"].Value = data[11];
            cmd.Parameters["?inFf"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("ff", SqlDbType.Float).Value = data[11];

            cmd.Parameters.Add(new MySqlParameter("?inVmp", MySqlDbType.Float));
            cmd.Parameters["?inVmp"].Value = data[12];
            cmd.Parameters["?inVmp"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("vmp", SqlDbType.Float).Value = data[12];

            cmd.Parameters.Add(new MySqlParameter("?inImp", MySqlDbType.Float));
            cmd.Parameters["?inImp"].Value = data[13];
            cmd.Parameters["?inImp"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("imp", SqlDbType.Float).Value = data[13];

            cmd.Parameters.Add(new MySqlParameter("?inSupplier_id", MySqlDbType.Int32));
            cmd.Parameters["?inSupplier_id"].Value = supplier_id;
            cmd.Parameters["?inSupplier_id"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("supplier_id", SqlDbType.Int).Value = supplier_id;

            cmd.Parameters.Add(new MySqlParameter("?inProd_id", MySqlDbType.Int32));
            cmd.Parameters["?inProd_id"].Value = prod_id;
            cmd.Parameters["?inProd_id"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("prod_id", SqlDbType.Int).Value = prod_id;

            try
                {
                    //cmd.CommandText = "EXEC [dbo].[spLOADPanels] @supplier_id, @prod_id, @order_no, @article_no, @article_name, @pallet_no, @serial_no, @prod_date, @cellclass, @voc, @isc, @pmpp, @eff, @ff, @vmp, @imp";
                    cmd.CommandText = "lagerman.rtLOADPanels;";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    loadTransAct.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        loadTransAct.Rollback();
                    }
                    catch (MySqlException ex)
                    {
                        if (loadTransAct.Connection != null)
                        {
                            EventlogAppender.logEvent_error_SQL(ex.GetType());
                            EventlogAppender.logEvent_error_SQL(ex.StackTrace);
                        }
                    }
                    EventlogAppender.logEvent_error_SQL(e.GetType());
                    EventlogAppender.logEvent_error_SQL(e.StackTrace);
                    MessageBox.Show("StackTrace: " + e.StackTrace, "Error");
                    MessageBox.Show("Message: " + e.Message, "Error");
                }
                this.mysqlConn.Close();
                return sqlResult;
        }

        public bool loadFlashDataSP(object[] data, int supplier_id, int prod_id)
        {
            bool sqlResult = false;

            MySqlConnection localConn = getConn();

            MySqlCommand cmd = localConn.CreateCommand();
            MySqlTransaction loadTransAct;

            // Start a local transaction and add parameters
            loadTransAct = localConn.BeginTransaction();
            cmd.Connection = getConn();
            cmd.Transaction = loadTransAct;

            cmd.Parameters.Add(new MySqlParameter("?inOrder_no", MySqlDbType.VarChar));
            cmd.Parameters["?inOrder_no"].Value = data[0];
            cmd.Parameters["?inOrder_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("order_no", SqlDbType.VarChar).Value = data[0];

            cmd.Parameters.Add(new MySqlParameter("?inArticle_no", MySqlDbType.Int32));
            cmd.Parameters["?inArticle_no"].Value = data[1];
            cmd.Parameters["?inArticle_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("article_no", SqlDbType.Float).Value = data[1];

            cmd.Parameters.Add(new MySqlParameter("?inArticle_name", MySqlDbType.VarChar));
            cmd.Parameters["?inArticle_name"].Value = data[2];
            cmd.Parameters["?inArticle_name"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("article_name", SqlDbType.VarChar).Value = data[2];

            cmd.Parameters.Add(new MySqlParameter("?inSerial_no", MySqlDbType.VarChar));
            cmd.Parameters["?inSerial_no"].Value = data[3];
            cmd.Parameters["?inSerial_no"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("serial_no", SqlDbType.Int).Value = data[4];

            cmd.Parameters.Add(new MySqlParameter("?inTestId", MySqlDbType.Int32));
            cmd.Parameters["?inTestId"].Value = data[4];
            cmd.Parameters["?inTestId"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inCellclass", MySqlDbType.Float));
            cmd.Parameters["?inCellclass"].Value = data[5];
            cmd.Parameters["?inCellclass"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("cellclass", SqlDbType.Float).Value = data[6];

            cmd.Parameters.Add(new MySqlParameter("?inVoc", MySqlDbType.Float));
            cmd.Parameters["?inVoc"].Value = data[6];
            cmd.Parameters["?inVoc"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("voc", SqlDbType.Float).Value = data[7];

            cmd.Parameters.Add(new MySqlParameter("?inisc", MySqlDbType.Float));
            cmd.Parameters["?inIsc"].Value = data[7];
            cmd.Parameters["?inIsc"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("isc", SqlDbType.Float).Value = data[8];

            cmd.Parameters.Add(new MySqlParameter("?inEff", MySqlDbType.Float));
            cmd.Parameters["?inEff"].Value = data[8];
            cmd.Parameters["?inEff"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("eff", SqlDbType.Float).Value = data[10];

            cmd.Parameters.Add(new MySqlParameter("?inFf", MySqlDbType.Float));
            cmd.Parameters["?inFf"].Value = data[11];
            cmd.Parameters["?inFf"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("ff", SqlDbType.Float).Value = data[11];

            cmd.Parameters.Add(new MySqlParameter("?inVmp", MySqlDbType.Float));
            cmd.Parameters["?inVmp"].Value = data[12];
            cmd.Parameters["?inVmp"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("vmp", SqlDbType.Float).Value = data[12];

            cmd.Parameters.Add(new MySqlParameter("?inImp", MySqlDbType.Float));
            cmd.Parameters["?inImp"].Value = data[13];
            cmd.Parameters["?inImp"].Direction = ParameterDirection.Input;
            //cmd.Parameters.Add("imp", SqlDbType.Float).Value = data[13];

            try
            {
                cmd.CommandText = "testDB.rtLOADPanelsSP;";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                loadTransAct.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    loadTransAct.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (loadTransAct.Connection != null)
                    {
                        EventlogAppender.logEvent_error_SQL(ex.GetType());
                        EventlogAppender.logEvent_error_SQL(ex.StackTrace);
                    }
                }
                EventlogAppender.logEvent_error_SQL(e.GetType());
                EventlogAppender.logEvent_error_SQL(e.StackTrace);
                MessageBox.Show("StackTrace: " + e.StackTrace, "Error");
                MessageBox.Show("Message: " + e.Message, "Error");
            }
            this.mysqlConn.Close();
            return sqlResult;
        }

        public bool sql_getPanel(object serial_no)
        {
            bool isInDB = false;

            //Create and Execute SQL statement
            try
            {
                MySqlDataReader sql_getUsr = null;
                MySqlCommand sql_userQuery = new MySqlCommand("SELECT * FROM lagerman.panelbase where serial_no = '" + serial_no + "'", getConn());
                sql_getUsr = sql_userQuery.ExecuteReader();
                if (sql_getUsr.HasRows == true)
                {
                    isInDB = true;
                }
                this.mysqlConn.Close();
            }
            catch (MySqlException e)
            {
                EventlogAppender.logEvent_error_SQL(e);
            }
            return isInDB;
        }

        public ArrayList getProdInfo(DataRow inRow)
        {
            ArrayList resArr = new ArrayList();

            //Create and Execute SQL statement
            try
            {
                string sql_query = "lagerman.rtGETProductInfo;";

                    MySqlDataReader sql_getProductInfo = null;
                    MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("?inSupplier", MySqlDbType.Int32));
                    cmd.Parameters["?inSupplier"].Value = inRow.ItemArray[0];
                    cmd.Parameters["?inSupplier"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new MySqlParameter("?inProd", MySqlDbType.Int32));
                    cmd.Parameters["?inProd"].Value = inRow.ItemArray[1];
                    cmd.Parameters["?inProd"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new MySqlParameter("?outProd", MySqlDbType.Int32));
                    cmd.Parameters["?outProd"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("?outSupplier", MySqlDbType.Int32));
                    cmd.Parameters["?outSupplier"].Direction = ParameterDirection.Output;

                    sql_getProductInfo = cmd.ExecuteReader();
                    while (sql_getProductInfo.Read())
                    {
                        ArrayList objArr = new ArrayList();
                        objArr.Add(sql_getProductInfo["outProd"]);
                        objArr.Add(sql_getProductInfo["outSupplier"]);
                        resArr.AddRange(objArr);
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return resArr;
        }

        public ArrayList insertBaseStock(DataTable inData)
        {
            ArrayList i = new ArrayList();

            //Create and Execute SQL statement
            try
            {
 
                foreach (DataRow row in inData.Rows) // Loop over the rows.
                {

                    MySqlConnection localConn = getConn();

                    MySqlCommand cmd = localConn.CreateCommand();
                    MySqlTransaction loadTransAct;

                    // Start a local transaction and add parameters
                    loadTransAct = localConn.BeginTransaction();
                    cmd.Connection = getConn();
                    cmd.Transaction = loadTransAct;
                    cmd.Parameters.Add(new MySqlParameter("?prod_grp", MySqlDbType.Int32));
                    cmd.Parameters["?prod_grp"].Value = row.ItemArray[0];
                    cmd.Parameters["?prod_grp"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new MySqlParameter("?prod_id", MySqlDbType.Int32));
                    cmd.Parameters["?prod_id"].Value = row.ItemArray[1];
                    cmd.Parameters["?prod_id"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new MySqlParameter("?serial_no", MySqlDbType.VarChar));
                    cmd.Parameters["?serial_no"].Value = row.ItemArray[2];
                    cmd.Parameters["?serial_no"].Direction = ParameterDirection.Input;

                    cmd.CommandText = "lagerman.rtINSERT_basestock;";
                    cmd.CommandType = CommandType.StoredProcedure;
                    i.Add(cmd.ExecuteNonQuery());
                    loadTransAct.Commit();

                    this.mysqlConn.Close();
                }
                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            return i;
        }

        public ArrayList listInventory()
        {
            ArrayList diffProdNoInStock = new ArrayList();

            //Create and Execute SQL statement
            try
            {
                string sql_query = "SELECT DISTINCT prod_no FROM lagerman.base_stock;";

                MySqlDataReader sql_getProductInfo = null;
                MySqlCommand sql_userQuery = new MySqlCommand(sql_query, getConn());

                sql_getProductInfo = sql_userQuery.ExecuteReader();
                while (sql_getProductInfo.Read())
                {
                    diffProdNoInStock.Add(sql_getProductInfo["prod_no"]);
                }

                this.mysqlConn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return diffProdNoInStock;
        }

        public object countInventory(int inObj)
        {
            object result = null;
            //ArrayList resArr = new ArrayList();

            //Create and Execute SQL statement
            try
            {
                string sql_query = "lagerman.rtGETStockCount;";
                Int64 retval = 0;
                //MySqlDataReader sql_getProductInfo = null;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?inProd", MySqlDbType.Int32));
                cmd.Parameters["?inProd"].Value = inObj;
                cmd.Parameters["?inProd"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?itemCount", MySqlDbType.Int32));
                cmd.Parameters["?itemCount"].Direction = ParameterDirection.Output;
                retval = (Int64)cmd.ExecuteNonQuery();
                result = cmd.Parameters["?itemCount"].Value;
               
                this.mysqlConn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return result;
        }

        public object cnameInventory(int inObj)
        {
            object result = null;
            //ArrayList resArr = new ArrayList();

            //Create and Execute SQL statement
            try
            {

                string sql_query = "lagerman.rtGETStockCname;";

                //MySqlDataReader sql_getProductInfo = null;

                Int64 retval = 0;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?inProd", MySqlDbType.Int32));
                cmd.Parameters["?inProd"].Value = inObj;
                cmd.Parameters["?inProd"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?outCname", MySqlDbType.VarString));
                cmd.Parameters["?outCname"].Direction = ParameterDirection.Output;
                retval = (Int64)cmd.ExecuteNonQuery();
                result = cmd.Parameters["?outCname"].Value;
                this.mysqlConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return result;
        }

        public ArrayList getSuppliers()
        {
            ArrayList suppliers = new ArrayList();
            try
            {
                MySqlDataReader sqlRes = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM lagerman.supplier;", getConn());
                sqlRes = cmd.ExecuteReader();
                while (sqlRes.Read())
                {
                    object[] sqlArr = new object[3];
                    sqlArr[0] = sqlRes["cname_supp"];
                    sqlArr[1] = sqlRes["supplier_id"];
                    sqlArr[2] = sqlRes["group_id"];
                    suppliers.Add(sqlArr);
                }
                this.mysqlConn.Close();
            }
            catch (MySqlException e)
            {
                EventlogAppender.logEvent_error_SQL(e);
            }
            return suppliers;
        }

        public ArrayList getProdGrp()
        {
            ArrayList prodgrp = new ArrayList();
            try
            {
                MySqlDataReader sqlRes = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM lagerman.prodgroup;", getConn());
                sqlRes = cmd.ExecuteReader();
                while (sqlRes.Read())
                {
                    object[] sqlArr = new object[3];
                    sqlArr[0] = sqlRes["id"];
                    sqlArr[1] = sqlRes["group_id"];
                    sqlArr[2] = sqlRes["grp_cname"];
                    prodgrp.Add(sqlArr);
                }
                this.mysqlConn.Close();
            }
            catch (MySqlException e)
            {
                EventlogAppender.logEvent_error_SQL(e);
            }
            return prodgrp;
        }

        public object getProdNameOut(int inObj)
        {
            object result = null;
            try
            {
                string sql_query = "lagerman.rtGETProductInfoByGrp;";
                Int64 retval = 0;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?inProd", MySqlDbType.Int32));
                cmd.Parameters["?inProd"].Value = inObj;
                cmd.Parameters["?inProd"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?outCname", MySqlDbType.VarString));
                cmd.Parameters["?outCname"].Direction = ParameterDirection.Output;
                retval = (Int64)cmd.ExecuteNonQuery();
                result = cmd.Parameters["?outCname"].Value;
                this.mysqlConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return result;
        }

        public object countShipments()
        {
            object result = null;

            //Create and Execute SQL statement
            try
            {
                string sql_query = "warehouse.rtGETShipmentCount;";
                Int64 retval = 0;
                //MySqlDataReader sql_getProductInfo = null;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?itemCount", MySqlDbType.Int32));
                cmd.Parameters["?itemCount"].Direction = ParameterDirection.Output;
                retval = (Int64)cmd.ExecuteNonQuery();
                result = cmd.Parameters["?itemCount"].Value;

                this.mysqlConn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return result;
        }

        public object chklagermanID(int inObj)
        {
            object result = null;
            //ArrayList resArr = new ArrayList();

            //Create and Execute SQL statement
            try
            {
                string sql_query = "warehouse.rtCHKlagermanId;";
                Int64 retval = 0;
                //MySqlDataReader sql_getProductInfo = null;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?inLagermanId", MySqlDbType.Int64));
                cmd.Parameters["?inLagermanId"].Value = inObj;
                cmd.Parameters["?inLagermanId"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?itemCount", MySqlDbType.Int32));
                cmd.Parameters["?itemCount"].Direction = ParameterDirection.Output;
                retval = (Int64)cmd.ExecuteNonQuery();
                result = cmd.Parameters["?itemCount"].Value;

                this.mysqlConn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            return result;
        }

        public void commitShipment(string customerName, string customerStreet, string customerCity, int customerPostCode, Int64 lagermanId, string prodBlob)
        {
            MySqlConnection localConn = getConn();

            MySqlCommand cmd = localConn.CreateCommand();
            MySqlTransaction loadTransAct;

            // Start a local transaction and add parameters
            loadTransAct = localConn.BeginTransaction();
            cmd.Connection = getConn();
            cmd.Transaction = loadTransAct;

            cmd.Parameters.Add(new MySqlParameter("?inLagermanID", MySqlDbType.Int64));
            cmd.Parameters["?inLagermanID"].Value = lagermanId;
            cmd.Parameters["?inLagermanID"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inName", MySqlDbType.VarChar));
            cmd.Parameters["?inName"].Value = customerName;
            cmd.Parameters["?inName"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inStreet", MySqlDbType.VarChar));
            cmd.Parameters["?inStreet"].Value = customerStreet;
            cmd.Parameters["?inStreet"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inCity", MySqlDbType.VarChar));
            cmd.Parameters["?inCity"].Value = customerCity;
            cmd.Parameters["?inCity"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inPostCode", MySqlDbType.Int32));
            cmd.Parameters["?inPostCode"].Value = customerPostCode;
            cmd.Parameters["?inPostCode"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("?inShipmentdetails", MySqlDbType.Text));
            cmd.Parameters["?inShipmentdetails"].Value = prodBlob;
            cmd.Parameters["?inShipmentdetails"].Direction = ParameterDirection.Input;

            try
                {
                    cmd.CommandText = "warehouse.rtLOADShipment;";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    loadTransAct.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        loadTransAct.Rollback();
                    }
                    catch (MySqlException ex)
                    {
                        if (loadTransAct.Connection != null)
                        {
                            EventlogAppender.logEvent_error_SQL(ex.GetType());
                            EventlogAppender.logEvent_error_SQL(ex.StackTrace);
                        }
                    }
                    EventlogAppender.logEvent_error_SQL(e.GetType());
                    EventlogAppender.logEvent_error_SQL(e.StackTrace);
                    MessageBox.Show("StackTrace: " + e.StackTrace, "Error");
                    MessageBox.Show("Message: " + e.Message, "Error");
                }
                this.mysqlConn.Close();
        }

        public void removeFromStock(String serialNo)
        {
            try
            {
                string sql_query = "lagerman.rtDELFromStock;";
                Int64 retval = 0;
                MySqlCommand cmd = new MySqlCommand(sql_query, getConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?inSerial", MySqlDbType.VarChar));
                cmd.Parameters["?inSerial"].Value = serialNo;
                cmd.Parameters["?inSerial"].Direction = ParameterDirection.Input;
                retval = (Int64)cmd.ExecuteNonQuery();
                this.mysqlConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
        }

        public int getProdNoByName(String suppName)
        {
            int rtnVal;
            object sqlVal = null;

            try
            {
                MySqlDataReader sqlRes = null;
                MySqlCommand cmd = new MySqlCommand("SELECT prod_no FROM lagerman.prodcat WHERE suppierName like " + suppName + ";", getConn());
                sqlRes = cmd.ExecuteReader();
               
                while(sqlRes.Read()){
                    sqlVal = sqlRes["prod_no"];
                }
                this.mysqlConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "SQL query error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventlogAppender.logEvent_error_SQL(e);
                Application.Exit();
            }
            this.mysqlConn.Close();
            rtnVal = int.Parse(sqlVal.ToString());
            
            return rtnVal;
            
        }

        
    }
}
