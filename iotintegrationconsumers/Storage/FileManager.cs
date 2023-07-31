
// C# program to illustrate the usage
// of File.Create(String) method

// Using System, System.IO and
// System.Text namespaces
using System;
using System.IO;
using System.Text;

class FileManager
{
    // Specifying a file path
    static string file_path = @"file.txt";
    public static void FileCreate()
    {
        try
        {
            // Creating a new file, or overwrite
            // if the file already exists.
            using (FileStream fs = File.Create(file_path))
            {
                // Adding some info into the file
                byte[] info = new UTF8Encoding(true).GetBytes("GeeksforGeeks");
                fs.Write(info, 0, info.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static void InsertRecordInFile(string message)
    {
        // Creating a new file, or overwrite
        // if the file already exists.
        using (FileStream fs = File.Open(file_path, FileMode.Append, FileAccess.Write))
        {
            // Adding some info into the file
            byte[] info = new UTF8Encoding(true).GetBytes(message);
            fs.Write(info, 0, info.Length);
        }
    }
    public static string ReadLastRecordDataInFile()
    {
        // Reading the file contents
        using (StreamReader sr = File.OpenText(file_path))
        {
            string lastRecord = "";
            if (sr.ReadLine() != null)
            {
                foreach (string line in sr.ReadLine().Split())
                {
                    lastRecord = line;
                }
            }
            return lastRecord;
        }
    }
    public static void FileDelete()
    {
        FileInfo fi = new FileInfo(file_path);
        long size = fi.Length;
        if(size > 2*1024)
            File.WriteAllText(file_path, String.Empty);
    }
}