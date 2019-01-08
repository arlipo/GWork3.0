using System.IO;
using Microsoft.AspNetCore.Http;

namespace Open.Sentry.FileLogic {
    public class FileHelper {

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
