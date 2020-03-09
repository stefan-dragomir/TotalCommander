using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace TotalCommander
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private string leftViewPath, rightViewPath;
		public string activeViewPath, inactiveViewPath;
		//private bool AnItemIsSelected;
		private static ListView activeWiew = new ListView();

		public MainWindow()
		{
			InitializeComponent();
			//to implement FOR
			PopulateComboBox(cbDrivesLeft);
			PopulateComboBox(cbDrivesRight);
		}

		private void miAbout_Click(object sender, RoutedEventArgs e)
		{
			About abtWindow = new About();
			abtWindow.Show();
		}

		private void cbDrivesLeft_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string[] Drives = FileUtils.GetDrives().Split('|');
			BuildListView(listLeft, Drives[cbDrivesLeft.SelectedIndex]);
		}

		private void cbDrivesRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string[] Drives = FileUtils.GetDrives().Split('|');
			BuildListView(listRight, Drives[cbDrivesRight.SelectedIndex]);
		}

		private void listLeft_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			OpenDisplayItem(listLeft);
		}

		private void listRight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			OpenDisplayItem(listRight);
		}

		private void listLeft_Loaded(object sender, RoutedEventArgs e)
		{
			activeWiew = listLeft;
			SetActiveViewPath(activeWiew);
		}

		private void listRight_Loaded(object sender, RoutedEventArgs e)
		{
			activeWiew = listRight;
			SetActiveViewPath(activeWiew);
		}
		private void listLeft_GotFocus(object sender, RoutedEventArgs e)
		{
			activeWiew = listLeft;
			SetActiveViewPath(activeWiew);
		}
		private void listRight_GotFocus(object sender, RoutedEventArgs e)
		{
			activeWiew = listRight;
			SetActiveViewPath(activeWiew);
		}

		private void btnNewFolder_Click(object sender, RoutedEventArgs e)
		{

			NewFolder nf = new NewFolder(activeWiew, activeViewPath);
			nf.Show();
		}

		//Generic Functions

		private void PopulateComboBox(ComboBox cb)
		{
			string[] Drives = FileUtils.GetDrives().Split('|');

			foreach (string s in Drives)
			{
				cb.Items.Add(s);
			}

			cb.SelectedIndex = 0;

			BuildListView(listLeft, Drives[cbDrivesLeft.SelectedIndex]);
			BuildListView(listRight, Drives[cbDrivesLeft.SelectedIndex]);
		}

		private void OpenDisplayItem(ListView lv)
		{
			DisplayItem selectedItem = ((DisplayItem)lv.SelectedItem);

			if (selectedItem != null)
			{
				if (selectedItem.IsFile())
					Process.Start(selectedItem.Path);

				if (selectedItem.IsFolder())
					BuildListView(lv, selectedItem.Path);

				SetActiveViewPath(lv);
			}
		}

		public void BuildListView(ListView lv, string path)
		{
			lv.ItemsSource = "";

			DisplayItem dirs = new DisplayItem(path);
			List<DisplayItem> elements = dirs.GetSubElements();

			if (dirs.Path != dirs.GetParent().Path)
				elements.Insert(0, dirs.GetParent());

			lv.ItemsSource = elements;

			if (lv.Name.ToLower().Contains("left"))
				leftViewPath = path;

			if (lv.Name.ToLower().Contains("right"))
				rightViewPath = path;
		}

//private void setViewPaths(ListView lv)
//{
//			if (lv.Name.Contains("left"))
//				leftViewPath = path;

//			if (lv.Name.Contains("right"))
//				rightViewPath = path;

//		}

		private void SetActiveViewPath(ListView lv)
		{
			inactiveViewPath = activeViewPath;

			if (lv.Name.ToLower().Contains("left"))
				activeViewPath = leftViewPath;

			if (lv.Name.ToLower().Contains("right"))
				activeViewPath = rightViewPath;
		}
	}
}