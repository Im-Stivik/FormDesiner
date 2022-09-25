using System.IO;

namespace FormDesiner
{
    public class FileMennager
    {
        public static string designerFile;
        public static string scriptFile;
        
        public static bool isFileValid(string file)
        {
            if (file == null || file == "")
                return false;
            if (!File.Exists(file))
                return false;
            //check if the file dont have a .designer.cs extension
            if (file.Substring(file.Length - 13) != ".designer.cs")
                return false;
            //check if the file dont have windows region in it
            if (!File.ReadAllText(file).Contains("#region Windows Form Designer generated code"))
                return false;
            return true;
        }
        
        public static bool WriteItemsToFile(ItemMennager.Item[] items)
        {
            //TODO: implement this
            return false;
        }
    }
}