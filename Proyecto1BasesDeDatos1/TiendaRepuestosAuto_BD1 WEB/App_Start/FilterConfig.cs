using System.Web;
using System.Web.Mvc;

namespace TiendaRepuestosAuto_BD1_WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
