using System.Collections.Generic;

namespace ResumeBuilder.Utilities.Models
{
    public class ResumeResponseModel
    {
        public string Heading { get; set; }
        public string Header_TextSize { get; set; }
        public string Header_TextColor { get; set; }
        public List<Sections1> Sections { get; set; }

    }



    public class Sections1
    {

        public string SectionName { get; set; }
        public string Section_Background_Color { get; set; }
        public string Section_Text_Color { get; set; }
        public string Section_Text_Size { get; set; }
        public string Elements_Text_Color { get; set; }
        public string Elements_Text_Size { get; set; }
        public List<string> Elements { get; set; }


    }


    public class CVRequestModel
    {
        public string SectionText { get; set; }

        public PersonalInfo Info { get; set; }

        public List<Skills> Skills { get; set; }

        public List<Section> Sections { get; set; }

    }


    public class PersonalInfo
    {

        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string LinkdInLink { get; set; }
        public string TwitterLink { get; set; }
        public string WebsiteLink { get; set; }

    }


    public class Skills {

        public string Skill_Text { get; set; }

        public string Skill_Score { get; set; }

        public string Skill_Level { get; set; }
    }


    public class Section {

        public string Section_Text { get; set; }

        public List<Section_Contents> MyProperty { get; set; }

    }


    public class Section_Contents {

        public string Duration { get; set; }

        public string Element_Text { get; set; }

        public string Description { get; set; }

    }
}
