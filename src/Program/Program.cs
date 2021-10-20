using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            
            IFilter grey = new FilterGreyscale();
            IFilter negative = new FilterNegative();
            PipeNull pnull = new PipeNull();
            PipeSerial segpipe = new PipeSerial(negative, pnull);
            PipeSerial pipe = new PipeSerial(grey, segpipe);
            picture = pipe.Send(picture);


           
            PictureProvider applyfilters = new PictureProvider();
            FilterSave luke_ = applyfilters.toSavePicture(applyfilters , @"luke.jpg");
            PipeSerial terpipe = new PipeSerial(FilterSave, pnull);

        


        }
    }
}
