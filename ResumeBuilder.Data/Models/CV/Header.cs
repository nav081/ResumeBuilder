using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Utilities;

namespace ResumeBuilder.Data.Models.CV
{
    public class Header:BaseEntitites
    {
        public TemplateType Type { get; set; }
        public string HTML { get; set; }
        public int CreatedBy { get; set; }
        public int Popularity { get; set; }
    }
}
