using System.Web;
using System.Web.Mvc;

namespace aspnetmvc_simple_app
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
