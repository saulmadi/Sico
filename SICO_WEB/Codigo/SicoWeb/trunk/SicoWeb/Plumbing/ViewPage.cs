using MvcContrib.FluentHtml;

namespace SicoWeb.Plumbing
{
    public class ViewPage<T> : ModelWebViewPage<T> where T : class 
    {
        public override void Execute()
        {
            
        }
    }


    public class ViewUserControl<T> : MvcContrib.FluentHtml.ModelViewUserControl<T> where T : class
    {
    }

    public class MasterViewControl<T> : MvcContrib.FluentHtml.ModelViewMasterPage<T> where T : class
    {
    }


}