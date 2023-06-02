using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMSApi.Models
{
	public class Client
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int client_id { get; set; }

        public string school_Name { get; set; } = null!;

        public string state { get; set; } = null!;

        public string city { get; set; } = null!;

        public HomePageSections homepageSections { get; set; }
    }

    public class HomePageSections
    {
        
        public AppBar appBar { get; set; }

        public Main main { get; set; }

        public Headlines headlines { get; set; }

        
        public BottomBanner bottomBanner { get; set; }

        [BsonElement("slideshow")]
        public Dictionary<string, string> slideShow { get; set; }

        
        public SecondaryBanner secondaryBanner { get; set; }

        public Footer footer { get; set; }
    }

    public class AppBar
    {
        [BsonElement]
        public Dictionary<string, string> titles { get; set; }
    }


    public class Main
    {
        
        public string primaryImage { get; set; } = null!;

        
        public PrimaryLink primaryLink { get; set; }

        
        public PrimaryButton primaryButton { get; set; }

       
        public SecondaryButton secondaryButton { get; set; }
    }

    public class PrimaryLink
    {
        public string link { get; set; } = null!;
        public string text { get; set; } = null!;
    }

    public class PrimaryButton
    {
        public string link { get; set; } = null!;
        public string text { get; set; } = null!;
    }

    public class SecondaryButton
    {
        public string link { get; set; } = null!;
        public string text { get; set; } = null!;
    }

    public class Headlines
    {
        [BsonElement("primary_title")]
        public string primaryTitle { get; set; } = null!;

        //public Entry entry1 { get; set; }
        //public Entry entry2 { get; set; }
        //public Entry entry3 { get; set; }
        //public Entry entry4 { get; set; }
        //public Entry entry5 { get; set; }
        //public Entry entry6 { get; set; }

        public List<Entry> entries { get; set; }

    }

    public class BottomBanner
    {
        public string image { get; set; } = null!;

    }

    public class SlideShow
    {
        public Slide slide1 { get; set; }
        public Slide slide2 { get; set; }
        public Slide slide3 { get; set; }
        public Slide slide4 { get; set; }
    }

    public class SecondaryBanner
    {
        public Tile tile1 { get; set; }
        public Tile tile2 { get; set; }
        public Tile tile3 { get; set; }
        public Tile tile4 { get; set; }

    }

    public class Footer
    {
        public Links links { get; set; }
        public string image { get; set; } = null!;

    }

    public class Links
    {
        public Link link1 { get; set; }
        public Link link2 { get; set; }
        public Link link3 { get; set; }
    }

    public class Link
    {
        public string link { get; set; } = null!;
        public string text { get; set; } = null!;
    }

    public class Entry
    {
        public string link { get; set; } = null!;
        public string text { get; set; } = null!;
    }

    public class Slide
    {
        public string image { get; set; } = null!;
    }

    public class Tile
    {
        public string link { get; set; } = null!;
        public string image { get; set; } = null!;
    }
}

