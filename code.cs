using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
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
        public string AdminLogin(string field, string field)  //SP_Name:dbo.wsrv_checkadmi
        {
            int UserLogin = ReadLoginTxt(field);  //
            switch (UserLogin)
            {
                case 0:
                    {     
                        using (SqlConnection con = new SqlConnection(st))
                        {
                            con.Open();
                            string sql = string.Format("exec dbo.wsrv_checkadmi @id='{0}', @pwd='{1}';", field, field);
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(sql, con);
                            da.Fill(dt);

                            Checkadmi checkadmi = new Checkadmi();
                            checkadmi.result = dt.Rows[0][0].ToString();
                            if (dt.Rows[0][0].ToString() == "0")  
                            {
                                WriteLoginTxt(field);
                            }
                            checkadmi.msg = dt.Rows[0][1].ToString();
                            checkadmi.field = dt.Rows[0][2].ToString();
                            checkadmi.field = dt.Rows[0][3].ToString();

                            string result = JsonConvert.SerializeObject(checkadmi);
                            return result;
                           
                        }
                       
                    }
                default :
                    {
                        Checkadmi checkadmi = new Checkadmi();
                        checkadmi.result = "9";
                        checkadmi.msg = "ERROR";
                        checkadmi.field = field;
                        checkadmi.field = "";
                        string result = JsonConvert.SerializeObject(checkadmi);
                        return result;
                    }
            }

           


        }

        //SP_Name: dbo.wsrv_login
        //SP_Parameter: @id
        public string ReaderLogin(string field)  //SP_Name:dbo.wsrv_login
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
                            Login field = new Login();
                            login.field = dt.Rows[0][0].ToString();
                            login.msg = dt.Rows[0][1].ToString();
                            result = JsonConvert.SerializeObject(login);
                            return result;
                            

                        }
                }         
               

            }
           
        }

        //SP_Name: dbo.wsrv_borrow
        //SP_Parameter: @field, @field, @field, @field
        public string Borrow(string field, string field, string field, string field)
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_borrow @reader01='{0}', @field='{1}', @field=0, @autosave=1, @clearborrortmp=1, @sent05='{2}', @hist13='{3}';", field, field, field, field);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Borrow borrow = new Borrow();
                borrow.result = dt.Rows[0][0].ToString();
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

        //SP_Name: dbo.wsrv_return
        //SP_Parameter: @field, @field, @field, @field
        public string BookReturn(string field, string returntime, string field, string field)
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("exec dbo.wsrv_return @acce01='{0}', @i1=1, @i2=1, @autosave=1,@hist01 = '{1}', @sent06 = '{2}', @hist14='{3}',@returntype = 1, @stoptype=1;", barcode, returntime, userid, userlocation );
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                Bookreturn book_return = new Bookreturn();
                book_return.result = dt.Rows[0][0].ToString();
                book_return.msg = dt.Rows[0][1].ToString();
                book_return.field = dt.Rows[0][13].ToString();
                book_return.field = dt.Rows[0][2].ToString();
                book_return.field = dt.Rows[0][8].ToString();
                book_return.field = dt.Rows[0][3].ToString() + " 23:59";
                book_return.field = dt.Rows[0][4].ToString();
                book_return.field = dt.Rows[0][19].ToString();
                book_return.field = dt.Rows[0][6].ToString();

                string result = JsonConvert.SerializeObject(book_return);
                return result;
            }
            
        }

        //SP_Name: 
        //SP_Parameter: @field
        public string BookHist(string readerid)
        {
            using (SqlConnection con = new SqlConnection(st))
            {
                con.Open();
                string sql = string.Format("select top(25)  ROW_NUMBER() OVER(ORDER BY sent01 desc) as ' '  ,acce01 '登錄號',hcata12 '題名',cata13 '附件',Convert(varchar(20),sent01,120) as '借出日期',Convert(varchar(20),sent02,120) as '應還日期',Convert(varchar(20),hist01,120) as '歸還日期' from hist where hreader01 = '{0}';", readerid);
                DataTable dt = new DataTable();
               
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                string result = JsonConvert.SerializeObject(dt);
                return result;
            }
        }

        public string WriteLoginTxt(string str)  //
        {
            string path = HttpContext.Current.Server.MapPath("./");
            using (FileStream fs = new FileStream(path + "log.txt", FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(str);
                    return string.Empty;
                }
            }
        }

        public int ReadLoginTxt(string field)  //
        {
            string path = HttpContext.Current.Server.MapPath("./");
            using (FileStream fs = new FileStream(path + "log.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    if(result.IndexOf(field) > -1)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
        }

        public void DeleteLoginTxt(string userid)  //
        {
            string path = HttpContext.Current.Server.MapPath("./");
            using (FileStream fs = new FileStream(path + "log.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    if (result.IndexOf(field) > -1)
                    {
                        sr.Dispose();
                        sr.Close();
                        File.WriteAllText(path + "log.txt", result.Replace(userid+"\r\n", ""));
                    }                   
                }
               
            }
        }

    }
}
