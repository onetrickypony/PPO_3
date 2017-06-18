using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1
{
    public class PersonInfo
    {
        private string surname;
        private string name;
        private string fathername;
        private int rating;
        private string avatar;

        public string Surname
        {
            get { return surname; }
        }

        public string Name
        {
            get { return name; }
        }
        public string FatherName
        {
            get { return fathername; }
        }
        public int Rating
        {
            get { return rating; }
        }

        public string Avatar
        {
            get { return avatar; }
        }
        public PersonInfo (string surname, string name, string fathername, int rating, string avatar)
        {
            this.surname = surname;
            this.name = name;
            this.fathername = fathername;
            this.rating = rating;
            this.avatar = avatar;
        }

    }
}
