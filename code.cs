using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using Win32borrow;



namespace Win32borrow
{
    public class code
    {
        string st = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //SP_Name: dbo.wsrv_checkadmi
        //SP_Parameter: @id,@pwd
        public string admin_login(string userid, string pwd)  //SP_Name:dbo.wsrv_checkadmi
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_checkadmi @id='{0}', @pwd='{1}';", userid, pwd);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Checkadmi checkadmi = new Checkadmi();
                checkadmi.result = dt.Rows[0][0].ToString();
                checkadmi.msg = dt.Rows[0][1].ToString();
                checkadmi.userid = dt.Rows[0][2].ToString();
                checkadmi.location = dt.Rows[0][3].ToString();

                string result = JsonConvert.SerializeObject(checkadmi);

                return result;
            }


        }

        //SP_Name: dbo.wsrv_login
        //SP_Parameter: @id
        public string reader_login(string field)  //SP_Name:dbo.wsrv_login
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string result = string.Empty;
                string sql = string.Format("exec dbo.wsrv_login @id='{0}', @pwd='', @needpwd=0;", field);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                int s = Convert.ToInt32(dt.Rows[0][0].ToString());

                switch(s)
                {
                    case 0:
                        {
                            Login login = new Login();
                            login.result = dt.Rows[0][0].ToString();
                            login.msg = dt.Rows[0][1].ToString();
                            login.field = dt.Rows[0][13].ToString();
                            login.field = dt.Rows[0][2].ToString();
                            login.field = dt.Rows[0][4].ToString();
                            login.yxrq = dt.Rows[0][29].ToString();
                            login.yyrgnum = Convert.ToInt32(dt.Rows[0][34].ToString());
                            login.fk = Convert.ToSingle(dt.Rows[0][12].ToString());
                            login.tsk = Convert.ToInt32(dt.Rows[0][6].ToString());
                            login.tsy = Convert.ToInt32(dt.Rows[0][7].ToString());
                            login.fsk = Convert.ToInt32(dt.Rows[0][8].ToString());
                            login.fsy = Convert.ToInt32(dt.Rows[0][9].ToString());
                            login.qkk = Convert.ToInt32(dt.Rows[0][10].ToString());
                            login.qky = Convert.ToInt32(dt.Rows[0][11].ToString());

                            result = JsonConvert.SerializeObject(login);
                            return result;
                        }
                    default:
                        {
                            Login login = new Login();
                            login.result = dt.Rows[0][0].ToString();
                            login.msg = dt.Rows[0][1].ToString();
                            result = JsonConvert.SerializeObject(login);
                            return result;
                            

                        }
                }         
               

            }
           
        }

        //SP_Name: dbo.wsrv_borrow
        //SP_Parameter: @field, @field, @field, @field
        public string borrow(string field, string field, string field, string userlocation)
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_borrow @field='{0}', @acce01='{1}', @hist15=0, @autosave=1, @clearborrortmp=1, @field='{2}', @field='{3}';", field, field, field, field);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Borrow borrow = new Borrow();
                borrow.field = dt.Rows[0][0].ToString();
                borrow.msg = dt.Rows[0][1].ToString();
                borrow.field = dt.Rows[0][10].ToString();
                borrow.field = dt.Rows[0][2].ToString();
                borrow.field = dt.Rows[0][4].ToString();
                borrow.field = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                borrow.field = dt.Rows[0][3].ToString() + " 23:59";


                string result = JsonConvert.SerializeObject(borrow);
                return result;
            }

        }

        //SP_Name: 
        //SP_Parameter: @field
        public string hist(string field)
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("select top(25) field,field,field,Convert(varchar(10),field,111) as field,Convert(varchar(10),field,111) as field from table  where field = '{0}' order by field desc;", field);
                DataTable dt = new DataTable();
               
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                string result = JsonConvert.SerializeObject(dt);
                return result;
            }
        }

    }
}
