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
	}
}
