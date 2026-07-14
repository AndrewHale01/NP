using System.Net.Http.Json;

namespace _04_HTTP_json
{
    class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public override string ToString()
        {
            return $"{userId}, {id}, {title}";
        }
    }
    class Comment
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
        public override string ToString()
        {
            return $"{postId}, {id}, {name}";
        }
    }
    class Albums
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public override string ToString()
        {
            return $"{userId}, {id}, {title}";
        }
    }
    class Photos
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public override string ToString()
        {
            return $"{albumId}, {id}, {title}";
        }
    }
    public class Todos
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public override string ToString()
        {
            return $"{userId}, {id}, {title}";
        }
    }
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
        public override string ToString()
        {
            return $"{street}, {suite}, {city}, {zipcode}, {geo}";
        }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        public override string ToString()
        {
            return $"{name}, {catchPhrase}, {bs}";
        }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public override string ToString()
        {
            return $"{lat}, {lng}";
        }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
        public override string ToString()
        {
            return $"{id}, {name}, {username}, {email}, {address}, {phone}, {website}, {company}";
        }
    }


    internal class Program
    {
        static async Task Main(string[] args)
        {
            string linkPosts = "https://jsonplaceholder.typicode.com/posts";
            string linkComments = "https://jsonplaceholder.typicode.com/comments";
            string linkAlbums = "https://jsonplaceholder.typicode.com/albums";
            string linkPhotos = "https://jsonplaceholder.typicode.com/photos";
            string linkTodos = "https://jsonplaceholder.typicode.com/todos";
            string linkUsers = "https://jsonplaceholder.typicode.com/users";
            HttpClient client = new HttpClient();

            Console.WriteLine("-------- Enter number from 1 to 6: --------\n" +
                "1. Posts\n" +
                "2. Comments\n" +
                "3. Albums\n" +
                "4. Photos\n" +
                "5. Todos\n" +
                "6. Users\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var data = await client.GetFromJsonAsync<Post[]>(linkPosts);
                    if (data != null)
                    {
                        foreach (var post in data)
                        {
                            Console.WriteLine(post);
                        }
                    }
                    break;
                case 2:
                    var comments = await client.GetFromJsonAsync<Comment[]>(linkComments);
                    if (comments != null)
                    {
                        foreach (var comment in comments)
                        {
                            Console.WriteLine(comment);
                        }
                    }
                    break;
                case 3:
                    var albums = await client.GetFromJsonAsync<Albums[]>(linkAlbums);
                    if (albums != null)
                    {
                        foreach (var album in albums)
                        {
                            Console.WriteLine(album);
                        }
                    }
                    break;
                case 4:
                    var photos = await client.GetFromJsonAsync<Photos[]>(linkPhotos);
                    if (photos != null)
                    {
                        foreach (var photo in photos)
                        {
                            Console.WriteLine(photo);
                        }
                    }
                    break;
                case 5:
                    var todos = await client.GetFromJsonAsync<Todos[]>(linkTodos);
                    if (todos != null)
                    {
                        foreach (var todo in todos)
                        {
                            Console.WriteLine(todo);
                        }
                    }
                    break;
                case 6:
                    var users = await client.GetFromJsonAsync<User[]>(linkUsers);
                    if (users != null)
                    {
                        foreach (var user in users)
                        {
                            Console.WriteLine(user);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("There is no such number");
                    break;
            }

        }
        
    }
}
