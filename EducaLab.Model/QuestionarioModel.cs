using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaLab.Model
{
    public class QuestionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<QuestaoModel> Questoes { get; set; }
    }
}
