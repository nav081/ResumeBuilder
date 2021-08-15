using ResumeBuilder.Utilities;

namespace ResumeBuilder.DTO.Templates
{
    public class TemplateModel
    {
        public int TemplateId { get; set; }
        public TemplateType Type { get; set; }

        public int HeaderId { get; set; }

        public int SalutaionId { get; set; }

        public int BodyId { get; set; }

        public int FooterId { get; set; }

        public int CreatedBy { get; set; }

        public int Popularity { get; set; }

        public string HTML { get; set; }
    }
}
