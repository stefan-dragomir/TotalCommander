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
		private string activeViewPath;
		public NewFolder(ListView lv, string incommingPath)
		{
			InitializeComponent();
			this.activeViewPath = incommingPath;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			FileUtils.NewFolder(activeViewPath, txtNewFolderName.Text);
			this.Close();
		}
	}
}
