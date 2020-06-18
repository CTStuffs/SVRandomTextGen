using System;
using System.Collections.Generic;
using System.Text;

namespace SVTextGenerator
{
    public class SVCard
    {
		public int card_id;
		public int foil_card_id;
		public int card_set_id;
		public string card_name;
		public int is_foil;
		public int char_type;
		public int clan;
		public string tribe_name;
		public string skill;
		public string skill_condition;
		public string skill_target;
		public string skill_option;
		public string skill_preprocess;
		public string skill_disc;
		public string org_skill_disc;
		public string evo_skill_disc;
		public string org_evo_skill_disc;

		public int cost;
		public int atk;
		public int life;
		public int evo_atk;
		public int evo_life;
		public int rarity;
		public int get_red_ether;
		public int use_red_ether;
	
		public string description;
		public string evo_description;
		public string cv;
		public string copyright;
		public int base_card_id;
		public int normal_card_id;
		public int format_type;
		public int restricted_count;

		public SVCard()
        {

        }
	}
}
