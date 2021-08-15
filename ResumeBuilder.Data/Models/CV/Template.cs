using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeBuilder.Data.Models.CV
{
    public class Template : BaseEntitites
    {
        public TemplateType Type { get; set; }
        public int HeaderId { get; set; }
        [ForeignKey(nameof(HeaderId))]
        public Header Header { get; set; }
        public TemplateHeirarchy HeaderHeirarchy { get; set; }
        public int SalutaionId { get; set; }
        [ForeignKey(nameof(SalutaionId))]
        public TemplateHeirarchy SalutaionHeirarchy { get; set; }
        public Salutation Salutation { get; set; }
        public int BodyId { get; set; }
        [ForeignKey(nameof(BodyId))]
        public TemplateHeirarchy BodyHeirarchy { get; set; }
        public Body Body { get; set; }
        public int FooterId { get; set; }
        [ForeignKey(nameof(FooterId))]
        public TemplateHeirarchy FooterHeirarchy { get; set; }
        public Footer Footer { get; set; }
        public int CreatedBy { get; set; }
        public int Popularity { get; set; }
    }
}
