using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterSave : PictureProvider
    {
        public void toSavePicture(IPicture picture, string path)
        {
            int width = picture.Width;
            int height = picture.Height;
            using(Image<Rgba32> image = new Image<Rgba32>(width, height)) // creates a new image with all the pixels set as transparent
            {
                for (int h = 0; h < picture.Height; h++)
                {
                    for (int w = 0; w < picture.Width; w++)
                    {
                        Color c = picture.GetColor(w, h);
                        image[w, h] = new Rgba32(c.R, c.G, c.B, c.A);
                    }
                }
                image.Save(path);
            }
        }        


    }
}