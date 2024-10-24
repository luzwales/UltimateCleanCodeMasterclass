class MeaninglessWords
{
    class EmailManager //bad name - "manager" is too general. "Hnadler" is another example
    {
        public void SendEmail()
        {

        }
        public void CreateAccount()
        {

        }
    }

    string order; //bad names - hard to say how they are different
    string orderData;
    string orderInfo;
}

class OverspecificNames
{
    public class PeopleReader
    {
        public List<Person> ReadFromSqlDatabase() //bad name - too specific, there is no need to specify the source
        {
            return new List<Person>();  
        }
    }
}

class HungarianNotation
{
    int intAge; //bad names - there is no need to specify the type in the name
    string strLastName;
}

class ConfusingNames
{
    class UserDataStorage //bad name - almost the same as the one below
    {

    }

    class UsersDataStorage
    {

    }

    int itemsCount; //bad name - the meaning is the same as in the field below
    int countOfItems;

    void Copy(int[] array1, int[] array2) //bad name - hard to say the difference between those parameters
    {

    }
}

class Abbreviations
{
    string addr; //bad name - we shouldn't abbrevaite "address"
    string add; //even worse - may be confused for "add" as in adding two numbers
    string address; //good name
}