using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Http;
using UoW.Core.Core;
using UoW.Core.Repository;

namespace UoW.WebAPI
{
    public class PersonController : ApiController
    {
        IRepository<Person> _rep = new Repository<Person>();

        // GET api/<controller> 
        [HttpGet]
        public IQueryable<Person> Getall(Expression<Func<Person, object>> expression)
        {
            return _rep.Getall(expression);
        }

        // GET api/<controller>/5   
        [HttpGet]
        public Person GetbyId(int id)
        {
            Person c = _rep.GetById(id);

            if (c == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return c;
        }

        // POST api/<controller>   
        [HttpPost]
        public Person Post(Person rep)
        {            
            try
            {
                _rep.Save(rep);
            }
            catch (Exception ex)
            {
                var erro = Environment.NewLine + ex.Message;
                throw new Exception(erro);
            }

            return rep;
        }
        
        // PUT api/<controller>/5
        [HttpPut]
        public Person Put(Person rep)
        {
            try
            {
                _rep.Update(rep);
            }
            catch (Exception ex)
            {
                var erro = Environment.NewLine + ex.Message;
                throw new Exception(erro);
            }

            return rep;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            Person c = _rep.GetById(id);
            _rep.Delete(c);
        }
    }
}