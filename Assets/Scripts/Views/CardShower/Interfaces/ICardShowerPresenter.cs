using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardShowerPresenter
    {
        void Show(CardShowerDTO showableCard);
        void Hide();
        Task AddInvestigatorAnimation(Vector2 placeHolderPosition);
    }
}
