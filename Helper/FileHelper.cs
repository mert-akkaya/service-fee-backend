using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;

namespace Helper
{

    public class FileHelper
    {

        public static List<object> PostUpload(IFormFile file)
        {

            List<object> arr = new List<object>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    
                    while (reader.Read())
                    {
                        var result = new
                        {
                            name = reader.GetValue(0).ToString(),
                            city = reader.GetValue(1).ToString()
                        };
                        arr.Add(result);

                    }
                }
                
            }

            return arr;

        }
    }
}