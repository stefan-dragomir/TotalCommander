using System;
using System.Collections.Generic;
using System.IO;

namespace TotalCommander
{
	class DisplayItem
	{
		public string Path { get; }
		public string Name { get; set; }
		public string Extension { get; set; }
		public DateTime LastChangedDate { get; }
		public string IconURL { get; set; }

		public DisplayItem(string path)
		{
			this.Path = path;
			this.Name = GetName();
			this.Extension = GetExtension();
			this.LastChangedDate = GetLastChangedDate();
			this.IconURL = GetImage();
		}

		public string GetName()
		{
			return Path.Substring(Path.LastIndexOf(@"\") + 1);
		}
		private void SetName(string name)
		{
			this.Name = name;
		}

		public string GetExtension()
		{
			if (IsFile())
			{
				if (Path.Contains("."))
					return Path.Substring(Path.LastIndexOf(@".") + 1).ToUpper();
				else
					return GetName();
			}
			else
				return "<DIR>";
		}
		private void SetExtension(string extension)
		{
			this.Extension = extension;
		}

		public DateTime GetLastChangedDate()
		{
			return Directory.GetLastWriteTime(Path);
		}

		private string GetImage()
		{

			if (this.Name == "Up one level")
				return "resources/up.png";
			else if (this.IsFolder())
				return "resources/folder.png";
			else
				return "resources/icon.png";
		}

		private void SetImage()
		{

			if (this.Name == "Up one level")
				this.IconURL = "resources/up.png";
			else if (this.IsFolder())
				this.IconURL = "resources/folder.png";
			else
				this.IconURL = "resources/icon.png";
		}

		public DisplayItem GetParent()
		{
			DisplayItem parent;

			if (Directory.GetParent(Path) != null)
				parent = new DisplayItem(Directory.GetParent(Path).ToString());
			else
				parent = new DisplayItem(Path);


			parent.SetName("Up one level");
			parent.SetExtension("");
			parent.SetImage();

			return parent;
		}

		public List<DisplayItem> GetSubElements()
		{
			List<DisplayItem> elements = new List<DisplayItem>();
			string[] dirs, files;

			try
			{
				dirs = Directory.GetDirectories(Path);
				files = Directory.GetFiles(Path);
			}
			catch
			{
				return elements;
			}

			foreach (var item in dirs)
			{
				elements.Add(new DisplayItem(item));
			}

			foreach (var item in files)
			{
				elements.Add(new DisplayItem(item));
			}

			return elements;
		}

		public bool IsFile()
		{
			FileAttributes attr = File.GetAttributes(Path);

			if (attr.HasFlag(FileAttributes.Directory))
				return false;
			else
				return true;
		}

		public bool IsFolder()
		{
			FileAttributes attr = File.GetAttributes(Path);

			if (attr.HasFlag(FileAttributes.Directory))
				return true;
			else
				return false;
		}
	}
}
