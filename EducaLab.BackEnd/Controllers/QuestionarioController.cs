using EducaLab.Model;
using EducaLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EducaLab.BackEnd.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[RoutePrefix("api/questionario")]
    public class QuestionarioController : ApiController
    {
        static readonly IQuestionarioRepository repository = new QuestionarioRepository();

        public IEnumerable<QuestionarioModel> GetAll()
        {
            return repository.GetAll();
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var quest = repository.Get(id);

                if (quest == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, quest);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        public HttpResponseMessage Post(QuestionarioModel questionario)
        {
            try
            {
                if (questionario.Id > 0)
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Id inválido");

                if (string.IsNullOrEmpty(questionario.Nome))
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Nome é obrigatório");

                questionario = repository.Add(questionario);

                return Request.CreateResponse(HttpStatusCode.Created, string.Format("{0}/{1}", Request.RequestUri.AbsolutePath, questionario.Id));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        public HttpResponseMessage Put(QuestionarioModel questionario)
        {
            try
            {
                if (questionario.Id <= 0)
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Id inválido");

                if (string.IsNullOrEmpty(questionario.Nome))
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Nome é obrigatório");

                if (!repository.Update(questionario))
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, string.Format("{0}/{1}", Request.RequestUri.AbsolutePath, questionario.Id));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Id inválido");

                if (!repository.Remove(id))
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }
    }
}
