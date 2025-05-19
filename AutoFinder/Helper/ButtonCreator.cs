using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System;
using System.Reflection;
using System.IO;

namespace AutoFinder
{
    //static methods for creating button correctly 
    static class ButtonCreator
    {
        public static PushButton AddPushButton<TCommand>(this RibbonPanel panel, string buttonText) where TCommand : IExternalCommand, new()
        {
            Type typeFromHandle = typeof(TCommand);
            PushButtonData itemData = new PushButtonData(typeFromHandle.FullName, buttonText, Assembly.GetAssembly(typeFromHandle).Location, typeFromHandle.FullName);
            return (PushButton)panel.AddItem(itemData);
        }

        public static PushButton AddImageLarge(this PushButton pushButton, byte[] imageBytes)
        {
            pushButton.LargeImage = GetImageSourc(imageBytes);
            return pushButton;
        }

        private static BitmapImage GetImageSourc(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();
                return bitmap;
            }
        }
    }
}
