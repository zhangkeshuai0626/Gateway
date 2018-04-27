using System.Web.Mvc;
using Common.Utils;
using Common.AppModel;
using Models.DbModels;

namespace DFlow.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        /// <summary>
        /// 工具类
        /// </summary>
        public Common.Utils.Utility Util = Common.Utils.Utility.GetInstance();

        /// <summary>
        /// 返回当前用户登陆信息
        /// </summary>
        public LoginSessionModel LoginInfo
        {
            get
            {
                object obj = SessionHelper.Get(Enumer.Session.LoginInfo);
                if (obj != null)
                {
                    return obj as LoginSessionModel;
                }
                return null;
            }
        }

        /// <summary>
        /// 默认页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Detail()
        {
            return View();
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Edit()
        {
            return View();
        }

        protected BaseController() : base()
        {
            //初始化菜单
        }
    }

}