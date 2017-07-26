using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OrderLable
{
    public class OrderLabelLogic
    {
        public static OrderLabel GetModel()
        {
            OrderLabel orderLable = new OrderLabel();
            orderLable.PatName = "张小三";
            orderLable.PatSex = "男";
            orderLable.IpNo = "234334";
            orderLable.PatAge = "12岁";
            orderLable.BedNo = "01床";
            orderLable.ItemList = new List<Item> 
            { 
                new Item { ItemName = "王老吉", Quantity = "250ML" }, 
                new Item { ItemName = "清补凉", Quantity = "一包" } 
            };
            orderLable.QrCode = ImageToBytes(Image.FromFile("Images/qrCode.png"));
            orderLable.Freq = "bid";
            orderLable.Seq = "①";
            orderLable.ExecDate = "2017-07-25";
            orderLable.UsageName = "静脉滴注";
            return orderLable;
        }

        private static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
