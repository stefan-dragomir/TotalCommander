using System.Text;
using System.IO;

namespace TotalCommander
{
	class FileUtils
	{
		public static string GetDrives()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			StringBuilder drives = new StringBuilder();

			foreach (DriveInfo d in allDrives)
			{
				if (d.IsReady)
				{
					drives.Append(d.RootDirectory + "|");
				}
			}

			return drives.ToString().Substring(0, drives.Length - 1);
		}

		public static void NewFolder(string path, string folderName)
		{
			DirectoryInfo d = new DirectoryInfo(path);

			if (d.Parent == null)
				Directory.CreateDirectory(path + folderName);
			else
				Directory.CreateDirectory(path + @"\" + folderName);
		}

		public static void Delete(string path, string type)
		{
			DirectoryInfo d = new DirectoryInfo(path);

			if (d.Parent == null)
				return;
			else
			{
				switch (type.ToLower()) {
					case "file":
						File.Delete(path);
						break;
					case "folder":
						Directory.Delete(path, true);
						break;
				}
			}
		}

		public static void Clone(string sourcePath, string destinationPath, string type, bool keepOriginal = true)
		{
			switch (type.ToLower())
			{
				case "file":
					if (keepOriginal == false)
						File.Move(sourcePath, destinationPath);
					else
						File.Copy(sourcePath, destinationPath);

					break;
				case "folder":
					DirectoryInfo d = new DirectoryInfo(sourcePath);
					if (d.Parent == null)
						return;
					else
					{
						if (keepOriginal == false)
							//will not work across volumes
							Directory.Move(sourcePath, destinationPath);
						//else
							//Figure Out Copying
							//Directory.Move(sourcePath, destinationPath);
					}

					break;
			}
		}
	}
}
