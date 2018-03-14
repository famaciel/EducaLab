using EducaLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaLab.Repository
{
    public interface IQuestionarioRepository
    {
        IEnumerable<QuestionarioModel> GetAll();
        QuestionarioModel Get(int id);
        QuestionarioModel Add(QuestionarioModel item);
        bool Remove(int id);
        bool Update(QuestionarioModel item);
    }
}
