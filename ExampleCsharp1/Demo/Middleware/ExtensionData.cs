using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Demo.Middleware
{
    public class ExtensionValue
    {
        private ExtensionValueType _type;
        private object _value;

        #region ctor
        public ExtensionValue(Boolean value)
        {
            _type = ExtensionValueType.Boolean;
            _value = value;
        }

        public ExtensionValue(Int32 value)
        {
            _type = ExtensionValueType.Number;
            _value = value;
        }

        public ExtensionValue(Int64 value)
        {
            _type = ExtensionValueType.BigNumber;
            _value = value;
        }

        public ExtensionValue(Decimal value)
        {
            _type = ExtensionValueType.Decimal;
            _value = value;
        }

        public ExtensionValue(DateTime value)
        {
            _type = ExtensionValueType.DateTime;
            _value = value;
        }

        public ExtensionValue(String value)
        {
            _type = ExtensionValueType.String;
            _value = value;
        }

        public ExtensionValue(Guid value)
        {
            _type = ExtensionValueType.Guid;
            _value = value;
        }

        public ExtensionValue(TimeSpan value)
        {
            _type = ExtensionValueType.TimeSpan;
            _value = value;
        }

        public ExtensionValue(byte[] value)
        {
            _type = ExtensionValueType.Bytes;
            _value = value;
        }

        public ExtensionValue(IdDescriptionPair value)
        {
            _type = ExtensionValueType.IdDescriptionPair;
            _value = value;
        }
        #endregion

        public override string ToString()
        {
            if (_value == null)
                return string.Empty;

            return _value.ToString();
        }

        public override int GetHashCode()
        {
            if (_value == null)
                return 0;

            return _value.GetHashCode();
        }

        public object Value { get { return _value; } }

        public ExtensionValueType Type { get { return _type; } }

        #region #Value
        public Boolean BooleanValue
        {
            get
            {
                if (_type == ExtensionValueType.Boolean)
                    return (Boolean)_value;

                throw new InvalidCastException();
            }
        }

        public Int32 NumberValue
        {
            get
            {
                if (_type == ExtensionValueType.Number)
                    return (Int32)_value;

                throw new InvalidCastException();
            }
        }

        public Int64 BigNumberValue
        {
            get
            {
                if (_type == ExtensionValueType.BigNumber)
                    return (Int64)_value;

                throw new InvalidCastException();
            }
        }

        public Decimal DecimalValue
        {
            get
            {
                if (_type == ExtensionValueType.Decimal)
                    return (Decimal)_value;

                throw new InvalidCastException();
            }
        }

        public DateTime DateTimeValue
        {
            get
            {
                if (_type == ExtensionValueType.DateTime)
                    return (DateTime)_value;

                throw new InvalidCastException();
            }
        }

        public string StringValue
        {
            get
            {
                if (_type == ExtensionValueType.String)
                    return (string)_value;

                throw new InvalidCastException();
            }
        }

        public Guid GuidValue
        {
            get
            {
                if (_type == ExtensionValueType.Guid)
                    return (Guid)_value;

                throw new InvalidCastException();
            }
        }

        public TimeSpan TimeSpanValue
        {
            get
            {
                if (_type == ExtensionValueType.TimeSpan)
                    return (TimeSpan)_value;

                throw new InvalidCastException();
            }
        }

        public Byte[] BytesValue
        {
            get
            {
                if (_type == ExtensionValueType.Bytes)
                    return (Byte[])_value;

                throw new InvalidCastException();
            }
        }

        public IdDescriptionPair IdDescriptionPairValue
        {
            get
            {
                if (_type == ExtensionValueType.IdDescriptionPair)
                    return (IdDescriptionPair)_value;

                throw new InvalidCastException();
            }
        }
        #endregion

        #region Is#
        public bool IsBoolean { get { return _type == ExtensionValueType.Boolean; } }

        public bool IsNumber { get { return _type == ExtensionValueType.Number; } }

        public bool IsBigNumber { get { return _type == ExtensionValueType.BigNumber; } }

        public bool IsDecimal { get { return _type == ExtensionValueType.Decimal; } }

        public bool IsDateTime { get { return _type == ExtensionValueType.DateTime; } }

        public bool IsString { get { return _type == ExtensionValueType.String; } }

        public bool IsGuid { get { return _type == ExtensionValueType.Guid; } }

        public bool IsTimeSpan { get { return _type == ExtensionValueType.TimeSpan; } }

        public bool IsBytes { get { return _type == ExtensionValueType.Bytes; } }

        public bool IsIdDescriptionPair { get { return _type == ExtensionValueType.IdDescriptionPair; } }
        #endregion

        #region implicit operator
        public static implicit operator ExtensionValue(Boolean value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(Int32 value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(Int64 value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(Decimal value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(DateTime value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(String value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(Guid value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(TimeSpan value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(byte[] value)
        {
            return new ExtensionValue(value);
        }

        public static implicit operator ExtensionValue(KeyValuePair<Int32, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }

        public static implicit operator ExtensionValue(KeyValuePair<Int64, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }

        public static implicit operator ExtensionValue(KeyValuePair<Guid, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }

        public static implicit operator ExtensionValue(Tuple<Int32, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }

        public static implicit operator ExtensionValue(Tuple<Int64, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }

        public static implicit operator ExtensionValue(Tuple<Guid, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }

        public static implicit operator ExtensionValue(IdDescriptionPair value)
        {
            return new ExtensionValue(value);
        }
        #endregion
    }

    public enum ExtensionValueType
    {
        Boolean = 3,            // Boolean
        Number = 9,             // Signed 32-bit integer
        BigNumber = 11,         // Signed 64-bit integer
        Decimal = 15,           // Decimal
        DateTime = 16,          // DateTime
        String = 18,            // Unicode character string
        Guid = 19,              // Guid struct 
        TimeSpan = 20,          // TimeSpan struct
        Bytes = 21,             // Byte array -> byte[]      
        IdDescriptionPair = 22  // 
    }

    public class ExtensionData
    {
        private string _name;
        private ExtensionValue _value;

        public ExtensionData(string name, ExtensionValue value)
        {
            _name = name;
            _value = value;
        }

        public String Name { get { return _name; } }

        public ExtensionValue Value { get { return _value; } }
    }

    public class ExtensionDataCollection : IEnumerable<ExtensionData>
    {
        private Dictionary<string, ExtensionData> internalcollection;

        public ExtensionDataCollection()
        {
            internalcollection = new Dictionary<string, ExtensionData>();
        }

        public void Add(string name, ExtensionValue value)
        {
            Add(new ExtensionData(name, value));
        }

        public void Add(ExtensionData item)
        {
            internalcollection.Add(item.Name, item);
        }

        public bool ContainsName(string name)
        {
            return internalcollection.ContainsKey(name);
        }

        public bool Remove(string name)
        {
            return internalcollection.Remove(name);
        }

        public bool TryGetValue(string name, out ExtensionData value)
        {
            return internalcollection.TryGetValue(name, out value);
        }

        public bool TryGetValue(string name, out ExtensionValue value)
        {
            ExtensionData data;
            if (internalcollection.TryGetValue(name, out data))
            {
                value = data.Value;
                return true;
            }

            value = null;
            return false;
        }

        public ExtensionValue this[string name]
        {
            get
            {
                return internalcollection[name].Value;
            }
        }

        public void Clear()
        {
            internalcollection.Clear();
        }

        public int Count
        {
            get { return internalcollection.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)internalcollection.Values).GetEnumerator();
        }

        IEnumerator<ExtensionData> IEnumerable<ExtensionData>.GetEnumerator()
        {
            return ((IEnumerable<ExtensionData>)internalcollection.Values).GetEnumerator();
        }
    }


    public class IdDescriptionPair
    {
        private IdDescriptionValueType _type;
        private string _description;
        private object _value;
        private int _hashCode;

        #region ctor
        public IdDescriptionPair(Int32 value, string description)
            : this(IdDescriptionValueType.Number, value, description)
        {
        }

        public IdDescriptionPair(Int64 value, string description)
            : this(IdDescriptionValueType.BigNumber, value, description)
        {
        }

        public IdDescriptionPair(Guid value, string description)
            : this(IdDescriptionValueType.Guid, value, description)
        {
        }

        private IdDescriptionPair(IdDescriptionValueType type, object value, string description)
        {
            if (description == null)
                throw new ArgumentException("description");

            _type = type;
            _value = value;
            _description = description;
//            _hashCode = Util.HashCodeCombiner.CombineHashCodes(value.GetHashCode(), _description.GetHashCode());
        }
        #endregion

        public override string ToString()
        {
            if (_value == null)
                return string.Empty;

            return _value.ToString();
        }

        public override int GetHashCode()
        {
            if (_value == null)
            {
                return 0;
            }

            return _value.GetHashCode();
        }

        public string Description { get { return _description; } }

        public object Value { get { return _value; } }

        public IdDescriptionValueType Type { get { return _type; } }

        #region #Value
        public Int32 NumberValue
        {
            get
            {
                if (_type == IdDescriptionValueType.Number)
                    return (Int32)_value;

                throw new InvalidCastException();
            }
        }

        public Int64 BigNumberValue
        {
            get
            {
                if (_type == IdDescriptionValueType.BigNumber)
                    return (Int64)_value;

                throw new InvalidCastException();
            }
        }

        public Guid GuidValue
        {
            get
            {
                if (_type == IdDescriptionValueType.Guid)
                    return (Guid)_value;

                throw new InvalidCastException();
            }
        }
        #endregion

        #region Is#
        public bool IsNumber { get { return _type == IdDescriptionValueType.Number; } }

        public bool IsBigNumber { get { return _type == IdDescriptionValueType.BigNumber; } }

        public bool IsGuid { get { return _type == IdDescriptionValueType.Guid; } }
        #endregion

        #region implicit operator
        public static implicit operator IdDescriptionPair(KeyValuePair<Int32, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }

        public static implicit operator IdDescriptionPair(KeyValuePair<Int64, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }

        public static implicit operator IdDescriptionPair(KeyValuePair<Guid, string> pair)
        {
            return new IdDescriptionPair(pair.Key, pair.Value);
        }


        public static implicit operator IdDescriptionPair(Tuple<Int32, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }

        public static implicit operator IdDescriptionPair(Tuple<Int64, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }

        public static implicit operator IdDescriptionPair(Tuple<Guid, string> pair)
        {
            return new IdDescriptionPair(pair.Item1, pair.Item2);
        }
        #endregion
    }

    public enum IdDescriptionValueType
    {
        Number = 9,         // Signed 32-bit integer
        BigNumber = 11,     // Signed 64-bit integer     
        Guid = 19,          // Guid struct 
    }
}
