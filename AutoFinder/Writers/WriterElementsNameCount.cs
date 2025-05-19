using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Text;

namespace AutoFinder.Writers
{
    public class WriterElementsNameCount<T> : WriterElements<T> where T : Element
    {
        private Dictionary<string, int> ElementsAndCount;

        //Sort element's data(name, count) in Dictionary for easier use
        public WriterElementsNameCount(List<T> elements) : base(elements) 
        {
            ElementsAndCount = new Dictionary<string, int>();

            foreach (Element element in elements)
            {
                if (ElementsAndCount.ContainsKey(element.Name))
                    ElementsAndCount[element.Name]++;

                else
                    ElementsAndCount[element.Name] = 1; 
            }
        }

        //Write names of elements and their count
        public override string Write()
        {
            StringBuilder result = new StringBuilder(base.Write());

            if(result.ToString() == "У файлі не знайдено ні одного Model-In-Place.")
                return result.ToString();

            foreach (KeyValuePair<string, int> element in ElementsAndCount)
            {
                result.AppendLine($"Ім'я елементу: {element.Key} || Кількість: {element.Value}");
            }

            return result.ToString();
        }
    }
}
