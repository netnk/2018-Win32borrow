using System;
using System.Collections.Generic;
using System.Web;
using Win32borrow;

namespace Win32borrow
{
    /// <summary>
    /// Summary description for getservice
    /// </summary>
    public class getservice : IHttpHandler
    {
        Win32borrow.code wc = new Win32borrow.code();

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int mode = Convert.ToInt32(context.Request.QueryString["mode"]);

            switch(mode)
            {
                case 1:
                    {
                        //SP_Parameter: @id,@pwd
                        string userid = context.Request.QueryString["userid"];
                        string pwd = context.Request.QueryString["pwd"];
                        context.Response.Write(wc.admin_login(userid, pwd));
                        break;
                    }
                case 2:  //
                    {
                        //SP_Parameter: @id
                        string readerid = context.Request.QueryString["readerid"];                       
                        context.Response.Write(wc.reader_login(readerid));
                        break;
                    }

                case 3:  //
                    {
                        //SP_Parameter: @reader01, @acce01, @sent05, @hist13
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        context.Response.Write(wc.borrow(field, field, field, field));
                        break;
                    }
                case 5:  //
                    {
                        //SP_Parameter: @readerid
                        string field = context.Request.QueryString["field"];                       
                        context.Response.Write(wc.hist(field));
                        break;
                    }
            }
          


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
