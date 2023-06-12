namespace BookDetailsApp.Models
{
    public class BookDto
    {
        // Properties
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

        // MLA citation property
        public string MLACitation
        {
            get
            {
                string citation = $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {Year}.";
                return citation;
            }
        }

        // Chicago style citation property
        public string ChicagoCitation
        {
            get
            {
                string author = AuthorFirstName + ' ' + AuthorLastName;
                string citation = $"{author}. {Title}. {Publisher}; {Year}.";
                return citation;
            }
        }
    }
}