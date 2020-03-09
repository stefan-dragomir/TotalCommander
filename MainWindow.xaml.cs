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
		public string activeViewPath, inactiveViewPath, activeItemPath;
		//private bool AnItemIsSelected;
		private static ListView activeWiew = new ListView();

		public MainWindow()
		{
			InitializeComponent();
			//to implement FOR
			PopulateComboBox(cbDrivesLeft);
			PopulateComboBox(cbDrivesRight);
		}

//Menu Actions

		private void miAbout_Click(object sender, RoutedEventArgs e)
		{
			About abtWindow = new About();
			abtWindow.Show();
		}

//ComboBoxes Actions

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

//Views Actions

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

		private void listLeft_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SetActiveSelectionPath(listLeft);
		}

		private void listRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SetActiveSelectionPath(listRight);
		}

//Buttons Actions

		private void btnNewFolder_Click(object sender, RoutedEventArgs e)
		{
			NewFolder nf = new NewFolder(activeWiew, activeViewPath);
			nf.Show();
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (activeWiew.SelectedItems.Count >= 1)
			{
				string itemType = "";
				DisplayItem selectedItem = ((DisplayItem)activeWiew.SelectedItem);

				if (selectedItem.IsFile())
					itemType = "file";

				if (selectedItem.IsFolder())
					itemType = "folder";

				MessageBoxResult confirmDelete = MessageBox.Show("Are you sure to delete this item?", "Confrm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (confirmDelete == MessageBoxResult.Yes)
				{
					FileUtils.Delete(activeItemPath, itemType);
					BuildListView(activeWiew, activeViewPath);
				}
			}
		}

		private void btnCopy_Click(object sender, RoutedEventArgs e)
		{
			if (activeWiew.SelectedItems.Count >= 1)
			{
				string itemType = "";
				DisplayItem selectedItem = ((DisplayItem)activeWiew.SelectedItem);

				if (selectedItem.IsFile())
					itemType = "file";

				if (selectedItem.IsFolder())
					itemType = "folder";

				FileUtils.Clone(activeItemPath, inactiveViewPath, itemType, true);
			}
		}

		private void btnMove_Click(object sender, RoutedEventArgs e)
		{
			if (activeWiew.SelectedItems.Count >= 1)
			{
				string itemType = "";
				DisplayItem selectedItem = ((DisplayItem)activeWiew.SelectedItem);

				if (selectedItem.IsFile())
					itemType = "file";

				if (selectedItem.IsFolder())
					itemType = "folder";

				FileUtils.Clone(activeItemPath, inactiveViewPath, itemType, false);
			}
		}

//Generic Functions

		//Populates Combo Boxes with drives found.
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

		//opens item. expands directory / launches file.
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

		//builds a list view with all the elements found in a directory
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

		//sets Active / last active View paths for copy / move / new file
		private void SetActiveViewPath(ListView lv)
		{
			inactiveViewPath = activeViewPath;

			if (lv.Name.ToLower().Contains("left"))
				activeViewPath = leftViewPath;

			if (lv.Name.ToLower().Contains("right"))
				activeViewPath = rightViewPath;
		}

		//sets last selected item path for copy / delete / move
		private void SetActiveSelectionPath(ListView lv)
		{
			if (lv.SelectedItems.Count >= 1)
				activeItemPath = ((DisplayItem)lv.SelectedItem).Path;
		}
	}
}