using BenchmarkDotNet.Attributes;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

namespace BenchmarkPractice.Nfx
{
    public class QrCodes
    {
        private static string ylfolders = Path.Combine(Environment.CurrentDirectory, "outputs", "yl");
        private static string qrCodeNetfolders = Path.Combine(Environment.CurrentDirectory, "outputs", "qrcodenet");
        private static string zxingNetfolders = Path.Combine(Environment.CurrentDirectory, "outputs", "zxingnet");

        public static void Init()
        {
            if (!Directory.Exists(zxingNetfolders)) Directory.CreateDirectory(zxingNetfolders);
            if (!Directory.Exists(qrCodeNetfolders)) Directory.CreateDirectory(qrCodeNetfolders);
            if (!Directory.Exists(ylfolders)) Directory.CreateDirectory(ylfolders);
        }

        [Benchmark]
        public void ZXingNet()
        {
            var text = nameof(ZXingNet);

            var barCodeWriter = new BarcodeWriter();
            barCodeWriter.Format = BarcodeFormat.QR_CODE;
            barCodeWriter.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            barCodeWriter.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
            barCodeWriter.Options.Height = 100;
            barCodeWriter.Options.Width = 100;
            barCodeWriter.Options.Margin = 0;
            var bm = barCodeWriter.Encode(text);
            var b = barCodeWriter.Write(bm);
            //b.Save(Path.Combine(zxingNetfolders, $"{DateTime.Now.ToString("mmssms")}.jpg"), ImageFormat.Jpeg);
        }

        [Benchmark]
        public void QrCodeNet()
        {
            var text = nameof(QrCodes);

            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var code = new QrCode();
            qrEncoder.TryEncode(text, out code);
            const int modelSizeInPixels = 4;

            var render = new GraphicsRenderer(new FixedModuleSize(modelSizeInPixels, QuietZoneModules.Two), Brushes.Black, Brushes.White);

            using (var ms = new MemoryStream())
            {
                render.WriteToStream(code.Matrix, ImageFormat.Jpeg, ms);
                var img = Image.FromStream(ms);
                //img.Save(Path.Combine(netfolders, $"{DateTime.Now.ToString("mmssms")}.jpg"), ImageFormat.Jpeg);
            }
        }

        [Benchmark]
        public void YlQrCode()
        {
            var text = nameof(QrCodes);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.L))
                {
                    using (QRCode qrcode = new QRCode(qrCodeData))
                    {
                        var b = qrcode.GetGraphic(20, Color.Black, Color.White, null, 15, 6, false);
                        //b.Save(Path.Combine(ylfolders, $"{DateTime.Now.ToString("mmssms")}.jpg"), ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}
