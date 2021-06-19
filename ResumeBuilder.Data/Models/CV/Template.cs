using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Utilities;

namespace ResumeBuilder.Data.Models.CV
{
    public class Template : BaseEntitites
    {
        public TemplateType Type { get; set; }

        public int HeaderId { get; set; }

        public int SalutaionId { get; set; }

        public int BodyId { get; set; }

        public int FooterId { get; set; }

        public int CreatedBy { get; set; }

        public int Popularity { get; set; }

        
    }
}
