using ResumeBuilder.Utilities;

namespace ResumeBuilder.DTO.ResumeBuilder
{
    public class CreateTemplate
    {
        public TemplateType Type { get; set; }

        public int HeaderId { get; set; }

        public int SalutaionId { get; set; }

        public int BodyId { get; set; }

        public int FooterId { get; set; }
    }
}
