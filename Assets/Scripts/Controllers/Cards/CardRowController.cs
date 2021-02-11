using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public class CardRowController : CardController
    {
        protected override int AmountSelected(string cardId)
        {
            return 0;
        }
    }
}
