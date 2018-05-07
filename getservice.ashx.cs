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
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        context.Response.Write(wc.admin_login(field, field));
                        break;
                    }
                case 2:  //
                    {
                        //SP_Parameter: @id
                        string field = context.Request.QueryString["field"];                       
                        context.Response.Write(wc.reader_login(field));
                        break;
                    }

                case 3:  //
                    {
                        //SP_Parameter: @field, @field, @field, @field
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        context.Response.Write(wc.borrow(field, field, field, field));
                        break;
                    }

                case 4:  //
                    {
                        //SP_Parameter: @field, @field, @field, @field
                        string field = context.Request.QueryString["field"];
                        string field = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        string field = context.Request.QueryString["field"];
                        string field = context.Request.QueryString["field"];
                        context.Response.Write(wc.book_return(field, field, field, field));
                        break;
                    }

                case 5:  //
                    {
                        //SP_Parameter: @field
                        string field = context.Request.QueryString["field"];                       
                        context.Response.Write(wc.book_hist(field));
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
