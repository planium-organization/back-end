namespace KP.BackEnd.Core.DTOs.Shared.Profile
{
    public class StudentPutDto
    {
        private string _firstName;
        private string _lastName;
        private string _userName;
        private byte[] _image;
        private string _email;
        private string _major;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public byte[] Image
        {
            get => _image;
            set => _image = value;
        }
        
        public string Major
        {
            get => _major;
            set => _major = value;
        }
    }
}