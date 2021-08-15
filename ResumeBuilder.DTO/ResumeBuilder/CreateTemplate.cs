using ResumeBuilder.Utilities;

namespace ResumeBuilder.DTO.ResumeBuilder
{
    public class CreateTemplate
    {
        public TemplateType Type { get; set; }
        public int HeaderId { get; set; }
        public TemplateHeirarchy HeaderHeirarchy { get; set; }
        public int SalutaionId { get; set; }
        public TemplateHeirarchy SalutaionHeirarchy { get; set; }
        public int BodyId { get; set; }
        public TemplateHeirarchy BodyHeirarchy { get; set; }
        public int FooterId { get; set; }
        public TemplateHeirarchy FooterHeirarchy { get; set; }
    }
}
