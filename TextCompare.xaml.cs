using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Documents;
using static System.Math;

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
			txtPathLeft.Text = InitialFilePath;
		}

		private void btnLoadLeft_Click(object sender, RoutedEventArgs e)
		{
			OpenFile(txtPathLeft, InitialFilePath);
		}

		private void btnLoadRight_Click(object sender, RoutedEventArgs e)
		{
			OpenFile(txtPathRight);
		}

		private void btnCompare_Click(object sender, RoutedEventArgs e)
		{
			//on compare button populate big text box with file selected in the small textbox
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
					//DoTheMagicHere
					Compare(txtCompareLeft, txtCompareRight, txtPathLeft.Text, txtPathRight.Text);
				}
			}
		}

		private void txtCompareRight_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
		{
			txtCompareLeft.ScrollToVerticalOffset(txtCompareRight.VerticalOffset);
		}

		private void txtCompareLeft_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
		{
			txtCompareRight.ScrollToVerticalOffset(txtCompareLeft.VerticalOffset);
		}

//Generic Functions

		private void OpenFile(System.Windows.Controls.TextBox tb, string InitialFilePath = "")
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			if (InitialFilePath.Length >= 1)
				fileDialog.InitialDirectory = InitialFilePath;
			else
				fileDialog.InitialDirectory = @"C:\";

			fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			fileDialog.FilterIndex = 1;
			fileDialog.ShowDialog();

			tb.Text = fileDialog.FileName;
		}


//maybe prettify the below code
//if i still have time


		private void Compare(System.Windows.Controls.RichTextBox leftBox, System.Windows.Controls.RichTextBox rightBox, string leftFilePath, string rightFilePath)
		{

			//All the below code was adapted from the official Microsoft c# docs.
			//Apparently one does not simply add some line of text in a TextBox, select it, and color it.
			//Nooo, too simple...

			string[] leftCache = File.ReadAllLines(leftFilePath);
			string[] rightCache = File.ReadAllLines(rightFilePath);

			int nrLines = Max(leftCache.Length, rightCache.Length);

			int fontSize = (int)leftBox.FontSize / 2;
			int lineLength = 1;

			Run textRunLeft = new Run();
			Run textRunRight = new Run();

			Paragraph pgLeft = new Paragraph();
			Paragraph pgRight = new Paragraph();

			leftBox.Document.Blocks.Clear();
			rightBox.Document.Blocks.Clear();

			for (int i = 0; i < nrLines; i++)
			{
				if (i < leftCache.Length && i < rightCache.Length)
				{
					lineLength = Max(lineLength, Max(leftCache[i].Length, rightCache[i].Length));

					//Make a run of text to hold the read line
					textRunLeft = new Run(leftCache[i] + System.Environment.NewLine);
					textRunRight = new Run(rightCache[i] + System.Environment.NewLine);

					//Define Color for the Run of text
					textRunLeft.Background = null;
					textRunRight.Background = null;

					if (leftCache[i] != rightCache[i])
					{
						textRunLeft.Background = Brushes.Yellow;
						textRunRight.Background = Brushes.Yellow;
					}
				}
				else
				{
					if (i >= leftCache.Length)
					{
						lineLength = Max(lineLength, rightCache[i].Length);

						textRunLeft = new Run(System.Environment.NewLine);
						textRunRight = new Run(rightCache[i] + System.Environment.NewLine);

						textRunLeft.Background = null;
						textRunRight.Background = Brushes.Yellow;
					}

					if (i >= rightCache.Length)
					{
						lineLength = Max(lineLength, leftCache[i].Length);

						textRunLeft = new Run(leftCache[i] + System.Environment.NewLine);
						textRunRight = new Run(System.Environment.NewLine);

						textRunLeft.Background = Brushes.Yellow;
						textRunRight.Background = null;
					}
				}
				//Use a Paragraph to contain the runs of text
				pgLeft.Inlines.Add(textRunLeft);
				pgRight.Inlines.Add(textRunRight);
			}

			//Finally populate the RichTextBox with some text
			leftBox.Document.Blocks.Add(pgLeft);
			rightBox.Document.Blocks.Add(pgRight);

			//And set a big width, couldn't find a Wrap option...
			leftBox.Document.PageWidth = (lineLength * fontSize);
			rightBox.Document.PageWidth = (lineLength * fontSize);
		}
	}
}