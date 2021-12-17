using DomeinLaag.Exceptions;
using DomeinLaag.Interfaces;
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
        #region Properties
        private readonly IApplicatieRepository _repository;
        #endregion

        #region Constructors
        public ApplicatieBeheerder(IApplicatieRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public void GenereerDirectorys()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += @"\EscapeFromTheWoods";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                Directory.Delete(path, true);
            }
            string path1 = path + @"\Bitmappen";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            string path2 = path + @"\Tekstbestanden";
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }
        }
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task GenereerBitmap(Bos bos, List<Boom> bomen, List<Aap> apen)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                Console.WriteLine($"Start bitmap - bos{bos.Id}");
                Random random = new();
                Bitmap bitmap = new(bos.Xmax - bos.Xmin, bos.Ymax - bos.Ymin);
                bitmap.SetResolution(150.0F, 150.0F);

                Graphics graphics = Graphics.FromImage(bitmap);
                Pen penGroen = new(Color.DarkGreen, 1);

                graphics.Clear(Color.FromArgb(231, 252, 237));

                foreach (Boom boom in bomen)
                {
                    graphics.DrawEllipse(penGroen, boom.X - 3, boom.Y - 3, 6, 6);
                }

                foreach (Aap aap in apen)
                {
                    int rood = random.Next(50, 256);
                    int groen = random.Next(50, 256);
                    int blauw = random.Next(50, 256);

                    SolidBrush brush = new(Color.FromArgb(rood, groen, blauw));
                    Pen pen = new(Color.FromArgb(rood, groen, blauw));

                    if (aap.Naam == "初音ミク" || aap.Naam == "ミク" || aap.Naam == "Miku" || aap.Naam == "Hatsune Miku")
                    {
                        brush = new(ColorTranslator.FromHtml("#37b0bd"));
                        pen = new(ColorTranslator.FromHtml("#37b0bd"));
                    }

                    if (aap.Naam == "鏡音レン" || aap.Naam == "レン" || aap.Naam == "Rin" || aap.Naam == "Hatsune Miku")
                    {
                        brush = new(ColorTranslator.FromHtml("#f58a00"));
                        pen = new(ColorTranslator.FromHtml("#f58a00"));
                    }

                    if (aap.Naam == "鏡音リン" || aap.Naam == "リン" || aap.Naam == "Len" || aap.Naam == "Hatsune Miku")
                    {
                        brush = new(ColorTranslator.FromHtml("#e2b300"));
                        pen = new(ColorTranslator.FromHtml("#e2b300"));
                    }

                    if (aap.Naam == "巡音ルカ" || aap.Naam == "ルカ" || aap.Naam == "Luka" || aap.Naam == "Hatsune Miku")
                    {
                        brush = new(ColorTranslator.FromHtml("#eb66c1"));
                        pen = new(ColorTranslator.FromHtml("#eb66c1"));
                    }

                    if (aap.Naam == "MEIKO")
                    {
                        brush = new(ColorTranslator.FromHtml("#da6052"));
                        pen = new(ColorTranslator.FromHtml("#da6052"));
                    }

                    if (aap.Naam == "KAITO")
                    {
                        brush = new(ColorTranslator.FromHtml("#647aec"));
                        pen = new(ColorTranslator.FromHtml("#647aec"));
                    }

                    graphics.FillEllipse(brush, aap.Bomen[0].X - 3, aap.Bomen[0].Y - 3, 6, 6);
                    for (int i = 0; i < aap.Bomen.Count - 1; i++)
                    {
                        if (aap.Bomen[i + 1].X != -1)
                        {
                            graphics.DrawLine(pen, aap.Bomen[i].X, aap.Bomen[i].Y, aap.Bomen[i + 1].X, aap.Bomen[i + 1].Y);
                        }
                    }
                }

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += $"\\EscapeFromTheWoods\\Bitmappen";
                bitmap.Save(Path.Combine(path, $"Bos{bos.Id}_EscapeRoute.jpg"), ImageFormat.Jpeg);
                Console.WriteLine($"Einde bitmap - bos{bos.Id}");
            }
            catch (Exception ex)
            {
                throw new ApplicatieBeheerderException("Kan geen bitmap genereren.", ex);
            }
        }
#pragma warning restore CA1416 // Validate platform compatibility

        private async Task GenereerTekstBestand(Bos bos, List<Aap> apen)
        {
            try
            {
                Console.WriteLine($"Start tekstbestand - bos{bos.Id}");
                int langsteNaam = 0;
                foreach (Aap aap in apen)
                {
                    if (aap.Naam.Length > langsteNaam)
                    {
                        langsteNaam = aap.Naam.Length;
                    }
                }

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += $"\\EscapeFromTheWoods\\Tekstbestanden\\Bos{bos.Id}.txt";
                await using StreamWriter streamWriter = File.CreateText(path);

                int aantalStappen = 0;
                foreach (Aap aap in apen)
                {
                    if (aantalStappen < aap.Bomen.Count)
                    {
                        aantalStappen = aap.Bomen.Count;
                    }
                }

                int ontsnapt = 0;
                for (int i = 0; i < aantalStappen; i++)
                {
                    foreach (Aap aap in apen)
                    {
                        if (aap.Bomen.Count > i)
                        {
                            if (aap.Bomen[i].X != -1)
                            {
                                await Task.Run(() => streamWriter.WriteLine($"{aap.Naam.PadRight(langsteNaam, ' ')} zit in een boom met Id: {aap.Bomen[i].Id,3} met de coördinaten ({aap.Bomen[i].X,3}, {aap.Bomen[i].Y,3})."));
                            }
                            else
                            {
                                switch (ontsnapt)
                                {
                                    case 0:
                                        await Task.Run(() => streamWriter.WriteLine($"-----------------------------------------------------------------\n" +
                                    $"Gefeliciteerd {aap.Naam}, je bent als eerste uit het bos geraakt.\n" +
                                    $"-----------------------------------------------------------------"));
                                        break;
                                    case 1:
                                        await Task.Run(() => streamWriter.WriteLine($"-----------------------------------------------------------------\n" +
                                    $"Gefeliciteerd {aap.Naam}, je bent als tweeded uit het bos geraakt.\n" +
                                    $"-----------------------------------------------------------------"));
                                        break;
                                    case 2:
                                        await Task.Run(() => streamWriter.WriteLine($"-----------------------------------------------------------------\n" +
                                    $"Gefeliciteerd {aap.Naam}, je bent als derde uit het bos geraakt.\n" +
                                    $"-----------------------------------------------------------------"));
                                        break;
                                    default:
                                        await Task.Run(() => streamWriter.WriteLine($"-----------------------------------------------------------------\n" +
                                    $"Gefeliciteerd {aap.Naam}, je bent uit het bos geraakt.\n" +
                                    $"-----------------------------------------------------------------"));
                                        break;
                                }
                                ontsnapt++;
                            }
                        }
                    }
                }
                Console.WriteLine($"Stop tekstbestand - bos{bos.Id}");
            }
            catch (Exception ex)
            {
                throw new ApplicatieBeheerderException("Kan geen tekstbestand genereren.", ex);
            }
        }

        private async Task DataUploadenNaarDatabank(Bos bos, List<Boom> bomen, List<Aap> apen)
        {
            try
            {
                Console.WriteLine($"Start DataUploadenNaarDatabank - bos{bos.Id}");
                try
                {

                }
                catch (Exception ex)
                {
                    throw new ApplicatieBeheerderException("Kan niet uploaden naar databank", ex);
                }
                Console.WriteLine($"Stop DataUploadenNaarDatabank - bos{bos.Id}");
            }
            catch (Exception ex)
            {
                throw new ApplicatieBeheerderException("Kan gekregen data niet uploaden naar de databank.", ex);
            }
        }

        public async Task ProcessData(Bos bos)
        {
            List<Task> tasks1 = new();
            tasks1.Add(Task.Run(() => GenereerBitmap(bos, bos.Bomen, bos.Apen)));
            tasks1.Add(Task.Run(() => GenereerTekstBestand(bos, bos.Apen)));
            tasks1.Add(Task.Run(() => DataUploadenNaarDatabank(bos, bos.Bomen, bos.Apen)));
            Task.WaitAll(tasks1.ToArray());
            
        }
        #endregion
    }
}
