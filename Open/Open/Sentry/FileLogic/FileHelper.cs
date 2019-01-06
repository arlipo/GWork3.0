using System.IO;
using Microsoft.AspNetCore.Http;

namespace Open.Sentry.FileLogic {
    public class FileHelper {
        public static byte[] ParseFile(string fileName) {

            byte[] fileContent = null;
            File.SetAttributes(fileName, FileAttributes.Normal);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);

            long byteLength = new FileInfo(fileName).Length;
            fileContent = binaryReader.ReadBytes((int) byteLength);
            fs.Close();
            fs.Dispose();
            binaryReader.Close();
            return fileContent;
        }
        public static byte[] ParseImageToBytes(IFormFile file) {
            byte[] bytes;

            if (file == null) return null;

            using (var binaryReader = new BinaryReader(file.OpenReadStream())) {
                bytes = binaryReader.ReadBytes((int) file.Length);
            }

            return bytes;
        }
    }
}
