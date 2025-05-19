using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AutoFinder.Finders;
using AutoFinder.Writers;
using System.Collections.Generic;
using System.Linq;

namespace AutoFinder
{
    [Transaction(TransactionMode.Manual)]
    public class AutoFinderCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidocument = commandData.Application.ActiveUIDocument;
            Document document = uidocument.Document;

            var collection = GetElements(document);

            // Write a list of element names and their counts from the FamilyInstance collection
            IWriter writer = new WriterElementsNameCount<FamilyInstance>(collection);

            TaskDialog.Show("Model-In-Place елементи", writer.Write());

            return Result.Succeeded;
        }

        // Get elements of the specified type from the document and filter only In-Place families
        private List<FamilyInstance> GetElements(Document document)
        {
            var elements = ElementFinder<FamilyInstance>.FindElements(document);

            elements = elements.Where(c => c.Symbol.Family.IsInPlace).ToList();

            return elements;
        }
    }
}
