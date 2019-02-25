using BenchmarkDotNet.Attributes;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BenchmarkPractice.Nfx
{
    public class QrCodes
    {
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
                        b.Save(Path.Combine(Environment.CurrentDirectory, "outputs", "yl", $"{DateTime.Now.ToString("mmssms")}.jpg"), ImageFormat.Jpeg);
                    }
                }
            }
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
                img.Save(Path.Combine(Environment.CurrentDirectory, "outputs", "net", $"{DateTime.Now.ToString("mmssms")}.jpg"), ImageFormat.Jpeg);
            }
        }
    }
}
