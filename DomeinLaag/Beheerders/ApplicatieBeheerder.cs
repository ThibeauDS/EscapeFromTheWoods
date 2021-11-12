using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace DomeinLaag.Beheerders
{
    public class ApplicatieBeheerder
    {
        #region Methods
#pragma warning disable CA1416 // Validate platform compatibility
        private async Task GenereerBitmap(Bos bos, List<Boom> bomen, List<Aap> apen)
        {
            Bitmap bitmap = new(bos.Xmax - bos.Xmin, bos.Ymax - bos.Ymin);

            Graphics graphics = Graphics.FromImage(bitmap);
            Pen penGroen = new(Color.Green, 1);

            foreach (Boom boom in bomen)
            {
                graphics.DrawEllipse(penGroen, boom.X - 3, boom.Y - 3, 6, 6);
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            bitmap.Save(Path.Combine(path, $"{bos.Id}_EscapeRoute.jpg"), ImageFormat.Jpeg);
        }
#pragma warning restore CA1416 // Validate platform compatibility

        public async Task Process(Bos bos, List<Boom> bomen, List<Aap> apen)
        {
            await GenereerBitmap(bos, bomen, apen);
        }
        #endregion
    }
}
