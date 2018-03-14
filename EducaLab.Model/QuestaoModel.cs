using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaLab.Model
{
    public class QuestaoModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public List<ItemModel> Itens { get; set; }
    }
}
