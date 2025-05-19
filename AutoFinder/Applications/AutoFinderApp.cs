using Autodesk.Revit.UI;

namespace AutoFinder
{
    class AutoFinderApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Get List of Models In Place";
            application.CreateRibbonTab(tabName);

            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Auto Finder");

            PushButton buttonShowList = ribbonPanel.AddPushButton<AutoFinderCommand>("Get List of Models In Place");

            buttonShowList.AddImageLarge(Properties.Resources.Icon);

            return Result.Succeeded;
        }
    }
}
