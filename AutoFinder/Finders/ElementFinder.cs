using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace AutoFinder.Finders
{
    static class ElementFinder<T> where T : Element
    {
        //Find collection of special elements
        public static List<T> FindElements(Document document) 
        {
            var elements = new FilteredElementCollector(document)
                .OfClass(typeof(T))
                .Cast<T>()
                .ToList();
            return elements;
        }
    }
}
