using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCompleto.Adaptador
{
    public interface IAdaptador<TModel,TView>
    {
        TModel ToModel(TView view);
        TView ToView(TModel model);
        IEnumerable<TModel> ToModel(IEnumerable<TView> view);
        IEnumerable<TView> ToView(IEnumerable<TModel> model);


    }
}
