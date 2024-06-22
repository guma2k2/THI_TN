using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace THI_TN
{
    internal static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static String constr_publisher = "Data Source=MSI\\THUAN;Initial Catalog=THI_TN;Integrated Security=True";
        public static SqlDataAdapter da;
        public static SqlDataReader myReader;


        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";

        public static String mLoginDN = "";
        public static String passwordDN = "";

        public static String database = "THI_TN";
        public static String remoteLogin = "HTKN";
        public static String remotePassowrd = "123456";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mChiNhanh = 0;

        public static BindingSource bds_dspm = new BindingSource();

        public static frmMain mainForm;


        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open) Program.conn.Close();
            Console.WriteLine(Program.mlogin);
            Console.WriteLine(Program.password);

            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String cmd)
        {
            SqlDataReader myreader;
            //Program.conn = new SqlConnection(connectionstring);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.conn;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecSqlQuery(String cmd)
        {
            DataTable dt1 = new DataTable();
            conn = new SqlConnection(Program.connstr);
            da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt1);
            return dt1;

        }

        public static int CheckDataHelper(string query)
        {
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any rows
                        if (reader.HasRows)
                        {
                            // Read the first (and presumably only) row
                            reader.Read();

                            // Check if the "ReturnValue" column exists in the result
                            if (reader.FieldCount > 0 && reader.GetName(0) == "Return Value")
                            {
                                // Get the value from the "ReturnValue" column
                                int returnValue = Convert.ToInt32(reader["Return Value"]);
                                Console.WriteLine(returnValue);
                                return returnValue;
                            }
                        }
                    }
                }
            }

            return -1;
        }



        public static int ExecSqlNonQuery(String cmd)
        {
            String connectionstring = Program.connstr;
            conn = new SqlConnection(connectionstring);
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = conn;
            Sqlcmd.CommandText = cmd;
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 300;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {

                Sqlcmd.ExecuteNonQuery(); conn.Close(); return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return 0;
            }
        }

      
        public static void SetEnableOfButton(Form frm, Boolean Active)
        {

            foreach (Control ctl in frm.Controls)
                if ((ctl) is Button)
                    ctl.Enabled = Active;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new frmMain();
            Application.Run(new frmLogin());
        }
    }
}
