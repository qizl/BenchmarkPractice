using BenchmarkDotNet.Attributes;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace BenchmarkPractice.Nfx
{
    public class TryCatch
    {
        private void operation()
        {
            var text = nameof(TryCatch);

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
        public void NoTryCatch()
        {
            this.operation();
        }

        [Benchmark]
        public void WithTryCatch()
        {
            try
            {
                this.operation();
                //throw new Exception();
            }
            catch (Exception e)
            {
                //var json = JsonConvert.SerializeObject(e);
            }
        }
    }
}
