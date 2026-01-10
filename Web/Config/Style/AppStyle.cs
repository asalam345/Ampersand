using RapidFireLib.UX.Style;
using RapidFireUI.Style;

namespace Web.Config
{
    public class AppStyle : IStyleRF
    {
        public void ComponentStyle(StyleRF style)
        {

        }
        public void ComponentStyle(LayoutFooterRF style)
        {
            style.Type = LayoutFooterType.Thin;
        }
    }
}
