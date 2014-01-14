namespace Whim.Models
{
    public class User
    {
        public static bool operator ==(User rhs, User lhs)
        {
            if (ReferenceEquals(rhs, null) || ReferenceEquals(lhs, null))
                return ReferenceEquals(rhs, null) && ReferenceEquals(lhs, null);

            return rhs.Equals(lhs);
        }

        public static bool operator !=(User rhs, User lhs)
        {
            if (ReferenceEquals(rhs, null) || ReferenceEquals(lhs, null))
                return !ReferenceEquals(rhs, null) || !ReferenceEquals(lhs, null);

            return !rhs.Equals(lhs);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            var otherUser = obj as User;

            return obj != null && otherUser != null && FirstName == otherUser.FirstName && otherUser.LastName == LastName;
        }

        public override int GetHashCode()
        {
            return string.Format("{0}-{1}", FirstName, LastName).GetHashCode();
        }
    }
}