using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OrderLable
{
    public class OrderLabel
    {
        public string PatName { get; set; }
        public string PatSex { get; set; }
        public string IpNo { get; set; }
        public string PatAge { get; set; }
        public string BedNo { get; set; }
        public Byte[] QrCode { get; set; }
        public List<Item> ItemList { get; set; }
        public string Freq { get; set; }
        public string Seq { get; set; }
        public string ExecDate { get; set; }
        public string UsageName { get; set; }

    }
}
