using IOCRTHINGEE;
using Tesseract;

namespace OCRTHINGEE
{
    class Tesseract : IOCRENGINE
    {
        private static TesseractEngine _engine;

        public  Tesseract()
        {
            _engine = new TesseractEngine(@"./tessdata", "small", EngineMode.TesseractOnly);
        }
        
        public  string GetText(string testImagePath)
        {
           
            
                using (var img = Pix.LoadFromFile(testImagePath))
                {
                    using (var page = _engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            
        }

        string IOCRENGINE.GetText(string testImagePath)
        {
            return GetText(testImagePath);
        }
    }
}
