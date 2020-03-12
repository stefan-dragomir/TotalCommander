using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections.Generic;

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
		private static ListView inactiveWiew = new ListView();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			PopulateComboBox(cbDrivesLeft);
			PopulateComboBox(cbDrivesRight);
		}


//Menu Actions


		private void miCompareContent_Click(object sender, RoutedEventArgs e)
		{
			TextCompare tc;

			if (activeItemPath != null)
			{
				DisplayItem selectedItem = ((DisplayItem)activeWiew.SelectedItem);

				if (selectedItem.IsFile() && selectedItem.GetExtension().ToLower() == "txt")
					tc = new TextCompare(activeItemPath);
				else if (activeViewPath.Length >= 1)
					tc = new TextCompare(activeViewPath);
				else
					tc = new TextCompare();
			}
			else if (activeItemPath != null)
				tc = new TextCompare(activeViewPath);
			else
				tc = new TextCompare();

			tc.Show();
		}

		private void miExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void miAbout_Click(object sender, RoutedEventArgs e)
		{
			About abtWindow = new About();
			abtWindow.Show();
		}


//ComboBoxes Actions


		private void cbDrives_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string[] Drives = FileUtils.GetDrives().Split('|');

			if (sender == cbDrivesLeft)
				BuildListView(listLeft, Drives[cbDrivesLeft.SelectedIndex]);
			else
				BuildListView(listRight, Drives[cbDrivesRight.SelectedIndex]);
		}


//Views Actions


		private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			OpenDisplayItem((ListView)sender);
		}

		private void list_Loaded(object sender, RoutedEventArgs e)
		{
			SetActivePaths((ListView)sender);
		}

		private void list_GotFocus(object sender, RoutedEventArgs e)
		{
			SetActivePaths((ListView)sender);
		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SetActiveSelectionPath((ListView)sender);
		}


//Buttons Actions


		private void btnNewFolder_Click(object sender, RoutedEventArgs e)
		{
			NewFolder();
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			DeleteItem();
		}

		private void btnCopy_Click(object sender, RoutedEventArgs e)
		{
			CloneItem(true);
		}

		private void btnMove_Click(object sender, RoutedEventArgs e)
		{
			CloneItem(false);
		}

//KeyPress Actions

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.Key) {
				case Key.Delete:
					DeleteItem();
					e.Handled = true;
					break;

				case Key.F5:
					CloneItem(true);
					e.Handled = true;
					break;

				case Key.F6:
					CloneItem(false);
					e.Handled = true;
					break;

				case Key.F7:
					NewFolder();
					e.Handled = true;
					break;
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

				SetActivePaths(lv);
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

			SetActivePaths(lv);
		}

		//sets Active / Inactive View paths for copy / move / new file
		private void SetActivePaths(ListView lv)
		{
			if (lv.Name.ToLower().Contains("left"))
			{
				activeViewPath = leftViewPath;
				inactiveViewPath = rightViewPath;

				activeWiew = listLeft;
				inactiveWiew = listRight;
			}
			if (lv.Name.ToLower().Contains("right"))
			{
				activeViewPath = rightViewPath;
				inactiveViewPath = leftViewPath;

				activeWiew = listRight;
				inactiveWiew = listLeft;
			}
		}

		//sets last selected item path for copy / delete / move
		private void SetActiveSelectionPath(ListView lv)
		{
			if (lv.SelectedItems.Count >= 1)
				activeItemPath = ((DisplayItem)lv.SelectedItem).Path;
		}


//File Operations Invoking

		private void NewFolder()
		{
			NewFolder nf = new NewFolder(activeWiew, activeViewPath);
			nf.Show();
		}

		private void DeleteItem()
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

		private void CloneItem(bool keepSource)
		{
			if (activeWiew.SelectedItems.Count >= 1)
			{
				string itemType = "";
				DisplayItem selectedItem = ((DisplayItem)activeWiew.SelectedItem);

				if (selectedItem.IsFile())
					itemType = "file";

				if (selectedItem.IsFolder())
					itemType = "folder";

				FileUtils.Clone(activeItemPath, inactiveViewPath, itemType, keepSource);

				BuildListView(inactiveWiew, inactiveViewPath);
			}
		}

	}
}