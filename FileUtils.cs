using System;
using System.Collections.Generic;
using System.Linq;
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
				Directory.CreateDirectory(path + "\\" + folderName);
		}
		public static void Delete(string path, string type)
		{
			DirectoryInfo d = new DirectoryInfo(path);

			if (d.Parent == null)
				return;
			else
			{
				if (type.ToLower() == "file")
					File.Delete(path);

				if (type.ToLower() == "folder")
					Directory.Delete(path, true);
			}
		}
	}
}
