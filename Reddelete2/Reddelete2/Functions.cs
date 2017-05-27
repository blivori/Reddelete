using RedditSharp;
using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Reddelete2
{
    class Functions
    {

        Listing<Post> posts = null;
        Listing<Comment> comments = null;

        Reddit reddit = null;       
       

        public Reddit Login(string username, string password)
        {
            try
            {
                reddit = new Reddit(username, password);
            }
            catch(RedditException ex)
            {
                
            }

            return reddit;
        }

        public Listing<Comment> GetComments()
        {
            comments = reddit.User.Comments;

            return comments;
        }

        public Listing<Post> GetPosts()
        {

            posts = reddit.User.Posts;

            return posts;
        }

        public bool EditComments()
        {
            comments = GetComments();

            string[] dict = GetDictionaryFile();

            Random rnd = new Random();

            foreach (Comment c in comments)
            {
                string sentence = "";

                for (int i = 0; i < 7; i++)
                {
                    string randomWord = dict[rnd.Next(dict.Length)];
                    sentence = sentence + " " + randomWord;
                }

                try
                {
                    c.EditText(sentence);
                    c.Del();
                }
                catch (RedditException ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool EditPosts()
        {
            posts = GetPosts();

            string[] dict = GetDictionaryFile();

            Random rnd = new Random();


            foreach (Post p in posts)
            {
                string sentence = "";

                for (int i = 0; i < 7; i++)
                {
                    string randomWord = dict[rnd.Next(dict.Length)];
                    sentence = sentence + " " + randomWord;
                }

                try
                {
                    p.EditText(sentence);
                    p.Del();
                }
                catch (RedditException ex)
                {
                    return false;
                }
               
            }
            return true;
        }

        public bool DeleteComments()
        {
            foreach (Comment c in comments)
            {
                try
                {
                    c.Del();
                }
                catch (RedditException ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeletePosts()
        {
            foreach (Post p in posts)
            {
                try
                {
                    p.Del();
                }
                catch (RedditException ex)
                {
                    return false;
                }
            }
            return true;
        }

        public string[] GetDictionaryFile()
        {

            string[] dict = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dictionary.txt", Encoding.UTF8);
            
            return dict;
        }

        public bool DeleteAll(bool overwriteComments, bool overwritePosts, bool deleteComments, bool deletePosts)
        {
            try
            {
                if (overwriteComments == true)
                    EditComments();

                if (overwritePosts == true)
                    EditPosts();

                if (deleteComments == true)
                    DeleteComments();

                if (deletePosts == true)
                    DeletePosts();
            }
            catch (RedditException ex)
            {
                return false;
            }            
            return true;
        }

        [Serializable]
        private class RedditException : Exception
        {
            public RedditException()
            {
            }

            public RedditException(string message) : base(message)
            {
            }

            public RedditException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected RedditException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
