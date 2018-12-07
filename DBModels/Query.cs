using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace Randomizer.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Query
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private int _fromNumber;
        [DataMember]
        private int _toNumber;
        [DataMember]
        private int _generatedElementsNumber;
        [DataMember]
        private DateTime _queryDate;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;
        #endregion

        public Query(int fromNumber, int toNumber, User user) : this()
        {
            _guid = Guid.NewGuid();
            _fromNumber = fromNumber;
            _toNumber = toNumber;
            _generatedElementsNumber = toNumber - FromNumber + 1;
            _queryDate = DateTime.Now;
            _userGuid = user.Guid;
            _user = user;
            user.Queries.Add(this);
        }

        private Query()
        {
        }

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
        public DateTime QueryDate
        {
            get { return _queryDate; }
            private set { _queryDate = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        #endregion

        public override string ToString()
        {
            return $"From: {FromNumber} | To: {ToNumber} | Elements: {GeneratedElementsNumber}" +
                $" | Date: {QueryDate}";
        }

        #region EntityFrameworkConfiguration
        public class QueryEntityConfiguration : EntityTypeConfiguration<Query>
        {
            public QueryEntityConfiguration()
            {
                ToTable("Query");
                HasKey(s => s.Guid);

                 Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FromNumber)
                    .HasColumnName("FromNumber")
                    .IsRequired();
                Property(s => s.ToNumber)
                    .HasColumnName("ToNumber")
                    .IsRequired();
                Property(s => s.GeneratedElementsNumber)
                    .HasColumnName("GeneratedElementsNumber")
                    .IsRequired();
                Property(s => s.QueryDate)
                    .HasColumnName("QueryDate")
                    .IsRequired();
            }
        }
        #endregion

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}
