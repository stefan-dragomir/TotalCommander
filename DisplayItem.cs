using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace TotalCommander
{
	class DisplayItem
	{
        public string Path { get; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime LastChangedDate { get; }
        public string IconURL { get; }

        public DisplayItem(string path)
        {
            this.Path = path;
            this.Name = GetName();
            this.Extension = GetExtension();
            this.LastChangedDate = GetLastChangedDate();

            if (this.IsFile())
                this.IconURL = "resources/icon.png";

            if (this.IsFolder())
                this.IconURL = "resources/folder.png";
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

        public DisplayItem GetParent()
        {
            DisplayItem parent;

            try
            {
                parent = new DisplayItem(Directory.GetParent(Path).ToString());
            }
            catch
            {
                parent = new DisplayItem(Path);
            }

            parent.SetName("Up one level");
            parent.SetExtension("");
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
