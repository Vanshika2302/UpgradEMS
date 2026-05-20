using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UpGradEMS.DAL.Models;

namespace UpGradEMS.DAL.Repository
{
    public interface IEventRepository
    {
        List<EventDetails> GetAll();
        void Add(EventDetails eventObj);
        void Delete(Guid id);   
    }
}