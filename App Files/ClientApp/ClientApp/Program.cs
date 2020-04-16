using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    static class Program
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "Client.mdf";
        public static SqlConnection cnx = new SqlConnection(@"Data Source=(localdb)\v11.0;AttachDbFilename="+path+@"\"+databaseName+";Integrated Security=True");
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static DataTable dt;

        public static void OpenCnx()
        {
            if (cnx.State != ConnectionState.Open)
                cnx.Open();
        }
        public static void CloseCnx()
        {
            if (cnx.State != ConnectionState.Closed)
                cnx.Close();
        }
        public static void Excute(string req)
        {
            cmd = new SqlCommand(req, cnx);
            OpenCnx();
            cmd.ExecuteNonQuery();
            CloseCnx();
        }
        public static SqlDataReader FillDataReader(string req)
        {
            cmd = new SqlCommand(req, cnx);
            OpenCnx();
            dr = cmd.ExecuteReader();
            return dr;
        }
        public static void FillTable(string req)
        {
            OpenCnx();
            cmd = new SqlCommand(req, cnx);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            CloseCnx();
        }
        public static void FillDataGridView(DataGridView d,string req)
        {
            FillTable(req);
            d.DataSource = dt;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
