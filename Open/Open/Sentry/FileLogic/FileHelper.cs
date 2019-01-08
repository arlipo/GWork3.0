using System.IO;
using Microsoft.AspNetCore.Http;

namespace Open.Sentry.FileLogic {
    public class FileHelper {

        public static (byte[], string) ParseImageToBytes(IFormFile file) {
            byte[] bytes;
            var name = "";
            if (file == null) return (null, name);
            name = file.FileName;

            using (var binaryReader = new BinaryReader(file.OpenReadStream())) {
                bytes = binaryReader.ReadBytes((int) file.Length);
            }

            return (bytes, name);
        }
    }
}
