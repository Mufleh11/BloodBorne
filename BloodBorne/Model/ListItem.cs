using BloodBorne.Components.Shared;

namespace BloodBorne.Model
{
    public class ListItem
    {
        public event Action? OnListUpdated;
        public List<BossItem> _items;

        public ListItem()
        {
            _items = [];
        }

        public void AddItem(Bosses bosses)
        {
            var item = _items.FirstOrDefault(item => item.Bosses.Id == bosses.Id);
            if (item == null)
                _items.Add(new BossItem { Bosses = bosses });

            //else
            //    item.Quantity += quantity;



            OnListUpdated?.Invoke();
        }

        public IEnumerable<BossItem> GetItems()
        {
            return _items;
        }

        public void SetItems(IEnumerable<BossItem> items)
        {

            _items = items.ToList();
            OnListUpdated?.Invoke();
        }
    }
}
