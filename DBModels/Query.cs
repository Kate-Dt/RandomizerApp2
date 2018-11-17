using System;
using System.Data.Entity.ModelConfiguration;

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
        private Guid _userGuid;
        private User _user;
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

        public Query(int fromNumber, int toNumber, User user) : this()
        {
            _guid = Guid.NewGuid();
            _fromNumber = fromNumber;
            _toNumber = toNumber;
            _generatedElementsNumber = fromNumber - toNumber + 1;
            _queryDate = DateTime.Now;
            _userGuid = user.Guid;
            _user = user;
            user.Queries.Add(this);
        }

        private Query()
        {
        }

        public override string ToString()
        {
            return $"From: {FromNumber}  To: {ToNumber} Elements in sequence: {GeneratedElementsNumber}" +
                $"Date: {QueryDate}";
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
