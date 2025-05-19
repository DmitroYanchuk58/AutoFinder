using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Text;

namespace AutoFinder.Writers
{
    public class WriterElements<T> : IWriter where T : Element
    {
        private List<T> Elements;

        public WriterElements(List<T> elements)
        {
            this.Elements = elements;
        }

        //Check count of elements and write count of all collection's elements
        public virtual string Write()
        {
            StringBuilder result = new StringBuilder();
            if (Elements.Count == 0) 
            {
                return "У файлі не знайдено ні одного Model-In-Place.";
            }
            result.AppendLine($"Знайдено {Elements.Count} Model-In-Place елементів:\n");
            return result.ToString();
        }
    }
}
