using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaLab.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Correto { get; set; }
        public int QuestaoId { get; set; }
    }
}
