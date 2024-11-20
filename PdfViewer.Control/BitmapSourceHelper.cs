using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PdfViewer.Core
{
    internal class BitmapSourceHelper
    {
        public static BitmapSource ConvertImageToBitmapSource(Image image)
        {
            using MemoryStream memoryStream = new();
            // 将 Image 保存到内存流
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            // 创建 BitmapImage 并从内存流加载图像
            memoryStream.Seek(0, SeekOrigin.Begin);  // 将流位置重置为开始
            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
