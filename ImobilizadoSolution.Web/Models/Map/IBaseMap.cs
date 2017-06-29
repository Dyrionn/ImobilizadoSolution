using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadoSolution.Web.Models.Map
{
    public interface IBaseMap<TSource,TTarget>
    {
        TSource Mapper(TTarget target);

        TTarget Mapper(TSource source);

        List<TSource> Mapper(List<TTarget> targets);

        List<TTarget> Mapper(List<TSource> sources);
    }
}
