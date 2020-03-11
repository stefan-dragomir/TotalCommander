using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;

namespace TotalCommander
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class TextCompare : Window
	{
		private string InitialFilePath { get; }

		public TextCompare(string filePath = "")
		{
			InitializeComponent();
			this.InitialFilePath = filePath;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			PopulateTextBox(txtPathLeft, InitialFilePath);
		}

		private void btnLoadLeft_Click(object sender, RoutedEventArgs e)
		{
			openFile(txtPathLeft, InitialFilePath);
		}

		private void btnLoadRight_Click(object sender, RoutedEventArgs e)
		{
			openFile(txtPathRight);
		}

		private void btnCompare_Click(object sender, RoutedEventArgs e)
		{
			//on compare button populate big text box with file selected in the small textbox
			//Path.Substring(Path.LastIndexOf(@".") + 1).ToUpper();
			if (txtPathLeft.Text.Length < 1 || txtPathRight.Text.Length < 1)
				System.Windows.MessageBox.Show("Please select two valid text files.", "", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
			else
			{
				FileInfo fiLeft = new FileInfo(txtPathLeft.Text);
				FileInfo fiRight = new FileInfo(txtPathRight.Text);

				if (!fiLeft.Exists || !fiRight.Exists && fiLeft.Extension.ToLower() != "txt" && fiRight.Extension.ToLower() != "txt")
					System.Windows.MessageBox.Show("Please select two valid text files.", "", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
				else
				{
					PopulateTextBox(txtCompareLeft, txtPathLeft.Text, true);
					PopulateTextBox(txtCompareRight, txtPathRight.Text, true);
				}
			}
		}

//Generic Functions

		private void openFile(System.Windows.Controls.TextBox tb, string InitialFilePath = "")
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			if (InitialFilePath.Length >= 1)
				fileDialog.InitialDirectory = InitialFilePath;
			else
				fileDialog.InitialDirectory = @"C:\";
			fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			fileDialog.FilterIndex = 1;
			fileDialog.ShowDialog();

			PopulateTextBox(tb, fileDialog.FileName);
		}

		private void PopulateTextBox(System.Windows.Controls.TextBox tb, string filePath, bool populateWithContent = false)
		{
			if (populateWithContent)
				tb.Text = File.ReadAllText(filePath);
			else
				tb.Text = filePath;
		}

		private void Comparer(System.Windows.Controls.TextBox leftBox, System.Windows.Controls.TextBox rightBox)
		{
			int nrLines = System.Math.Max(leftBox.LineCount, rightBox.LineCount);
			for (int i = 0; i < nrLines; i++)
			{
				//highlighter
			}
		}
	}
}
