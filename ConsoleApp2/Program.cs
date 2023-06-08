
var playlist = new Queue<string>();//queue to store the playlist of songs
var history = new Stack<string>();//stack to keep track of the previously played songs

while (true)
{
    Console.WriteLine("Choose an option:\n");
    Console.WriteLine("1. Add a song to your playlist");
    Console.WriteLine("2. Play the next song in your playlist");
    Console.WriteLine("3. Skip the next song");
    Console.WriteLine("4. Rewind one song");
    Console.WriteLine("5. Exit\n");

    Console.Write("> ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Enter Song Name: ");
            var song = Console.ReadLine();
            playlist.Enqueue(song);   // to show the song to the end of the list
            Console.WriteLine($"\"{song}\" added to your playlist.\n");
            break;
        case "2":
            if (playlist.Count > 0)
            {
                var currentSong = playlist.Dequeue();   // to and remove the nxt song
                history.Push(currentSong);   // Add the current song
                Console.WriteLine($"Now playing \"{currentSong}\"\n");
                if (playlist.Count > 0)
                {
                    Console.WriteLine($"Next song: {playlist.Peek()}\n");   // to show the nxt song
                }
                else
                {
                    Console.WriteLine("Next song: none queued\n");
                }
            }
            else
            {
                Console.WriteLine("Your playlist is empty.\n");
            }
            break;
        case "3":
            if (playlist.Count > 0)
            {
                var skippedSong = playlist.Dequeue();   // to show and rmv the next song
                Console.WriteLine($"Skipped \"{skippedSong}\"\n");
                if (playlist.Count > 0)
                {
                    Console.WriteLine($"Next song: {playlist.Peek()}\n"); // to show the next song
                }
                else
                {
                    Console.WriteLine("Next song: none queued\n");
                }
            }
            else
            {
                Console.WriteLine("Your playlist is empty.\n");
            }
            break;
        case "4":
            if (history.Count > 0)
            {
                var previousSong = history.Pop(); //show and remove the prvs song
                playlist.Enqueue(previousSong); //add the prvs one
                Console.WriteLine($"Rewound to \"{previousSong}\"\n");
                Console.WriteLine($"Now playing \"{previousSong}\"\n");
                if (playlist.Count > 0)
                {
                    Console.WriteLine($"Next song: {playlist.Peek()}\n"); //show nxt song in list
                }
                else
                {
                    Console.WriteLine("Next song: none queued\n");
                }
            }
            else
            {
                Console.WriteLine("You haven't played any songs yet.\n");
            }
            break;
        case "5":
            Console.WriteLine("Goodbye!");
            return;   //Exit
        default:
            Console.WriteLine("Invalid option. Please try again.\n");
            break;
    }
}

