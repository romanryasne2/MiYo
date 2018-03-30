using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiYo.Models.Converters
{
    public class BinToImageSourceConverter
    {
        /// <summary>
        /// Converts byte array image data to string 
        /// that can be used as src attribute value of img tag.
        /// </summary>
        /// <param name="data">
        /// byte array image
        /// </param>
        /// <returns>
        /// string that can be used as src attribute value of img tag.
        /// </returns>
        public static string Convert(byte[] data)
        {
            string base64 = System.Convert.ToBase64String(data);
            return @String.Format("data: image / png; base64,{0}", base64);
        }
    }
}