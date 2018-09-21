using System;

namespace ModelLibrary
{
    public class RestData
    {
        private int _userId;
        private int _id;
        private string _title;
        private bool _completed;

        public RestData()
        {
        }

        public RestData(int userId, int id, string title, bool completed)
        {
            _userId = userId;
            _id = id;
            _title = title;
            _completed = completed;
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public bool Completed
        {
            get => _completed;
            set => _completed = value;
        }

        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Completed)}: {Completed}";
        }

        protected bool Equals(RestData other)
        {
            return _userId == other._userId && _id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RestData) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_userId * 397) ^ _id;
            }
        }
    }
}
