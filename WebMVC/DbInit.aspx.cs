using Common.Utils;
using Models;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BLL;

namespace WebMVC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Common.Utils.Utility Util = Common.Utils.Utility.GetInstance();

        InitBLL InitBLL = new InitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            InitBLL.InitDataBase();
            Response.Write("数据库更新成功!");

        }

        private void InitDataBase()
        {
            var db = DbFactory.CreateDbContext();
            InsertEmployee(db);
            int n = db.SaveChanges();
        }

        private void InsertEmployee(DbContext db)
        {
            throw new NotImplementedException();
        }
    }
}