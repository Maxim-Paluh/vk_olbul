using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.Model
{
    public class search_works
    {
        [JsonProperty("all_autor_name")]
        public string AllAutorName { get; set; }

        [JsonProperty("all_autor_rusname")]
        public string AllAutorRusname { get; set; }

        [JsonProperty("altname")]
        public string Altname { get; set; }

        [JsonProperty("autor1_id")]
        public long Autor1Id { get; set; }

        [JsonProperty("autor1_is_opened")]
        public long Autor1IsOpened { get; set; }

        [JsonProperty("autor1_rusname")]
        public string Autor1Rusname { get; set; }

        [JsonProperty("autor2_id")]
        public long Autor2Id { get; set; }

        [JsonProperty("autor2_is_opened")]
        public long Autor2IsOpened { get; set; }

        [JsonProperty("autor2_rusname")]
        public string Autor2Rusname { get; set; }

        [JsonProperty("autor3_id")]
        public long Autor3Id { get; set; }

        [JsonProperty("autor3_is_opened")]
        public long Autor3IsOpened { get; set; }

        [JsonProperty("autor3_rusname")]
        public string Autor3Rusname { get; set; }

        [JsonProperty("autor4_id")]
        public long Autor4Id { get; set; }

        [JsonProperty("autor4_is_opened")]
        public long Autor4IsOpened { get; set; }

        [JsonProperty("autor4_rusname")]
        public string Autor4Rusname { get; set; }

        [JsonProperty("autor5_id")]
        public long Autor5Id { get; set; }

        [JsonProperty("autor5_is_opened")]
        public long Autor5IsOpened { get; set; }

        [JsonProperty("autor5_rusname")]
        public string Autor5Rusname { get; set; }

        [JsonProperty("autor_id")]
        public long AutorId { get; set; }

        [JsonProperty("autor_is_opened")]
        public long AutorIsOpened { get; set; }

        [JsonProperty("autor_rusname")]
        public string AutorRusname { get; set; }

        [JsonProperty("doc")]
        public long Doc { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("markcount")]
        public long Markcount { get; set; }

        [JsonProperty("midmark")]
        public double[] Midmark { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_eng")]
        public string NameEng { get; set; }

        [JsonProperty("name_show_im")]
        public string NameShowIm { get; set; }

        [JsonProperty("parent_work_id")]
        public long ParentWorkId { get; set; }

        [JsonProperty("parent_work_id_present")]
        public long ParentWorkIdPresent { get; set; }

        [JsonProperty("pic_edition_id")]
        public string PicEditionId { get; set; }

        [JsonProperty("pic_edition_id_auto")]
        public string PicEditionIdAuto { get; set; }

        [JsonProperty("rusname")]
        public string Rusname { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("work_id")]
        public long WorkId { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }
    }
}
