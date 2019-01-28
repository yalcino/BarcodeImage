using DataMatrix.net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace BarcodeImage
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] args = new string[4];
            //args[0] = @"C:\BarcodeImages\test.jpg";
            //args[1] = "QR";
            //args[2] = "ASA";
            //args[3] = "   123";

            try
            {

                //param 0 = File directory
                //param 1 = DMC or QR info
                //param 2 = BarcodeText

                string StrBarcode = "";
                StrBarcode = StrBarcode + args[2];
                for (int i = 3; i < args.Length; i++) StrBarcode = StrBarcode + " " + args[i];

                if (args[1]=="DMC")
                {
                    DmtxImageEncoder encoder = new DmtxImageEncoder();
                    Bitmap bmp = encoder.EncodeImage(StrBarcode, 100);
                    bmp.Save(args[0], System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                if (args[1] == "QR")
                {
                    QRCodeGenerator QREn = new QRCodeGenerator();
                    var QRData = QREn.CreateQrCode(StrBarcode, QRCoder.QRCodeGenerator.ECCLevel.H);
                    var QRCode = new QRCode(QRData);
                    var Img = QRCode.GetGraphic(20);
                    Img.Save(args[0], System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                //Test
                //string deneme = "ss";
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
