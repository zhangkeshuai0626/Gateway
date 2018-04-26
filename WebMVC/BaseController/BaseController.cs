using System.Web.Mvc;
using Models.AppModels;
using Common.Utils;

namespace DFlow.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        /// <summary>
        /// 工具类
        /// </summary>
        public Common.Utils.Util Util = Common.Utils.Util.GetInstance();

        /// <summary>
        /// 返回当前用户登陆信息
        /// </summary>
        public LoginSessionModel LoginInfo
        {
            get
            {
                object obj = SessionHelper.Get(Key.SessionKey.LoginInfo);
                if (obj != null)
                {
                    return obj as LoginSessionModel;
                }
                return null;
            }
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult Detail()
        {
            return View();
        }
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