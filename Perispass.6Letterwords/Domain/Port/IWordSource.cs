using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perispass._6Letterwords.Domain.Port
{
    public interface IWordSource
    {
        IEnumerable<string> ReadWords();
    }
}
