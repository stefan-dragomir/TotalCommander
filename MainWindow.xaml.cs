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

		private string CurrentPath, PreviousPath;
		private bool AnItemIsSelected;

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

		//Generic Functions

		private void ChangeFocusedPaths(DisplayItem item)
		{
			PreviousPath = CurrentPath;
			//PreviousPathParent = CurrentPathParent;

			CurrentPath = item.Path;
			//CurrentPathParent = item.GetParent().Path;
		}

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
			}
		}

		private void BuildListView(ListView lv, string path)
		{
			lv.ItemsSource = "";

			DisplayItem dirs = new DisplayItem(path);
			List<DisplayItem> elements = dirs.GetSubElements();

			if (dirs.Path != dirs.GetParent().Path)
				elements.Insert(0, dirs.GetParent());

			lv.ItemsSource = elements;

			ChangeFocusedPaths(dirs);
			AnItemIsSelected = false;
		}

		private void listLeft_GotFocus(object sender, RoutedEventArgs e)
		{

		}

		private void listLeft_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listLeft.SelectedItems.Count >= 1)
			{
				DisplayItem selectedItem = ((DisplayItem)listLeft.SelectedItem);
				ChangeFocusedPaths(selectedItem);
				AnItemIsSelected = true;
			}
		}
		private void listRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listRight.SelectedItems.Count >= 1)
			{
				DisplayItem selectedItem = ((DisplayItem)listRight.SelectedItem);
				ChangeFocusedPaths(selectedItem);
				AnItemIsSelected = true;
			}
		}

		private void btnNewFolder_Click(object sender, RoutedEventArgs e)
		{
			if (AnItemIsSelected)
			{
				FileUtils.NewFolder(PreviousPath);
				if (listLeft.GotFocus)
					BuildListView(listLeft, PreviousPath);
				if (listRight.GotFocus)
					BuildListView(listRight, PreviousPath);
			}
			else
			{
				FileUtils.NewFolder(CurrentPath);
				if (listLeft.MouseLeftButtonUp)
					BuildListView(listLeft, PreviousPath);
				if (listRight.GotFocus)
					BuildListView(listRight, PreviousPath);
			}


		}
	}
}