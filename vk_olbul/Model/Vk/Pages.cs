using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.Model
{
   public class Pages
    {
        public long id { get; set; }
        public long group_id { get; set; }
        public long creator_id { get; set; }
        public string title { get; set; }
        public long current_user_can_edit { get; set; }
        public long current_user_can_edit_access { get; set; }
        public long who_can_view { get; set; }
        public long who_can_edit { get; set; }
        public long edited { get; set; }
        public long  created { get; set; }
        public long editor_id { get; set; }
        public long views { get; set; }
        public string parent { get; set; }
        public string parent2 { get; set; }
        public string source { get; set; }
        public string html { get; set; }
        public string view_url { get; set; }

    }
}
