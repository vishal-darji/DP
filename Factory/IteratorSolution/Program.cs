using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //radio station
            SongsOfThe70s songs70s = new SongsOfThe70s();
            SongsOfThe80s songs80s = new SongsOfThe80s();
            SongsOfThe90s songs90s = new SongsOfThe90s();

            DiscJockey madMike = new DiscJockey(songs70s, songs80s, songs90s);

            // madMike.showTheSongs();

            madMike.showTheSongs2();
            Console.ReadLine();

        }
    }
    public class SongInfo
    {

        String songName;
        String movieName;
        int yearReleased;

        public SongInfo(String newSongName, String newmovieName, int newYearReleased)
        {

            songName = newSongName;
            movieName = newmovieName;
            yearReleased = newYearReleased;

        }

        public String getSongName() { return songName; }
        public String getmovieName() { return movieName; }
        public int getYearReleased() { return yearReleased; }

    }
    public interface SongIterator
    {

        IEnumerator createIterator();

    }


    public class SongsOfThe70s : SongIterator{
        
        // ArrayList holds SongInfo objects
        
        List<SongInfo> bestSongs;
        
        public SongsOfThe70s() {
               
               bestSongs = new List<SongInfo>();

               addSong("Chingari Koi Bhadke", "Amar Prem", 1972);
               addSong("Abhi Na Jao Chhodkar", "Hum Dono", 1971);
               addSong("Aanewala Pal", "Kanyadaan", 1978);
               
        }
        
        // Add a SongInfo object to the end of the ArrayList
        
        public void addSong(String songName, String movieName, int yearReleased){
               
               SongInfo songInfo = new SongInfo(songName, movieName, yearReleased);
               
               bestSongs.Add(songInfo);
               
        }
        
        
        // Get rid of this
        // Return the ArrayList filled with SongInfo Objects
        
        public List<SongInfo> getBestSongs(){
               
               return bestSongs;
               
        }

        // NEW By adding this method I'll be able to treat all
        // collections the same

        public IEnumerator createIterator()
        {
                // TODO Auto-generated method stub
               return bestSongs.GetEnumerator();
        }


        
    }

      

    public class SongsOfThe80s : SongIterator{
        
        // Create an array of SongInfo Objects
        
        SongInfo[] bestSongs;
        
        // Used to increment to the next position in the array
        
        int arrayValue = 0;
        
        public SongsOfThe80s() {
               
               bestSongs = new SongInfo[3];
               
               addSong("Gazab ka hai din", "QSQT", 1988);
               addSong("Jawani Janeman", "Namak halal", 1982);
               addSong("My Name is Lakhan", "Ram Lakhan", 1988);
               
        }
        
        // Add a SongInfo Object to the array and increment to the next position
        
        public void addSong(String songName, String movieName, int yearReleased){
               
               SongInfo song = new SongInfo(songName, movieName, yearReleased);
                       
               bestSongs[arrayValue] = song;
               
               arrayValue++;
               
        }
        
        // This is replaced by the Iterator
        
        public SongInfo[] getBestSongs(){
               
               return bestSongs;
               
        }

        // NEW By adding this method I'll be able to treat all
        // collections the same
               
        
        public IEnumerator createIterator() {
               // TODO Auto-generated method stub
            return bestSongs.GetEnumerator();   
        }
        
}


    public class SongsOfThe90s : SongIterator{
        
        // Create a Hashtable with an int as a key and SongInfo
        // Objects 
        Dictionary<int, SongInfo> bestSongs = new Dictionary<int, SongInfo>();
        
        //Hashtable<Integer, SongInfo> bestSongs = new Hashtable<Integer, SongInfo>();
        
        // Will increment the Hashtable key
        
        int hashKey = 0;
        
        public SongsOfThe90s() {
               
               addSong("Pehla Nasha", "Jo jeeta vohi sikandar", 1991);
               addSong("Mujhe Neend Aaye", "Radiohead", 1990);
               addSong("Chaiyya Chaiyya", "Dil Se", 1998);
               
        }
        
        // Add a new SongInfo Object to the Hashtable and then increment
        // the Hashtable key
        
        public void addSong(String songName, String movieName, int yearReleased){
               
               SongInfo songInfo = new SongInfo(songName, movieName, yearReleased);
               bestSongs.Add(hashKey, songInfo);
               hashKey++;
                       
        }
        
        // This is replaced by the Iterator
        // Return a Hashtable full of SongInfo Objects

        public Dictionary<int, SongInfo> getBestSongs()
        {
               
               return bestSongs;
               
        }

        // NEW By adding this method I'll be able to treat all
        // collections the same
        
        public IEnumerator createIterator() {
               // TODO Auto-generated method stub
            return bestSongs.Values.GetEnumerator();
        }
        
}

    public class DiscJockey
    {

        SongsOfThe70s songs70s;
        SongsOfThe80s songs80s;
        SongsOfThe90s songs90s;

        // NEW Passing in song iterators

        SongIterator iter70sSongs;
        SongIterator iter80sSongs;
        SongIterator iter90sSongs;

        /* OLD WAY
        public DiscJockey(SongsOfThe70s newSongs70s, SongsOfThe80s newSongs80s, SongsOfThe90s newSongs90s) {
               
               songs70s = newSongs70s;
               songs80s = newSongs80s;
               songs90s = newSongs90s;
               
        }
        */

        // NEW WAY Initialize the iterators   

        public DiscJockey(SongIterator newSongs70s, SongIterator newSongs80s, SongIterator newSongs90s)
        {

            iter70sSongs = newSongs70s;
            iter80sSongs = newSongs80s;
            iter90sSongs = newSongs90s;

        }

        public void showTheSongs()
        {

            // Because the SongInfo Objects are stored in different
            // collections everything must be handled on an individual
            // basis. This is BAD!

            List<SongInfo> aL70sSongs = songs70s.getBestSongs();

            Console.WriteLine("Songs of the 70s\n");

            foreach (SongInfo sng in aL70sSongs)
            {
                Console.WriteLine(sng.getSongName());
                Console.WriteLine(sng.getmovieName());
                Console.WriteLine(sng.getYearReleased() + "\n");
            }

            for (int i = 0; i < aL70sSongs.Capacity; i++)
            {

                SongInfo bestSongs = (SongInfo)aL70sSongs[i];

                

            }

            SongInfo[] array80sSongs = songs80s.getBestSongs();

            Console.WriteLine("Songs of the 80s\n");

            for (int j = 0; j < array80sSongs.Length; j++)
            {

                SongInfo bestSongs = array80sSongs[j];

                Console.WriteLine(bestSongs.getSongName());
                Console.WriteLine(bestSongs.getmovieName());
                Console.WriteLine(bestSongs.getYearReleased() + "\n");

            }

            Dictionary<int, SongInfo> ht90sSongs = songs90s.getBestSongs();

            Console.WriteLine("Songs of the 90s\n");

            foreach (KeyValuePair<int, SongInfo> entry in ht90sSongs)
            {
                Console.WriteLine( entry.Value.getSongName());
                Console.WriteLine(entry.Value.getmovieName());
                Console.WriteLine(entry.Value.getYearReleased() + "\n");
            }


            

        }

        // Now that I can treat everything as an Iterator it cleans up
        // the code while allowing me to treat all collections as 1

        public void showTheSongs2(){
               
               Console.WriteLine("NEW WAY WITH ITERATOR\n");
               
               IEnumerator Songs70s = iter70sSongs.createIterator();
               IEnumerator Songs80s = iter80sSongs.createIterator();
               IEnumerator Songs90s = iter90sSongs.createIterator();
               
               Console.WriteLine("Songs of the 70s\n");
               printTheSongs(Songs70s);
               
               Console.WriteLine("Songs of the 80s\n");
               printTheSongs(Songs80s);
               
                Console.WriteLine("Songs of the 90s\n");
               printTheSongs(Songs90s);
               
        }
        public void printTheSongs(IEnumerator enumerator)
        {

            while (enumerator.MoveNext())
            {

                SongInfo songInfo = (SongInfo)enumerator.Current;

                Console.WriteLine(songInfo.getSongName());
                Console.WriteLine(songInfo.getmovieName());
                Console.WriteLine(songInfo.getYearReleased() + "\n");

            }

        }


    }





}
