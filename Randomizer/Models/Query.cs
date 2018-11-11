using System;

namespace Randomizer.Models
{
    [Serializable]
    public class Query
    {
        #region Fields
        private Guid _guid;
        private int _fromNumber;
        private int _toNumber;
        private int _generatedElementsNumber;
        private DateTime _queryDate;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public int FromNumber
        {
            get { return _fromNumber; }
            set { _fromNumber = value; }
        }
        public int ToNumber
        {
            get { return _toNumber; }
            private set { _toNumber = value; }
        }
        public int GeneratedElementsNumber
        {
            get { return _generatedElementsNumber; }
            private set { _generatedElementsNumber = value; }
        }
        #endregion

        public Query(int fromNumber, int toNumber)
        {
            _guid = Guid.NewGuid();
            _fromNumber = fromNumber;
            _toNumber = toNumber;
            _generatedElementsNumber = fromNumber - toNumber + 1;
            _queryDate = DateTime.Now;
        }

        private Query()
        {
        }
        
        public override string ToString()
        {
            return $"From: {FromNumber}  To: {ToNumber}";
        }
    }
}
