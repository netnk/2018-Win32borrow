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
                case 1:  //
                    {
                        //SP_Parameter: @id,@pwd
                        string userid = context.Request.QueryString["userid"];
                        string pwd = context.Request.QueryString["pwd"];                      
                        context.Response.Write(wc.AdminLogin(userid, pwd));
                        
                        break;
                    }
                case 2:  //
                    {
                        //SP_Parameter: @id
                        string field = context.Request.QueryString["field"];                       
                        context.Response.Write(wc.ReaderLogin(field));
                        break;
                    }

                case 3:  //
                    {
                        //SP_Parameter: @field, @field, @field, @field
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        field = HttpUtility.UrlDecode(field);
                        string field = context.Request.QueryString["field"];
                        field = HttpUtility.UrlDecode(field);
                        context.Response.Write(wc.Borrow(field, field, field, field));
                        break;
                    }

                case 4:  //
                    {
                        //SP_Parameter: @field, @field, @field, @field
                        string field = context.Request.QueryString["field"];
                        string field = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        field = HttpUtility.UrlDecode(field);
                        context.Response.Write(wc.BookReturn(field, field, field, field));
                        break;
                    }

                case 5:  //
                    {
                        //SP_Parameter: @readerid
                        string field = context.Request.QueryString["field"];                       
                        context.Response.Write(wc.BookHist(field));
                        break;
                    }

                case 6:  //
                    {
                        string field = context.Request.QueryString["field"];
                        wc.DeleteLoginTxt(field);
                        context.Response.Write("OK!!");
                        break;
                    }

                case 99:  //測試用
                    {
                        string field = context.Request.QueryString["id"];
                        int a = wc.ReadLoginTxt(field);
                        context.Response.Write(a);
                        break;
                    }

                default:
                    {
                        context.Response.Write("");
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
