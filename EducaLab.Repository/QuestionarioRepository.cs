using EducaLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaLab.Repository
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private List<QuestionarioModel> questionarios = new List<QuestionarioModel>();
        private int idNext = 1;

        public QuestionarioRepository()
        {
            Add(new QuestionarioModel() { Nome = "História" });
            Add(new QuestionarioModel() { Nome = "Português" });
            Add(new QuestionarioModel() { Nome = "Matemática" });
        }

        public IEnumerable<Model.QuestionarioModel> GetAll()
        {
            return questionarios;
        }

        public Model.QuestionarioModel Get(int id)
        {
            return questionarios.Find(x => x.Id == id);
        }

        public Model.QuestionarioModel Add(Model.QuestionarioModel item)
        {
            if (item == null)
                throw new ArgumentNullException("Questionario");

            item.Id = idNext++;
            questionarios.Add(item);
            
            return item;
        }

        public bool Remove(int id)
        {
            QuestionarioModel quest = questionarios.FirstOrDefault(x => x.Id == id);
            if (quest == null)
                return false;

            questionarios.RemoveAll(x => x.Id == id);

            return true;
        }

        public bool Update(Model.QuestionarioModel item)
        {
            if (item == null)
                throw new ArgumentNullException("Questionario");

            QuestionarioModel quest = questionarios.FirstOrDefault(x => x.Id == item.Id);
            if (quest == null)
                return false;

            quest.Nome = item.Nome;

            return true;
        }
    }
}
