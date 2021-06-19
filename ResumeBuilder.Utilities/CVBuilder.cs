using System.IO;

namespace ResumeBuilder.Utilities
{
    public static class CVBuilder
    {
        public static Stream Htmltopdf(string html) {

            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);
            MemoryStream stream = new MemoryStream();
            stream.Position = 0;
            doc.Save(stream);
            doc.Close();
            return stream;
        }

    }
}
