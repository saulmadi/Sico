namespace SicoWeb.Plumbing
{
    public class ViewPage<T> : MvcContrib.FluentHtml.ModelViewPage<T> where T : class 
    {
        public ViewPage():base ()
        {
            
        }
    }


    public class ViewUserControl<T> : MvcContrib.FluentHtml.ModelViewUserControl<T> where T : class
    {
        public ViewUserControl()
            : base(new LowercaseFirstCharacterOfNameBehaviour())
        {

        }
    }
}