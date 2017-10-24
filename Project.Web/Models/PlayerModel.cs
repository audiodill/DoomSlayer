using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Life { get; set; }
        public string Gender { get; set; }
        public int XP { get; set; }
        public int Power { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Aptitude { get; set; }
        public int Luck { get; set; }
        public int XpLevel { get; set; }
        public int Gold { get; set; }
        public string PlayerType { get; set; }
        public string ImageName { get; set; }

        public static List<SelectListItem> PlayerTypes { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Human", Value = "Human"},
            new SelectListItem() {Text = "Dwarf", Value = "Dwarf"},
            new SelectListItem() {Text = "Elf", Value = "Elf"},
            new SelectListItem() {Text = "Dark Elf", Value = "Dark Elf"},
        };
    }
}