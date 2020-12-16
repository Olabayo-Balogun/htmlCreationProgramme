using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace htmlCreationProgramme
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring a username
            Console.WriteLine("Please enter a username");
            string userName = Console.ReadLine();
            userName = $"<span style='color:red; font-size: 10vw;'>Your username is: </span>{userName.ToString()}";
            userName = $"<header style='background-color: blue; font-size: 9vw;' >{userName}</header>";

            //Declaring a file name
            Console.WriteLine("Please enter a file name");
            string fileName = Console.ReadLine();
            fileName = fileName.ToString();

            //Declaring the filepath
            string filePath = $"C:\\users\\OlabayoBalogun\\source\\repos\\htmlCreationProgramme\\htmlCreationProgramme\\{fileName}.html";


            //Declaring the blog content
            Console.WriteLine("Please write your blog's content");
            string blogContent = Console.ReadLine();
            blogContent = $"<p style='background-color: green; font-size: 5vw;'>{blogContent.ToString()}</p>";

            Console.WriteLine("Please enter the date published");
            string publishDate = $"<footer style='background-color: yellow; font-size: 5vw;'> { DateTime.Now.ToString("G")}</footer>";


            string fileContent = $"{userName} <br> {blogContent} <br> {publishDate}";

            //Creating the HTML file.
            File.WriteAllText(filePath, $"{fileContent}");


            
            Console.WriteLine("HTML File created.");
            Console.ReadLine();
        }
    }
}
