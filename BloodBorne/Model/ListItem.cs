namespace BloodBorne.Model
{
    public class ListItem
    {
        public event Action? OnListUpdated;
        public List<BossList> _items;
        public ListItem()
        {
            _items = [];
        }

        public void AddItem(Bosses bosses)
        {           
            _items.Add(new BossList { Bosses = bosses });
            OnListUpdated?.Invoke();
        }

        public void RemoveItem(Bosses bosses)
        {
            _items.RemoveAll(item => item.Bosses.Id == bosses.Id);
            OnListUpdated?.Invoke();
        }

        public IEnumerable<BossList> GetItems()
        {
            return _items;
        }
        public void SetItems(IEnumerable<BossList> items)
        {
            _items = items.ToList();
            OnListUpdated?.Invoke();
        }
    }
}

