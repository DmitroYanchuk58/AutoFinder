# AutoFinder
📄 How to Use the "AutoFinder" Revit Add-in
Follow these steps to install and run your Revit add-in correctly:

1. 🔧 Modify the .addin File
Open the .addin file included with your project and update the Assembly path to point to the compiled .dll file on your computer.

Example:
<Assembly>C:\Path\To\Your\Compiled\DLL\AutoFinder.dll</Assembly>

Make sure the path is correct and points to the actual location of your built DLL.


2. 📁 Place the .addin File in the Revit Add-ins Folder
Copy your modified .addin file to the Revit Add-ins folder corresponding to your Revit version:

C:\ProgramData\Autodesk\Revit\Addins\2023

Replace 2023 with your version of Revit, if different.

3. ▶️ Run Revit and Open a Test Project
Start Autodesk Revit.
Select Get List of Models in Place ribbon panel.
Click on Get List of Models in Place button.
See a list of models in place elements
