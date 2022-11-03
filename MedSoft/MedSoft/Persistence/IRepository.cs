using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepository<ID,E> where E: Entity<ID>{
        E findOne(ID id);
        List<E> findAll();
        E save(E entity);
        void update(E entity);
        void delete(ID id);
    }
}
