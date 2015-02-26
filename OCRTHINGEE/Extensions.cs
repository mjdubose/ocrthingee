using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;

namespace OCRTHINGEE
{
    internal static class Extensions
    {
        public static string RemoveChars(this string s, params char[] removeChars)
        {
            var sb = new StringBuilder(s.Length);
            foreach (var c in s.Where(c => !removeChars.Contains(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
     



        public static void TryToDelete(this string f)
        {
            try
            {
                // Try to delete the file.
                File.Delete(f);
            }
            catch (IOException ie)
            {
                MessageBox.Show(ie.Message);
            }
        }

        public static Bitmap Crop(this Image image)
        {
            var imageX = new Bitmap(image);
            var filter =
                new Crop(new Rectangle((int) (.04*imageX.Width), (int) (.228*imageX.Height), (int) (.625*imageX.Width),
                    (int) (.675*imageX.Height)));
            // apply the filter
            var newImage = filter.Apply(imageX);
            return newImage;
        }

        public static Bitmap Clone(this Bitmap bmp, int startX, int startY, int width, int height)
        {
            var rawOriginal = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            var origByteCount = rawOriginal.Stride*rawOriginal.Height;
            var origBytes = new Byte[origByteCount];
            Marshal.Copy(rawOriginal.Scan0, origBytes, 0, origByteCount);

            const int bpp = 4; //4 Bpp = 32 bits, 3 = 24, etc.

            var croppedBytes = new Byte[width*height*bpp];

            //Iterate the selected area of the original image, and the full area of the new image
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width*bpp; j += bpp)
                {
                    var origIndex = (startX*rawOriginal.Stride) + (i*rawOriginal.Stride) + (startY*bpp) + (j);
                    var croppedIndex = (i*width*bpp) + (j);

                    //copy data: once for each channel
                    for (var k = 0; k < bpp; k++)
                    {
                        if (origIndex < origBytes.Length)
                        {
                            croppedBytes[croppedIndex + k] = origBytes[origIndex + k];
                        }
                    }
                }
            }

            //copy new data into a bitmap
            var croppedBitmap = new Bitmap(width, height);
            var croppedData = croppedBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(croppedBytes, 0, croppedData.Scan0, croppedBytes.Length);

            bmp.UnlockBits(rawOriginal);
            croppedBitmap.UnlockBits(croppedData);

            return croppedBitmap;
        }

        public static Image Invert(this Image imagex)
        {
            var image = AForge.Imaging.Image.Clone(new Bitmap(imagex), PixelFormat.Format24bppRgb);
            var filter = new Invert();
            filter.ApplyInPlace(image);
            return image;
        }

        public static Bitmap ResizeBmp(this Bitmap bmp)
        {
            var b0 = bmp;
            const double scale = 406/96;
            if (b0 == null) return null;
            if (b0.Height >= 20) return bmp;
            var width = (int) (b0.Width*scale);
            var height = (int) (b0.Height*scale);
            var bmpScaled = new Bitmap(b0, width, height);

            return bmpScaled;
        }

        public static Image DefineRowsForImageRipping(this Image pbimage, List<Row> rowlist)
        {
            if (pbimage == null) return null;
            var imageX = ClearHorizontalBars(new Bitmap(pbimage));

            var vert = 0;

            var image = AForge.Imaging.Image.Clone(imageX, PixelFormat.Format24bppRgb);
            while (vert < image.Height)
            {
                var hor = 0;
                while (hor < image.Width)
                {
                    var color = image.GetPixel(hor, vert);


                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    {
                        image.SetPixel(hor, vert, Color.Green);

                        hor++;
                    }
                    else
                    {
                        hor = image.Width;
                    }
                }
                vert++;
            }
            //   pb1.Image = image;
            for (var x = 0; x < image.Height; x++)
            {
                var color = image.GetPixel(image.Width - 1, x);

                if (color.R != 255 && color.G != 255 && color.B != 255)
                {
                    x++;
                }
                else
                {
                    var i = x - 2;
                    if (i < 0)
                    {
                        i = 0;
                    }
                    var thisrow = new Row {RowTop = i};
                    while (color.R == 255 && color.G == 255 && color.B == 255 && x < image.Height - 1)
                    {
                        x++;
                        color = image.GetPixel(image.Width - 1, x);
                    }

                    thisrow.RowBottom = x + 2;

                    if (thisrow.RowBottom - thisrow.RowTop > ((int) (image.Height*.0088)))
                    {
                        rowlist.Add(thisrow);
                    }
                }
            }

            return imageX;
        }

        public static Image FilterImage(this Image imageZ, decimal r1, decimal r2, decimal g1, decimal g2, decimal b1,
            decimal b2)
        {
            var imageX = new Bitmap(imageZ);
            var image = AForge.Imaging.Image.Clone(imageX, PixelFormat.Format24bppRgb);
            var filter = new ColorFiltering {FillOutsideRange = true};
            var red1 = Convert.ToInt32(r1);
            var red2 = Convert.ToInt32(r2);
            var green1 = Convert.ToInt32(g1);
            var green2 = Convert.ToInt32(g2);
            var blue1 = Convert.ToInt32(b1);
            var blue2 = Convert.ToInt32(b2);

            filter.Red = new IntRange(red1, red2);
            filter.Green = new IntRange(green1, green2);
            filter.Blue = new IntRange(blue1, blue2);

            var nImage = filter.Apply(image);
            return nImage;
        }

        public static Bitmap ClearHorizontalBars(Bitmap image)
        {
            var vert = 0;
            while (vert < image.Height)
            {
                var hor = 0;
                while (hor < image.Width)
                {
                    var color = image.GetPixel(hor, vert);
                    if (color.R <= 255 && color.R >= 240 && color.G <= 255 && color.G >= 240 && color.B <= 255 &&
                        color.B >= 240)
                    {
                        image.SetPixel(hor, vert, Color.White);
                    }
                    if (!(color.R == 255 && color.B == 255 && color.G == 255) && (hor == 0))
                    {
                        for (var dotwice = -3; dotwice < 3; dotwice++)
                        {
                            for (var horclear = 0; horclear < image.Width; horclear++)
                            {
                                if (vert + dotwice < 0)
                                {
                                }
                                else
                                {
                                    if (vert + dotwice > image.Height - 1)
                                    {
                                        image.SetPixel(horclear, vert, Color.White);
                                        dotwice = 3;
                                    }
                                    else
                                        image.SetPixel(horclear, vert + dotwice, Color.White);
                                }
                            }
                        }
                    }
                    hor++;
                }
                vert++;
            }
            return image;
        }
    }
}