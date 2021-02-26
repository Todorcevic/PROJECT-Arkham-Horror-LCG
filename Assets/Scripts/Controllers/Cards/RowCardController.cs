using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public class RowCardController : CardController, IRowCardController
    {
        protected override void DoubleClick(ICardView cardView)
        {
            throw new NotImplementedException();
        }
    }
}
