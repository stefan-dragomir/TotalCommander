using System.Text;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace TotalCommander
{
	class FileUtils
	{
		public static string GetDrives()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			StringBuilder drives = new StringBuilder();

			foreach (DriveInfo di in allDrives)
			{
				if (di.IsReady)
				{
					drives.Append(di.RootDirectory + "|");
				}
			}

			return drives.ToString().Substring(0, drives.Length - 1);
		}

		public static void NewFolder(string path, string folderName)
		{
			DirectoryInfo di = new DirectoryInfo(path);

			if (di.Parent == null)
				Directory.CreateDirectory(path + folderName);
			else
				Directory.CreateDirectory(path + @"\" + folderName);
		}

		public static void Delete(string path, string type)
		{
			DirectoryInfo di = new DirectoryInfo(path);

			if (di.Parent == null)
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
					FileInfo fi = new FileInfo(sourcePath);

					File.Copy(fi.FullName, destinationPath + @"\" + fi.Name);

					if (keepOriginal == false)
						Delete(sourcePath, "file");

					break;
				case "folder":
					DirectoryInfo di = new DirectoryInfo(sourcePath);

					if (di.Parent == null)
						return;
					else
					{
						CopyFolderRecursive(sourcePath, destinationPath);

						if (keepOriginal == false)
							Delete(sourcePath, "folder");
					}

					break;
			}
		}

		private static void CopyFolderRecursive(string sourcePath, string destinationPath)
		{
			DirectoryInfo currentDirectory = new DirectoryInfo(sourcePath);
			NewFolder(destinationPath, currentDirectory.Name);

			string destPath = destinationPath + @"\" + currentDirectory.Name;

			FileInfo[] innerFiles = currentDirectory.GetFiles();

			foreach (FileInfo fi in innerFiles)
				File.Copy(fi.FullName, destPath + @"\" + fi.Name);

			DirectoryInfo[] innerFolders = currentDirectory.GetDirectories();

			foreach (DirectoryInfo di in innerFolders)
				CopyFolderRecursive(di.FullName, destPath);
		}

		public static int Zipper(string sourcePath, string destinationPath, string type, bool unpack = false)
		{
			Process p = new Process();
			string argString;

			if (type.ToLower() == "file")
			{
				FileInfo fi = new FileInfo(sourcePath);

				if (!unpack)
					argString = "a -tzip \"" + destinationPath + "\\" + fi.Name.Replace(fi.Extension, "") + ".zip\"" + " \"" + sourcePath + "\"";
				else
					argString = "e "  + "\"" + sourcePath + "\" -o\"" + destinationPath + "\\" + fi.Name.Replace(fi.Extension, "") + "\" * -r";
			}
			else
			{
				DirectoryInfo di = new DirectoryInfo(sourcePath);
				argString = "a -tzip \"" + destinationPath + "\\" + di.Name + ".zip\"" + " \"" + sourcePath + "\"";
			}

			p.StartInfo.FileName = "C:\\Program Files\\7-Zip\\7z.exe";
			p.StartInfo.Arguments = argString;

			p.Start();
			p.WaitForExit();
			return p.ExitCode;
		}
	}
}
