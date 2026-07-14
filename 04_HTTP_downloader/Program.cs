namespace _04_HTTP_downloader
{
    
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string link = "https://png.pngtree.com/png-clipart/20221230/original/pngtree-france-flag-transparent-with-watercolor-paint-brush-clipart-png-image_8826499.png";
            HttpResponseMessage response = await client.GetAsync(link);
            string way = "C:\\Users\\Світлана\\Desktop\\Мережеве програмування\\France.png";
            if (response.IsSuccessStatusCode)
            {
                byte[] img = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes(way, img );
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
