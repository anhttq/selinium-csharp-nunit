using Codeuctivity.ImageSharpCompare;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;

namespace CoreFramework.Utilities
{
    public class ImageProcessor 
    {
        static Image<Rgba32> ClearBlackBackGround(Image<Rgba32> image)
        {
            Color sourceColor = Color.Black;
            Color targetColor = Color.Transparent;
            float threshold = 0; 
            RecolorBrush brush = new RecolorBrush(sourceColor, targetColor, threshold); 
            DrawingOptions drawingOptions = new DrawingOptions
            {
                GraphicsOptions = new GraphicsOptions
                {
                    AlphaCompositionMode = PixelAlphaCompositionMode.Src,
                    ColorBlendingMode = PixelColorBlendingMode.Normal
                }
            }; 

            image.Mutate(x => x.Fill(drawingOptions, brush)); return image;
        }

        public static Image<Rgba32> ConvertRgb24ToRgba32(Image<Rgb24> imageRgb24)
        {
            var maskRgba32 = new Image<Rgba32>(imageRgb24.Width, imageRgb24.Height);

            for (var x = 0; x < imageRgb24.Width; x++)
            {
                for (var y = 0; y < imageRgb24.Height; y++)
                {
                    var pixel = new Rgba32();
                    pixel.FromRgb24(imageRgb24[x, y]);

                    maskRgba32[x, y] = pixel;
                }
            }
            return maskRgba32;
        }
        public static string MakeRelativePath(string fromPath, string toPath)
        {
            return Path.GetRelativePath(fromPath, toPath);
        }

        public static double CompareTwoImages(string actualImgFilePath, string baselineImgFilePath, string differentImgFilePath, string mergedImgFilePath, double expectedRate)
        {
            var actualImage = Image.Load(actualImgFilePath);
            var baselineImage = Image.Load(baselineImgFilePath);
            ICompareResult compareResult = ImageSharpCompare.CalcDiff(actualImage, baselineImage);
            var similarityRate = 100 - compareResult.PixelErrorPercentage;

            if (similarityRate < expectedRate)
            {
                var fileStreamDifferenceMask = File.Create(differentImgFilePath);
                Image<Rgb24> maskImage = (Image<Rgb24>)ImageSharpCompare.CalcDiffMaskImage(actualImgFilePath, baselineImgFilePath);
                SixLabors.ImageSharp.ImageExtensions.SaveAsPng(maskImage, fileStreamDifferenceMask);
                Image<Rgba32> rgba32Mask = ConvertRgb24ToRgba32(maskImage);
                Image<Rgba32> clearedMask = ClearBlackBackGround(rgba32Mask);

                using (Image<Rgba32> mergedImage = new Image<Rgba32>(clearedMask.Width, clearedMask.Height))
                {
                    SixLabors.ImageSharp.Point point = new SixLabors.ImageSharp.Point(0, 0);
                    mergedImage.Mutate(o => o
                    .DrawImage(actualImage, point, 1f) 
                    .DrawImage(clearedMask, point, 1f) 
                        );
                    mergedImage.Save(mergedImgFilePath);   
                }

                return similarityRate;
            }
            else
            {
                return similarityRate;
            }
        }
    }
}
