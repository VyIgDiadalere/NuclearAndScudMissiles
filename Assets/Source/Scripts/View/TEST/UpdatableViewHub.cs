using System.Collections.Generic;

namespace Source.Scripts.View.TEST
{
    public class UpdatableViewHub
    {
        private List<IUpdatableView> _views = new();

        public void RegisterView(IUpdatableView view)
        {
            if (_views.Contains(view))
            {
                return;
            }
            
            _views.Add(view);
        }

        public void UnregisterView(IUpdatableView view)
        {
            _views.Remove(view);
        }

        public void UpdateViews()
        {
            foreach (var view in _views)
            {
                view.Refresh();
            }
        }
    }
}