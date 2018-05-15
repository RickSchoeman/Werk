using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.TwinfieldAPI.Handlers
{
    public delegate IEnumerable<TValue> GetCashData<TValue>();

    public delegate IEnumerable<TValue> GetCasheData<TValue, TKey>(TKey key);

    public delegate void ObjectLoadedEventHandler<TValue>(Object sender, ObjectLoadedEventArgs<TValue> e);
    public abstract class CasheData<TValue> where TValue : ICloneable
    {
        protected void OnGetDataLoaded(TValue value)
        {
            if (ObjectLoaded == null)
            {
                return;
            }

            ObjectLoaded(this, new ObjectLoadedEventArgs<TValue>(value));
        }

        public event ObjectLoadedEventHandler<TValue> ObjectLoaded;
        public abstract void Add(TValue item);
    }

    public class CasheData<TKey, TValue> : CasheData<TValue> where TValue : ICloneable
    {
        private readonly Dictionary<TKey, TValue> internalData;
        private readonly Func<TValue, TKey> keySelector;
        private readonly GetCasheData<TValue, TKey> getDataByKey;

        public CasheData(GetCashData<TValue> get, Func<TValue, TKey> keySelector)
        {
            internalData = new Dictionary<TKey, TValue>();
            this.keySelector = keySelector;
            this.getDataByKey = k => { return get(); };
        }

        public CasheData(GetCasheData<TValue, TKey> get, Func<TValue, TKey> keySelector)
        {
            internalData = new Dictionary<TKey, TValue>();
            this.keySelector = keySelector;
            this.getDataByKey = get;
        }

        public TValue Get(TKey key)
        {
            TValue value;
            if (internalData.TryGetValue(key, out value))
            {
                return (TValue) value.Clone();
            }

            foreach (var item in getDataByKey(key))
            {
                Add(item);
                OnGetDataLoaded(item);
            }

            if (internalData.TryGetValue(key, out value))
            {
                return (TValue) value.Clone();
            }

            return default(TValue);
        }

        public override void Add(TValue item)
        {
            this.internalData[this.keySelector(item)] = item;
        }
    }

    public class ObjectLoadedEventArgs<TValue> : EventArgs
    {
        private TValue item;

        public ObjectLoadedEventArgs(TValue item)
        {
            this.item = item;
        }
        public TValue Item
        {
            get { return this.item; }
        }
    }
}
