using MvcContrib.FluentHtml.Behaviors;
using MvcContrib.FluentHtml.Elements;

namespace SicoWeb.Plumbing
{
    public class LowercaseFirstCharacterOfNameBehaviour : IBehavior<IMemberElement>
    {
        public void Execute(IMemberElement element)
        {
            string name = null;
            if (!element.Builder.Attributes.TryGetValue("name", out name) || string.IsNullOrEmpty(name)) return;
            name = name[0].ToString().ToLower() + name.Substring(1);
            element.Builder.MergeAttribute("name", name, true);
        }
    }
}