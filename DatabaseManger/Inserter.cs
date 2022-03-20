using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.DatabaseManger
{
    public class Inserter
    {
        public async Task<bool> Insert(Activity activity)
        {
            var context = new ActivityContext();
            context.Activities.Add(activity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
