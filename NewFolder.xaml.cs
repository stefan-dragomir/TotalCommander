using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TotalCommander
{
	/// <summary>
	/// Interaction logic for NewFolder.xaml
	/// </summary>
	public partial class NewFolder : Window
	{
		private ListView activeListView;
		private string activeViewPath;
		public NewFolder(ListView lv, string incommingPath)
		{
			InitializeComponent();
			this.activeViewPath = incommingPath;
			this.activeListView = lv;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			FileUtils.NewFolder(activeViewPath, txtNewFolderName.Text);
			BuildListView(activeListView, activeViewPath);
			this.Close();
		}

		public void BuildListView(ListView lv, string path)
		{
			lv.ItemsSource = "";

			DisplayItem dirs = new DisplayItem(path);
			List<DisplayItem> elements = dirs.GetSubElements();

			if (dirs.Path != dirs.GetParent().Path)
				elements.Insert(0, dirs.GetParent());

			lv.ItemsSource = elements;
		}
	}
}
