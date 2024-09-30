namespace TrophyAssignment
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }
        public Trophy()
        {
            
        }

        public void ValidateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException();
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition has less than 3 characters: ", Competition);
            }
        }
        public void ValidateYear()
        {
            if (1970 > Year || Year > 2024)
            {
                throw new ArgumentOutOfRangeException("Year has to be between 1970 and 2024: ", Year.ToString());
            }
        }
        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
        public override string ToString()
        {
            return $"Id: {Id} -- Competition: {Competition} -- Year: {Year}";
        }
    }
}