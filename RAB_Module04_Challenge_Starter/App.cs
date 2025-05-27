using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Media.Imaging;

namespace RAB_Module04_Challenge_Starter
{
	internal class App : IExternalApplication
	{
		public Result OnStartup(UIControlledApplication app)
		{
            // Create tab
            string tabname = "Revit Add-in Bootcamp";

            // Create tab and panel - safer version
            try
            {
                app.CreateRibbonTab(tabname);
            }
            catch (Exception error)
            {
                Debug.Print("Tab already exists, using existing panel");
                Debug.Print(error.Message);
                // Tab already exists
            }

            // make panel
            string panelName1 = "Scavenger Hunt";

            RibbonPanel panel = app.CreateRibbonPanel(tabname, panelName1);

            // define buttons. I'm sure theres a way to do this as a method, but I don't know how to do that yet.
            PushButtonData buttonData1 = new PushButtonData(
                "button1",
                "Command 1",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd1");

            PushButtonData buttonData2 = new PushButtonData(
                "button2",
                "Command 2",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd2");

            PushButtonData buttonData3 = new PushButtonData(
                "button3",
                "Command 3",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd3");

            PushButtonData buttonData4 = new PushButtonData(
                "button4",
                "Command 4",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd4");

            PushButtonData buttonData5 = new PushButtonData(
                "button5",
                "Command 5",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd5");

            PushButtonData buttonData6 = new PushButtonData(
                "button6",
                "Command 6",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd6");

            PushButtonData buttonData7 = new PushButtonData(
                "button7",
                "Command 7",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd7");

            PushButtonData buttonData8 = new PushButtonData(
                "button8",
                "Command 8",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd8");

            PushButtonData buttonData9 = new PushButtonData(
                "button9",
                "Command 9",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd9");

            PushButtonData buttonData10 = new PushButtonData(
                "button10",
                "Command 10",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd10");

            // add buttons to panel

            PushButton button1 = panel.AddItem(buttonData1) as PushButton;
            PushButton button2 = panel.AddItem(buttonData2) as PushButton;
            button1.LargeImage = ConvertToImageSource(Properties.Resources.Blue_32);
            button2.LargeImage = ConvertToImageSource(Properties.Resources.Red_32);

            // add stacked row
            panel.AddStackedItems(buttonData3,buttonData4,buttonData5);
            buttonData3.Image = ConvertToImageSource(Properties.Resources.Yellow_16);
            buttonData4.Image = ConvertToImageSource(Properties.Resources.Green_16);
            buttonData5.Image = ConvertToImageSource(Properties.Resources.Red_16);

            // add slit button
            SplitButtonData splitButtonData = new SplitButtonData("SplitButton",
                "Split\rButton");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(buttonData6);
            splitButton.AddPushButton(buttonData7);

            PulldownButtonData pulldownButtonData = new PulldownButtonData("PulldownButton",
                "Pulldown\rButton");
            pulldownButtonData.LargeImage = ConvertToImageSource(Properties.Resources.Yellow_32);
            PulldownButton pulldownButton = panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.AddPushButton(buttonData8);
            pulldownButton.LargeImage = ConvertToImageSource(Properties.Resources.Blue_32);
            pulldownButton.Image = ConvertToImageSource(Properties.Resources.Blue_16);
            buttonData8.LargeImage = ConvertToImageSource(Properties.Resources.Yellow_32);
            buttonData8.Image = ConvertToImageSource(Properties.Resources.Yellow_16);
            pulldownButton.AddPushButton(buttonData9);
            pulldownButton.AddPushButton(buttonData10);

            return Result.Succeeded;
		}

		public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}

        public BitmapImage ConvertToImageSource(byte[] imageData)
        {
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                stream.Position = 0; // Reset the stream position to the beginning
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
        }
    }

}
