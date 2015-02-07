using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCompleto.Adaptador
{
    public abstract class AdaptadorBase<TModel, TView> :
        IAdaptador<TModel, TView>
   {
        public abstract TModel ToModel(TView view);
        public abstract TView ToView(TModel model);

        public IEnumerable<TModel> ToModel(IEnumerable<TView> view)
        {
           var l=new List<TModel>();
            foreach (var item in view)
            {
               l.Add(ToModel(item)); 
            }
            return l;
        }

        public IEnumerable<TView> ToView(IEnumerable<TModel> model)
        {
            var l = new List<TView>();
            foreach (var item in model)
            {
                l.Add(ToView(item));
            }
            return l;
        }
   }
}
