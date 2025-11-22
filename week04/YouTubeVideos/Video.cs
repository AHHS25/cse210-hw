using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // This class represents a YouTube video with a list of comments
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }

        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        // Add a comment to the video
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Return the number of comments
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        // Return the list of comments
        public List<Comment> GetComments()
        {
            return _comments;
        }
    }
}
