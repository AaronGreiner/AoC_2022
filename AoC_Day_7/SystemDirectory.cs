using System.Collections.Generic;

namespace AoC_Day_7
{
    internal class SystemDirectory
    {
        public string Name;
        public SystemDirectory Parent;

        public List<SystemFile> Files = new List<SystemFile>();
        public List<SystemDirectory> Directories = new List<SystemDirectory>();

        public SystemDirectory(SystemDirectory parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        public SystemDirectory GetDirectoryByName(string name)
        {
            foreach (SystemDirectory dir in Directories)
            {
                if (dir.Name == name)
                {
                    return dir;
                }
            }

            return null;
        }

        public int GetTotalSize()
        {
            int total = 0;

            foreach (SystemDirectory dir in Directories)
            {
                total += dir.GetTotalSize();
            }

            foreach (SystemFile file in Files)
            {
                total += file.Size;
            }

            return total;
        }

        public List<SystemDirectory> GetListOfDiectories(int min_size, int max_size)
        {
            List<SystemDirectory> list = new List<SystemDirectory>();

            foreach (SystemDirectory dir in Directories)
            {
                int size = dir.GetTotalSize();

                if (size <= max_size && size >= min_size)
                {
                    list.Add(dir);
                }

                list.AddRange(dir.GetListOfDiectories(min_size, max_size));
            }

            return list;
        }
    }
}
